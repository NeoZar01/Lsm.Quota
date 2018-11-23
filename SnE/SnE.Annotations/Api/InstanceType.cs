using System;

namespace DoE.Lsm.Annotations
{
    /// <summary>
    ///     This attribute will only be used for documentation to alert the developer about the available entity options.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class InstanceType : Attribute
    {    
        public InstanceType(params string[] entities){}
    }
}