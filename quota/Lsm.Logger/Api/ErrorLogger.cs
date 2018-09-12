using System;
using System.Collections.Generic;

namespace DoE.Lsm.Logger
{
    using Context;

    ///<summary>
    ///  Logs errors based on severity level.
    ///</summary>
    public sealed class ErrorLogger : IDisposable, ILogger
    {

        /// <summary>
        ///     Stores all listeners
        /// </summary>
        private IList<IOnLog>  listernersStore = new List<IOnLog>();

        /// <summary>
        ///     
        /// </summary>
        private static Monitor              _monitorExceptionSub;

        private static Severity.High        _severityLevel;

        //constructor
        public ErrorLogger() {}

        #region Singleton - Minor Errors
        public ILogger Minor
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance            = new ErrorLogger(); //instantiate a new instance

                        _monitorExceptionSub = new Monitor(); //instantiate the monitor listerner
                        _severityLevel       = Severity.High.No;
                        _instance.Register(_monitorExceptionSub);
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Singleton -  Critical errors
        public ILogger Critical
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ErrorLogger();

                        _monitorExceptionSub = new Monitor();
                        _severityLevel       = Severity.High.Yes;
                        _instance.Register(_monitorExceptionSub);
                        return _instance;
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        ///     Notify all listerners about the error
        /// </summary>
        public Incident Exception
        {
            set
            {
                value.Level = (int)_severityLevel;
                NotifyAll(value);
            }
        }

        /// <summary>
        ///     Register a listerner
        /// </summary>
        /// <param name="observer"></param>
        public void Register(IOnLog observer)
        {
            listernersStore.Add(observer);
        }

        /// <summary>
        ///     De-Register a listerner
        /// </summary>
        /// <param name="observer"></param>
        public void UnRegister(IOnLog observer)
        {
            listernersStore.Add(observer);
        }

        /// <summary>
        ///     Notifier
        /// </summary>
        /// <param name="exceptionEnv"></param>
        public void NotifyAll(Incident exceptionEnv)
        {
            foreach (var observer in listernersStore)
            {
                observer.Log(exceptionEnv);
            }

        }

        #region  Gabbage Collection Stuff

        private static volatile ErrorLogger _instance;

        private static readonly object _syncLock = new object();

        private bool _disposed = false;


        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);            
        }

        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _instance = null;
                _monitorExceptionSub = null;
            }
        }
        #endregion
    }
}