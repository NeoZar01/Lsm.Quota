using System;
using System.ComponentModel.DataAnnotations;

namespace DoE.Lsm.WF.Engine.Context
{

    ///<summary>
    ///     This will be the envelop that wraps all the requests to the Workflow engine. 
    ///  <remark> Similar to <c>HttpContext</c> </remark>
    /// </summary>
    public class ProcessWorkItem
    {
        /// <summary>
        ///     Initial Instance Id of the EntityType thrown
        /// </summary>
        [Key]
        public string ProcessInstanceToken
        { get; set; }

        /// <summary>
        ///     Initial Instance Id of the EntityType thrown
        /// </summary>
        public string InstanceEntityType
        { get; set; }

        /// <summary>
        ///         Any Entity type passed with the payload
        /// </summary>
        public string ProcessInstanceId
        { get; set; }

        public string param_001 { get; set; }

        public string param_002 { get; set; }

        public string param_003 { get; set; }

        public string param_004 { get; set; }

        public string param_005 { get; set; }

        public string param_006 { get; set; }

        public string param_007 { get; set; }

        public string param_008 { get; set; }

        public string param_009 { get; set; }

        public string param_0010 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status
        { get; set; }


        /// <summary>
        ///         Assigned Role
        /// </summary>
        public string Role
        { get; set; }

        /// <summary>
        ///         Used for routing
        /// </summary>
        public string Route
        { get; set; }

        /// <summary>
        ///         Taken action
        /// </summary>
        public Response Response
        { get; set; }

        /// <summary>
        ///         GEID of sender
        /// </summary>
        public string  IdentityToken
        { get; set; }

        /// <summary>
        ///         Name of sender
        /// </summary>
        public string User
        { get; set; }

        /// <summary>
        ///         Payload receiver
        /// </summary>
        public string DestinationUser
        { get; set; }

        /// <summary>
        ///         Receiver name
        /// </summary>
        public string ReceiverName
        { get; set; }


        /// <summary>
        ///         SubEntity inheriting from the above entity
        /// </summary>
        public object SubEntity
        { get; set; }

    }

    ///<summary>
    ///  Actions injected to the Reponse model by the above mentioned roles.
    ///</summary>
    public enum Response : int 
    {
      Discard = 0,
      Submit  = 1,
      Deny    = 2,
      Approve = 3
    }

    /// <summary>
    ///     Dirty Read Transaction options  
    /// </summary>
    public enum ReadMode
    { Dirty, Clean }

   /**
    *  @return : This replaces tasks options on most functions that returns the following flags
               :  0 | 1 | True | False
    */
    public enum ExecutionResult : int 
    { Success = 1, Failed = -1 , Idle = -1 }

    /**
     * Enables/Disables Transactions
    */
    public enum With
    { Transaction, NonTransitive }


    /// <summary>  Sets the Parking station for an entity
    ///
    /// </summary>
    public enum Stations : int
    {
      School        = 0,
      Circuit       = 1,
      District      = 2,
      HeadOffice    = 3,
      Treasury      = 4
    }

    public static class Utils
    {
        /// <summary> 
        ///      Sets the state of the item. 
        ///   <remark>
        ///      Reduces the risk of losing  unsaved/undrafted requisitions 
        ///   </remark>
        /// </summary>
        public static string State(string state)
        {
            if( state == null || string.IsNullOrEmpty(state) || string.IsNullOrWhiteSpace(state) )
            {
                throw new ArgumentNullException("state");
            }

            switch (state)
            {
                case "IN_MEMORY":
                    return state;
                default:
                    return "Invalid state token";
            }
        }
    }
}
