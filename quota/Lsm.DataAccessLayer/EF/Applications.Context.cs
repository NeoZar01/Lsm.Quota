﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApplicationsNormsStandards : DbContext
    {
        public ApplicationsNormsStandards()
            : base("name=ApplicationsNormsStandards")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<WFProcess> WFProcesses { get; set; }
        public virtual DbSet<WFProcessInstance> WFProcessInstances { get; set; }
        public virtual DbSet<WFProcessInstanceParking_Log> WFProcessInstanceParking_Log { get; set; }
        public virtual DbSet<WFProcessStep> WFProcessSteps { get; set; }
        public virtual DbSet<WFProcessStepInstance> WFProcessStepInstances { get; set; }
        public virtual DbSet<WFPStepOutcomeLookup> WFPStepOutcomeLookups { get; set; }
        public virtual DbSet<C_Error> C_Error { get; set; }
        public virtual DbSet<C_Lock> C_Lock { get; set; }
    }
}
