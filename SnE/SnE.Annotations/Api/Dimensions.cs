using System;

namespace DoE.Lsm.Annotations
{
    [Flags]
    public enum  Flavours {
        Fact                = 0x01,
        DynamicDateRange    = 0x02,
        BookYear            = 0x03,
        Quarter             = 0x04,
        Year                = 0x05,
        Calendar            = 0x06,

    }

    ///<summary>
    /// This attribute will just help us to better understand the running of adhoc queries  on fact tables/entities
    ///
    /// <remark>This attribute is only for documentation reasons and intelligence gathering.</remark>
    ///</summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Dimensions : Attribute
    {
        public Dimensions(Flavours dimensionOptions) { }        
    }
}