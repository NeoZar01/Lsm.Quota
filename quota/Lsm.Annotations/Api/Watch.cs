using System;

using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DoE.Lsm.Annotations.Exceptions
{

    /// <summary>
    ///     Swallows a technical exceptions and returns a user friendly exception message
    /// </summary>
    [PSerializable]
    public class Watch : OnMethodBoundaryAspect
    {

        /// <summary>
        ///     This message will be send out to the user
        /// </summary>
        protected string _enduserMessage        =  string.Empty;

        /// <summary>
        /// 
        /// </summary>
        protected int _code                      = 10054;


        public Watch(object For, int code, string exception)
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
                args.Exception = new global::System.Exception(string.Concat(_enduserMessage, " ", args.Instance));

                //push to the logFile using log4net

                args.FlowBehavior = FlowBehavior.ThrowException;

            }else if (args.Exception.GetType() == typeof(FailedTransactionException))
            {
                args.Exception = new global::System.Exception(string.Concat(_enduserMessage, " ", args.Instance));

                //push to the logFile using log4net

                args.FlowBehavior = FlowBehavior.ThrowException;
            }

            base.OnException(args);
        }




    }
}
