using DoE.Notify.Exception.Objects;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DoE.Notify.Hubs
{

    [HubName("ExceptionsHub")]
    public class ExceptionMonitorHub : Hub
    {

        public void AlertOfAllException(ExceptionEnvelop exceptionEnvelop)
        {
            this.Clients.Caller.onCriticalExceptionThrown(exceptionEnvelop);
        }

    }
}