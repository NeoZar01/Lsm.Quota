using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoE.Lsm.WF.Core
{

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
