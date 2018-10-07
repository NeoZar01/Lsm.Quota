using System;
using System.Text;

using log4net;

namespace DoE.Lsm.Logger
{
    using Context;

    public class FileAppender : IOnLog
    {
        private readonly ILog _log;

        public FileAppender(object caller)
        {
           _log = LogManager.GetLogger(caller.ToString());
        }

        //File.WriteInto<Error>(incident, incident.InstanceId,  DefaultFolder.Exceptions, Files.Formats.Abstracts.Format.Xml);            
        public void Log(Error error)
        {
            if (typeof(Error).IsInstanceOfType(error)) new ArgumentNullException(nameof(error));

            StringBuilder record = new StringBuilder();
                          record.Append(string.Concat(error.Code, "------ ", error.AttemptedAction, ": " , string.Concat(" [", error.LogTime, "] ")));
                          record.Append(string.Concat("Entity: ",error.Entity));
                          record.Append(string.Concat("EntityType: ",error.ErrorType));
                          record.Append(string.Concat("StackTrace: ",error.StackTrace," "));
            try
            {
                _log.Info(record);
            }
            catch(Exception e)
            {
                Log(new Error
                {
                    LogTime         = DateTime.Now,
                    Entity          = error.Entity,
                    AttemptedAction = "Log an Info Error",
                    StackTrace      = e.InnerException.ToString(),
                    Code            = 1050
                });
            }
        }

        public void Debug(Error error)
        {
            if (typeof(Error).IsInstanceOfType(error)) new ArgumentNullException(nameof(error));

            //File.WriteInto<Error>(incident, incident.InstanceId,  DefaultFolder.Exceptions, Files.Formats.Abstracts.Format.Xml);            
            try
            {
                _log.Debug(error.StackTrace);
            }
            catch (Exception e)
            {
                Log(new Error
                {
                    LogTime = DateTime.Now,
                    Entity = error.Entity,
                    AttemptedAction = "Log an Debug Error",
                    StackTrace = e.InnerException.ToString(),
                    Code = 1050
                });
            }
        }
    }
}