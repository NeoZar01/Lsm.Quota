using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Reflection.BindingFlags;

namespace DoE.Lsm.WF.Engine.Svc.Context
{
    using Engine.Context;

    public static class ProcessInvoker
    {
        public static PayloadContext Call(PayloadContext context)
        {
            try
            {
                Type destinationMember = Type.GetType(context.DestinationUser);

                object instance = Activator.CreateInstance(destinationMember);

                object outcome = destinationMember.InvokeMember(context.RequestTokenType.Equals("Async") ? "ProcessRequestAsync" : "ProcessRequest", InvokeMethod, null, instance, new object[] { });


            }
            catch
            {
                 return new PayloadContext {Status = "ERROR"};
            }

                return new PayloadContext { Status = "SUCCESS" };
        }
    }
}