using System;

namespace DoE.Lsm.Annotations
{
    ///<summary>
    /// This attribute will just help us to better understand the running of adhoc queries  on fact tables/entities
    ///
    /// <remark>This attribute is only for documentation reasons and intelligence gathering.</remark>
    ///</summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Column : Attribute
    {
        public Column() { }

        public enum Fact {IsRequired}

        ///<summary>
        ///      Quarterly reports   
        ///</summary>
        public Fact DynamicDateRange { get; set; }

        ///<summary>
        ///      Quarterly reports   
        ///</summary>
        public Fact BookYear { get; set; }

        ///<summary>
        ///      Quarter
        ///</summary>
        public Fact Quarter { get; set; }

        ///<summary>
        ///      Year
        ///</summary>
        public Fact Year { get; set; }

        ///<summary>
        ///      Calendar
        ///</summary>
        public Fact Calendar { get; set; }
    }
}