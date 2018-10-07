using System;
using System.Reflection;

namespace DoE.Lsm.Web.Api
{
    /// <summary>
    ///         This is only used for simplifying debugging versions
    /// </summary>
    public static class ApplicationAssemblyInfo
    {
        /// <summary>
        ///  <value type="string"></value>
        /// </summary>
        public static string Environment { get { return AssemblyInfo<AssemblyEnvironment>(a => a.Value); }}



        /// <summary>
        ///     Gets info an assembly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string AssemblyInfo<T>(Func<T, string> value) where T : Attribute
        {
            T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
            return value.Invoke(attribute);
        }
    }
}