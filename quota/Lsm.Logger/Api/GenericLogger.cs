using System;
using System.Collections.Generic;

using log4net;
using log4net.Core;


namespace DoE.Lsm.Logger
{
    using Api;
    using Context;

    using static Context.Level;

    public sealed class GenericLogger :  ILogger, IDisposable
    {
        private IList<IAppender> hubs = new List<IAppender>();
        private static FileAppenderHub fileHub;
        private static WebAppenderHub  webHub;
        private static Level level;

        public ILogger InitiateWarningInstace
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new GenericLogger();

                        fileHub   = new FileAppenderHub(this);
                        webHub    = new WebAppenderHub();

                        level     = Low;
                        _instance.Register(fileHub);
                        _instance.Register(webHub);
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        public ILogger InitiateAlertInstance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new GenericLogger();
                        level     = High;
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
        public string Report
        {
            set
            {
                NotifyAll(value);
            }
        }

        /// <summary>
        ///     Register a listerner
        /// </summary>
        /// <param name="observer"></param>
        private void Register(IAppender observer)
        {
            hubs.Add(observer);
        }

        /// <summary>
        ///     De-Register a listerner
        /// </summary>
        /// <param name="observer"></param>
        private void UnRegister(IAppender observer)
        {
            hubs.Add(observer);
        }

        /// <summary>
        ///     Notifier
        /// </summary>
        /// <param name="exceptionEnv"></param>
        private void NotifyAll(string error)
        {
            foreach (var observer in hubs)
            {
                observer.Log(error);
            }

        }

        #region  GC

        private static volatile GenericLogger _instance;

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
        public GenericLogger() { }

    }
}