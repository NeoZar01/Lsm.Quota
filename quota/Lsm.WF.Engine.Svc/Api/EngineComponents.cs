using System;
using System.Runtime.InteropServices;

namespace DoE.Lsm.WF.Engine.Api
{
    //
    // Summary:
    // Specifies dependant workflow components
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public class EngineComponents : Attribute
    {

        private string _components;

        public EngineComponents(string components)
        {
            this._components = components;
        }

        public string[] Routes { get { return _components.Split(',');  } }

    }
}
