using System;

namespace DoE.Lsm.Annotations
{

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class FlowProcess : Attribute
    {

        public FlowProcess() {}
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

    }
}
