using System;

namespace DoE.Lsm.Annotations.Exceptions
{
    using Logger;
    using Logger.Context;
    using System.Text;

    [Serializable] public class FailedBatchTransactionException : Exception
    {

        private readonly bool _hasToLog;
        private Error _error;
        private ILogger _logger;

        public FailedBatchTransactionException() {}
        public FailedBatchTransactionException(string exceptionMessage) :base(exceptionMessage) { }

        public FailedBatchTransactionException(string UIMessage, string stackTrace, bool hasToLog, ILogger logger)  : base(UIMessage)
        {
            this._hasToLog = hasToLog;
            this._logger = logger;

            Error = new Error { StackTrace = stackTrace, LogTime = DateTime.Now };
        }

        // <summary>
        //   Returns an instance of the error thread via the logging singleton.
        // </summary>
        public virtual Error Error
        {
            get { return _error; }

            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));

                StringBuilder record = new StringBuilder();
                              record.Append(string.Concat(value.Code, "------ ", value.AttemptedAction, ": ", string.Concat(" [", value.LogTime, "] ")));
                              record.Append(string.Concat("Entity: ", value.Entity));
                              record.Append(string.Concat("EntityType: ", value.ErrorType));
                              record.Append(string.Concat("StackTrace: ", value.StackTrace, " "));

                if (_hasToLog == true)
                {
                    var thread = _logger.ConfigureAlert;
                        thread.Report = record.ToString();
                }
                _error = value;  //throw a user friendly error message to the end user.
            }
        }
    }
}