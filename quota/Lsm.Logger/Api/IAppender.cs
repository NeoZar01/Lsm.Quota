namespace DoE.Lsm.Logger
{
    using Context;

    /// <summary>
    ///         Signature for derived logging classes.
    /// </summary>
    public interface IAppender
    {

        /// <summary>
        ///       Used for logging  
        /// </summary>
        /// <param name="log"></param>
        void Log(string log);

        /// <summary>
        ///         Used for debugging - Prints the actual code instead of the errors spit by the application.
        /// </summary>
        /// <param name="incident"></param>
        void Debug(string incident);
                
    }
}
