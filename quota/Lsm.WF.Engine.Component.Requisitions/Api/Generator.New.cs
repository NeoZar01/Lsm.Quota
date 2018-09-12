using System;
using System.Threading.Tasks;

using Utils = DoE.Lsm.WF.Engine.Context;
using DoE.Lsm.Data.Repositories;

namespace DoE.Lsm.WF.Component.Requisitions.Tasks
{

    public sealed class New
    {

        private readonly IRepositoryStore _databaseContext;

        public New(IRepositoryStore databaseContext)
        { this._databaseContext = databaseContext; }


        ///<summary>	 
        ///  <para> Allows different requisitions to be opened concurrently on the same browser without interrupting each other's sessions.  </para>
        ///  <para> Handles differents states of the requistions[Draft | New | Last_In_Memory] </para>
        ///  <para> Avoids data loss by saving all items on the shopping card into an in_memory state requisition</para>
        ///  
        ///  <return> Requisition Number </return>
        ///</summary>
        //  Creates a new requisitons number
        public async Task<string> RequisitionInstanceNumber(string requisitionNo, string emisID, int term)
        {

            if (string.IsNullOrEmpty(requisitionNo))
            {
                string inMemoryRequisition = _databaseContext.Requisitions.LastInMemoryRequisition = emisID;  //Check for any requisitions in an in-memory state

                if (!string.IsNullOrEmpty(inMemoryRequisition))
                {
                    Status = global::DoE.Lsm.WF.Engine.Context.Utils.State(_databaseContext.Requisitions.State = inMemoryRequisition);
                    return inMemoryRequisition;
                }
                else
                {

                    var isReadWrite = string.IsNullOrEmpty(requisitionNo) ? false : await _databaseContext.Requisitions.IsInstanceReadWriteAsync(requisitionNo, emisID);

                    if (isReadWrite == true)
                    {
                        Status = global::DoE.Lsm.WF.Engine.Context.Utils.State(_databaseContext.Requisitions.State = inMemoryRequisition);
                        return requisitionNo;
                    }

                    string RequisitionDateFormat = (DateTime.Today.Year).ToString().Substring(2, 2) + DateTime.Today.Month + DateTime.Today.Day + DateTime.Today.Minute + DateTime.Now.Hour + DateTime.Now.Second;
                    string newRequisitioNum = emisID + "/" + term + "-" + RequisitionDateFormat;

                    // use a recursive function to ensure that the newly created requisition does not conflict with any other created requisition.
                    var isAlreadyInUse = await _databaseContext.Requisitions.IsInstanceReadWriteAsync(newRequisitioNum, emisID);

                    if (isAlreadyInUse == true)
                    {
                        await RequisitionInstanceNumber(requisitionNo, emisID, term);
                    }

                    Status = global::DoE.Lsm.WF.Engine.Context.Utils.State("IN_MEMORY");
                    return newRequisitioNum;
                }
            }

            Status = global::DoE.Lsm.WF.Engine.Context.Utils.State(_databaseContext.Requisitions.State = requisitionNo);
            return requisitionNo;
        }

        public string Status { get; set; }

    }
}
