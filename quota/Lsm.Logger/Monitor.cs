using DoE.Lsm.Logger.Context;
using System;

using Default = DoE.Lsm.UoW;

namespace DoE.Lsm.Logger
{

    public class Monitor : IOnLog
    {
        public Monitor() {}

        public void Log(Incident incident)
        {

            if (typeof(Incident).IsInstanceOfType(incident)) new ArgumentNullException(nameof(incident));

            try
            {               
                Default::File.WriteInto<Incident>(incident, incident.InstanceId,  DefaultFolder.Exceptions, Files.Formats.Abstracts.Format.Xml);            
            }
            catch(System.Exception e)
            {
                Log(new Incident
                {
                    LogTime         = DateTime.Now, StackTrace = this.ToString(),
                    Entity          = "0",
                    Message         = "Failed to save XML to the incident directory",
                    Source        = e.InnerException.ToString(),
                    Level           = (int)Severity.High.Yes,
                    Solution        = "N/A" 
                });
                //ph
            }
        }

        public void Debug(Incident incident)
        {}

    }
}