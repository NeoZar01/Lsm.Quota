using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Notify.Exception.Objects
{
    public sealed class ExceptionEnvelop
    {

        public int SeverityLevel { get; set; }

        public object Entity { get; set; }
        public object EntityKey { get; set; }

        public string Error { get; set; }
        public string Exception { get; set; }
        public string Solution { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
