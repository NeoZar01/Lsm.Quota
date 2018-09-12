using System;
using System.Runtime.InteropServices;

namespace DoE.Lsm.Web.Api
{
    //
    // Summary:
    // Specifies dependant workflow components
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public class AssemblyEnvironment : Attribute
    {
        private string _environment;

        public AssemblyEnvironment(string environment)
        {
            this._environment = environment;
        }

        public string Value { get { return _environment; } }
    }
}