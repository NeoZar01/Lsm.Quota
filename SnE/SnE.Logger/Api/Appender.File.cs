using System;
using System.Text;

using log4net;

namespace DoE.Lsm.Logger.Api
{
    using Context;

    public class FileAppenderHub : IAppender
    {
        private readonly ILog _log;

        public FileAppenderHub(object caller)
        {
           _log = LogManager.GetLogger(caller.ToString());
        }

        //File.WriteInto<Error>(incident, incident.InstanceId,  DefaultFolder.Exceptions, Files.Formats.Abstracts.Format.Xml);            
        public void Log(string error)
        {
            if (string.IsNullOrEmpty(error)) new ArgumentNullException(nameof(error));
            try
            {
                _log.Info(error);
            }
            catch(Exception e)
            {
                Log(e.StackTrace);
            }
        }

        public void Debug(string error)
        {
            if (typeof(Error).IsInstanceOfType(error)) new ArgumentNullException(nameof(error));

            //File.WriteInto<Error>(incident, incident.InstanceId,  DefaultFolder.Exceptions, Files.Formats.Abstracts.Format.Xml);            
            try
            {
                _log.Debug(error);
            }
            catch (Exception e)
            {
                Log(e.StackTrace);
            }
        }
    }
}