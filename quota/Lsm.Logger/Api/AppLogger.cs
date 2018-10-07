using System;
using System.Collections.Generic;

using log4net;
using log4net.Core;


namespace DoE.Lsm.Logger
{
    using Context;
    using static Context.Level;

    ///<summary>
    ///  Logs errors based on severity level.
    ///</summary>
    public sealed class AppLogger :  ILogger, IDisposable
    {

        #region Custom Logging Properties
        private IList<IOnLog> hubs = new List<IOnLog>();
        private static FileAppender fileHub;
        private static Level level;

        public ILogger Record
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppLogger();

                        fileHub   = new FileAppender(this);
                        level     = Low;
                        _instance.Register(fileHub);
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        public ILogger Warn
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppLogger();
                        level = High;
                        _instance.Register(fileHub);
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        ///     Notify all listerners about the error
        /// </summary>
        public Error Exception
        {
            set
            {
                value.Code = (int)level;
                NotifyAll(value);
            }
        }

        /// <summary>
        ///     Register a listerner
        /// </summary>
        /// <param name="observer"></param>
        public void Register(IOnLog observer)
        {
            hubs.Add(observer);
        }

        /// <summary>
        ///     De-Register a listerner
        /// </summary>
        /// <param name="observer"></param>
        public void UnRegister(IOnLog observer)
        {
            hubs.Add(observer);
        }

        /// <summary>
        ///     Notifier
        /// </summary>
        /// <param name="exceptionEnv"></param>
        public void NotifyAll(Error error)
        {
            foreach (var observer in hubs)
            {
                observer.Log(error);
            }

        }
        #endregion

        #region  Gabbage Collection Stuff

        private static volatile AppLogger _instance;

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
                fileHub = null;
            }
                #endregion

        }
        public AppLogger() { }

    }
}