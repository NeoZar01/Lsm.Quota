namespace DoE.Lsm.Logger
{
    using Context;

    /// <summary>
    ///         Signature for derived logging classes.
    /// </summary>
    public interface IOnLog
    {

        /// <summary>
        ///       Used for logging  
        /// </summary>
        /// <param name="log"></param>
        void Log(Incident log);

        /// <summary>
        ///         Used for debugging - Prints the actual code instead of the errors spit by the application.
        /// </summary>
        /// <param name="incident"></param>
        void Debug(Incident incident);
                
    }
}
