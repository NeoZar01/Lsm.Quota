using System;

namespace DoE.Lsm.Annotations
{

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Interface : Attribute
    {
        public Interface() {}

        public string Key { get; set; }

        public string Name { get; set; }

    }
}
