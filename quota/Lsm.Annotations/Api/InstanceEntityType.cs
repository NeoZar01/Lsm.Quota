using System;

namespace DoE.Lsm.Annotations
{
    /// <summary>
    ///     This attribute will only be used for documentation to alert the developer about the available entity options.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class InstanceEntityType : Attribute
    {    
        public InstanceEntityType(string options){}

        /// <summary>
        /// 
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        { get; set; }
    }
}