using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PostSharp;
using PostSharp.Serialization;
using PostSharp.Aspects;

namespace DoE.Lsm.Annotations.Api
{

    [PSerializable]
    public class RequestTokenHandler : OnMethodBoundaryAspect
    {

        public override void OnEntry(MethodExecutionArgs args)
        {   base.OnEntry(args);
             
          if(args.Arguments.Count > 0 && args.Arguments[0] == null)
          {
                
          }

        }

    }
}
