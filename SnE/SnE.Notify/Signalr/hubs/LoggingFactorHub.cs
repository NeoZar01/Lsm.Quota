using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DoE.Notify.Hubs
{
    [HubName("LoggingFactorHub")]
    public class LoggingFactorHub : Hub
    {
        public void Annotate(string error)
        {
            this.Clients.Caller.onNotifyInvoked(error);
        }
    }
}