//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoE.Lsm.Data.Repositories.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class WIProcess
    {
        public int id { get; set; }
        public System.Guid InstanceId { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntityType { get; set; }
        public string ParentProcessId { get; set; }
    }
}
