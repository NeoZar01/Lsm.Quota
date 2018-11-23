using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Annotations.Api.Exceptions
{
    [Serializable]
    public class UIException : Exception
    {
        public UIException() {}

        public UIException(string userErrorMessage) :base(userErrorMessage) {}
    }
}
