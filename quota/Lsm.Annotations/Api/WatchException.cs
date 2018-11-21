using System;

using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DoE.Lsm.Annotations.Exceptions
{
    using Api.Exceptions;

    /// <summary>
    ///     Swallows a technical exceptions and returns a user friendly exception message
    /// </summary>
    [PSerializable]
    public class WatchException : OnMethodBoundaryAspect
    {

        /// <summary>
        ///     This message will be send out to the user
        /// </summary>
        protected string _enduserMessage        =  string.Empty;
        protected int _code                      = 10054;

        public WatchException(object For, int code, string exception)
        {
            this._enduserMessage = exception;
            this._code = code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {

            if (args.Exception.GetType() == typeof(InvalidDatabaseOperationException))
            {
                args.Exception = new UIException(_enduserMessage);

                //push to the logFile using log4net

                args.FlowBehavior = FlowBehavior.ThrowException;

            }else if (args.Exception.GetType() == typeof(FailedTransactionException))
            {
            
                args.Exception = new UIException(_enduserMessage);

                //push to the logFile using log4net

                args.FlowBehavior = FlowBehavior.ThrowException;
            }

            base.OnException(args);
        }




    }
}
