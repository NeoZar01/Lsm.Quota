using System;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repositories
{

    using EF;
    using Logger;
    using WF.Engine.Context;
    using Annotations.Exceptions;

    public class RequisitionRepository : RepositoryFactory<Requisition>, IRequisitionsRepository
    {

        private string _status;
        private string _requisitionInReadMemory;

        private delegate ExecutionResult WorkTask(int e);

        public RequisitionRepository(PortalLsm dbContext, ILogger logger) : base(dbContext, logger)
        { }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReqId"></param>
        /// <returns></returns>
        public ExecutionResult Park(Requisition requisition, string stage, string state)
        {
            requisition.LastModifiedDate = DateTime.Now;
            requisition.State = state;

            try
            {
                return DbContext.SaveChanges() == 1 ? ExecutionResult.Success : ExecutionResult.Failed;
            }
            catch
            {
                throw new InvalidDatabaseOperationException("There was an error processing your request. The Workflow engine failed to move your payload to another state");
            }
        }


        public async Task<Requisition> GetRequisitionByEntityIdAsync(Guid ReqId)
        {
            try
            {

                return await DbContext.Requisitions
                                                .Where(c => c.ReqNO.Equals(ReqId))
                                                .SingleOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }


        public Requisition FindByInstanceId(Guid reqId)
        {
            try
            {
                return DbContext.Requisitions
                                          .Where(c => c.InstanceId.Equals(reqId)).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }




        public async Task<ExecutionResult> ParkAsync(Requisition requisition, string stage, string state)
        {
            requisition.LastModifiedDate = DateTime.Now;
            requisition.State = state;
 
            try
            {
                return await DbContext.SaveChangesAsync() == 1 ? ExecutionResult.Success : ExecutionResult.Failed;
            }
            catch
            {
                throw;
            }
        }


        public string State
        {
            get
            {
                return _status;
            }

            set
            {
                var requisitionLinq = DbContext.Requisitions.Where(c => (c.InstanceId.Equals(new Guid(value)))).SingleOrDefault();

                _status = requisitionLinq == null ? "INVALID" : requisitionLinq.State;
            }
        }


        public string LastInMemoryRequisition
        {
            get
            {
                return _requisitionInReadMemory;
            }
            set
            {

                var requisition = DbContext.Requisitions
                                           .Where(c => c.EmisToken.Equals(value) && c.State.Equals("IN_MEMORY"))  //make sure it was never send to the drafts or denied
                                           .OrderByDescending((c) => c.LastModifiedDate) //order the last updated requisition
                                           .Take(1)           //take the first on the list
                                           .FirstOrDefault();  //just to be sure.     

                _requisitionInReadMemory = (requisition == null) ? null : requisition.ReqNO;

            }
        }

        public async Task<bool> IsInstanceReadWriteAsync(string reqNo, string emisId)
        {
            try
            {

                var requisitionQuery = await DbContext.Requisitions
                                                                .Where(c => c.ReqNO.Equals(reqNo) && c.EmisToken.Equals(emisId))
                                                                .FirstOrDefaultAsync();

                if (requisitionQuery != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }


        }

        public async Task<string> MergeOnAsync(Guid entityId, string reqNo, School s, byte minGrade, byte maxGrade, string calendar, string stage, string state)
        {
            try
            {

                Requisition requisition;

                if (await ExistsAsync(entityId))
                {
                    requisition = DbContext.Requisitions
                                           .Where(c => c.InstanceId.Equals(entityId) && c.EmisToken.Equals(s.RowGuid.ToString()) && c.Calendar.Equals(calendar))
                                           .SingleOrDefault();

                    requisition.LastModifiedDate = DateTime.Now;
                    requisition.State = state;

                }
                else
                {

                    requisition = new Requisition
                    {
                        Calendar = calendar,
                        EmisToken = s.RowGuid.ToString(),
                        ReqNO = reqNo,
                        GrFrom = minGrade,
                        GrTo = maxGrade,
                        CreationDate = DateTime.Now,
                        LastModifiedDate = DateTime.Now,
                        State = state
                    };

                    DbContext.Requisitions.Add(requisition);
                }

                var task = await DbContext.SaveChangesAsync();

                return (ExecutionResult)task == ExecutionResult.Success ? requisition.ReqNO : null;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Requisition> GetRequisitionsByState(string emisId, string stage, string state)
        {
            return DbContext.Requisitions
                                      .Where(c => c.EmisToken.Equals(emisId)  && c.State.Equals(state))
                                      .OrderByDescending(c => c.CreationDate);
        }

        public int RequisitionsPerCalendar(string emisEntityId, string calendar)
        {
            try
            {
                return DbContext.Requisitions
                                           .Where(c => c.EmisToken == emisEntityId && (c.Calendar.Equals(calendar)))
                                           .Count();
            }
            catch
            {
                return 0;
            }
        }


        public decimal TotalPricePerCalendar(string emisId, string calendar, string state)
        {

            try
            {
                var sumLinq = DbContext.Requisitions
                                                .Where(c => c.EmisToken.Equals(emisId) && c.Calendar.Equals(calendar) && c.State == state)
                                                .Sum(c => c.TotalPrice);

                return sumLinq != null ? Math.Round(sumLinq ?? 0, 2, MidpointRounding.AwayFromZero) : 0M;
            }
            catch
            {
                return 0M;
            }
        }


        public bool Exists(Guid entityId)
        {
            try
            {

                var requisition = DbContext.Requisitions
                                                           .Where(c => c.InstanceId.Equals(entityId))
                                                           .SingleOrDefaultAsync();

                return requisition != null;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> ExistsAsync(Guid entityId)
        {
            try
            {

                var requisition = await DbContext.Requisitions
                                                           .Where(c => c.InstanceId.Equals(entityId))
                                                           .SingleOrDefaultAsync();

                return requisition != null;
            }
            catch
            {
                return false;
            }

        }


        public PortalLsm DbContext
        {
            get
            {
                return this._DbContext as PortalLsm;
            }
        }

    }
}
