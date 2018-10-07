using System;

namespace DoE.Lsm.Annotations.Exceptions
{
    using Logger;
    using Logger.Context;

    [Serializable] public class FailedTransactionException : Exception
    {

        private readonly bool _hasToLog;
        private Error _error;
        private ILogger _logger;

        public FailedTransactionException() {}
        public FailedTransactionException(string exceptionMessage) :base(exceptionMessage) { }

        public FailedTransactionException(string UIMessage, string stackTrace, bool hasToLog, ILogger logger)  : base(UIMessage)
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

                if (_hasToLog == true)
                {
                    var thread = _logger.Warn;
                        thread.Exception = value;
                }
                _error = value;  //throw a user friendly error message to the end user.
            }
        }
    }
}