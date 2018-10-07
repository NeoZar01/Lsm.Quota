using System;
using System.Runtime.InteropServices;

namespace DoE.Lsm
{
    //
    // Summary:
    // Specifies dependant workflow components
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public class ServiceComponent : Attribute
    {

        private string[] components;

        public ServiceComponent(params string[] services)
        {
            components = new string[services.Length];

            for (int s = 0; s < services.Length; s++)
            {
                if (s % 2 != 0)
                {
                    if (string.IsNullOrEmpty(components[((s == 0) ? 0 : (s - 1))]))
                    {
                        components[s - 1] = services[s];
                    }
                    else
                    {
                        components[s] = services[s];
                    }
                }
                continue;
            }

        }

        public string Requisitions
        {
            get
            {  int index = 0;
               return (string.IsNullOrEmpty(components[index]) ? components[index + 1] : components[index]);
            }
        }
    }
}
