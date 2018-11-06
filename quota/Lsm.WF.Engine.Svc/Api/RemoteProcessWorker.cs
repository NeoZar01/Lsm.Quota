using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Reflection.BindingFlags;

namespace DoE.Lsm.WF.Engine.Context
{

    public static class RemoteProcessWorker
    {
        //public static WorkInstance Method(WorkInstance context)
        //{
        //    try
        //    {
        //        Type rmi = Type.GetType(context.DestinationUser);

        //        IRole instance = (IRole)Activator.CreateInstance(rmi);

        //        var outcome = rmi.InvokeMember(context.RequestType.Equals("Async") ? "ProcessRequestAsync" : "ProcessRequest", InvokeMethod, null, instance, new object[] { });

        //    }
        //    catch
        //    {
        //         return new WorkInstance {Status = "ERROR"};
        //    }

        //        return new WorkInstance { Status = "SUCCESS" };
        //}
    }
}