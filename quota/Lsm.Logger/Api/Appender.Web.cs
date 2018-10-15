using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoE.Lsm.Logger.Context;
using Microsoft.AspNet.SignalR;
using DoE.Notify.Hubs;

namespace DoE.Lsm.Logger.Api
{

    public class WebAppenderHub : IAppender
    {
        public void Debug(string incident)
        {
            throw new NotImplementedException();
        }

        public void Log(string error)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SystemHealthMonitorHub>();
                context.Clients.All.Annotate(error);
        }
    }
}
