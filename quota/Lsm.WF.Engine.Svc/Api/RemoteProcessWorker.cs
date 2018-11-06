using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Reflection.BindingFlags;

namespace DoE.Lsm.WF.Engine.Context
{
    using Entities;
    using WI.Context.Entities;

    public static class RemoteProcessWorker
    {
        public static ProcessWorkItem Method(ProcessWorkItem context)
        {
            try
            {
                Type rmi = Type.GetType(context.DestinationUser);

                IRole instance = (IRole)Activator.CreateInstance(rmi);

                var outcome = rmi.InvokeMember(context.InstanceEntityType.Equals("Async") ? "ProcessRequestAsync" : "ProcessRequest", InvokeMethod, null, instance, new object[] { });

            }
            catch
            {
                 return new ProcessWorkItem {Status = "ERROR"};
            }

                return new ProcessWorkItem { Status = "SUCCESS" };
        }
    }
}