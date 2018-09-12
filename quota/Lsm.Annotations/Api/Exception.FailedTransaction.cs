using System;

namespace DoE.Lsm.Annotations.Exceptions
{

    using Logger;
    using Logger.Context;

    [Serializable] public class FailedTransactionException : Exception
    {

        //<summary>
        //  Severity level of the Exception
        //</summary>
        private readonly Severity.High _priorityLevel;

        //<summary>
        //  Determines whether we should log this operation or not.
        //</summary>
        private readonly bool _hasToLog;
        private Incident _error;

        //</summary>
        //   Instance of the logger class that will be used to log the error
        //<summary>
        private ILogger _logger;

        //default constructor
        public FailedTransactionException() { }

        //constructor with just exception message 
        public FailedTransactionException(string exceptionMessage) :base(exceptionMessage) { }

        //Constructor with logging capabilities.
        //<summary>
        //
        //<param name="exception"></param>
        //</summary>
        public FailedTransactionException(string userError, string stackTrace, string solution, string entity, object entityKey, bool hasToLog, Severity.High priorityLevel, ILogger logger) 
            : base(userError)
        {
            this._priorityLevel = priorityLevel;
            this._hasToLog = hasToLog;
            this._logger = logger;

            //Exception instance report
            Error = new Incident
            {
                Source = stackTrace,
                Solution = solution,
                Message = userError,
                LogTime = DateTime.Now,
                Entity = entity
            };
        }


        // <summary>
        //   Returns an instance of the error thread via the logging singleton.
        // </summary>
        public virtual Incident Error
        {
            get { return _error; }

            private set
            {
                //* Add events to include this error to a incident file. *//

                if (value == null) throw new ArgumentNullException(nameof(value));

                if (_hasToLog == true)
                {
                    //checks priority level  
                    switch (_priorityLevel)
                    {
                        case Severity.High.No:
                            var lowThread = _logger.Minor;
                            lowThread.Exception = value;
                            break;
                        case Severity.High.Yes:
                            var highThread = _logger.Critical;
                            highThread.Exception = value;   //log this error to multiple logging hubs.
                            break;
                    }
                }
                _error = value;  //throw a user friendly error message to the end user.
            }
        }

    }
}
