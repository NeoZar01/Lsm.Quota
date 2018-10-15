using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Annotations.Api
{

    [PSerializable]
    public class CreateSnapshot : OnMethodBoundaryAspect
    {
    }
}
