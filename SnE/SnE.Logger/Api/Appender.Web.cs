using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoE.Lsm.Logger.Context;
using Microsoft.AspNet.SignalR;

namespace DoE.Lsm.Logger.Api
{
    using Notify.Hubs;

    public class WebAppenderHub : IAppender
    {
        public void Debug(string incident)
        {
            throw new NotImplementedException();
        }

        public void Log(string error)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LoggingFactorHub>();
                context.Clients.All.onNotifyInvoked(error);
        }
    }
}
