namespace DoE.Lsm.Annotations.Exceptions
{
    using System;

    using Logger;
    using Logger.Context;

    //<summary>
    //   Standard error that should be thrown when an invalid operation is attempted on the database
    //  <remark> Select :
    //   <para> This error is paramount when a scale is expected to be called but a null value is return. </para>
    //   <para> Can be used to notify is a scale/norm sync failed by returning null on scale queries</para>
    //  </remark>
    //</summary>
    [Serializable] public class InvalidDatabaseOperationException : Exception 
    {

 
        //default constructor
        public InvalidDatabaseOperationException() {}

        //constructor with just exception message 
        public InvalidDatabaseOperationException(string exceptionMessage) :base(exceptionMessage) { }

        //Constructor with logging capabilities.
        //<summary>
        //
        //<param name="exception"></param>
        //</summary>
        #warning I am in progress of replacing this constructor with the log4net framework
        public InvalidDatabaseOperationException(string userError, string stackTrace) 
            : base(userError)
        {}

    }
}
