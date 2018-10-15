using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DoE.Notify.Hubs
{
    [HubName("SystemHealthMonitorHub")]
    public class SystemHealthMonitorHub : Hub
    {
        public void Annotate(string error)
        {
            this.Clients.Caller.onCriticalExceptionThrown(error);
        }

    }
}