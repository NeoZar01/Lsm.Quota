using System;

namespace DoE.Lsm.Logger.Context
{

    public enum Level
    { High, Low }

    /// <summary>
    /// 
    /// </summary>
    public class Error
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
        public string ErrorType
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StackTrace 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LogTime 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AttemptedAction
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Code
        { get; set; }


    }
}
