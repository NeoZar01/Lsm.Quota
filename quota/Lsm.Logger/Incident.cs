using System;

namespace DoE.Lsm.Logger.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class Incident
    {
        /// <summary>
        /// 
        /// </summary>
        public string InstanceId
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Entity
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StackTrace 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Source 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Solution 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LogTime 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Level
        { get; set; }


    }
}
