namespace DoE.Lsm.Logger
{
    using Context;

    ///<summary>
    ///     This interface will be a signature for the logging pattern. 
    ///    
    ///     <remark>The logger uses the observer pattern to register a list of listerners who will be notified if an error is thrown</remark> 
    ///     <see cref="https://www.dofactory.com/net/observer-design-pattern">For more info about using observer pattern</see>
    ///	   <see> log4net for a much clearner and faster way to log and run debug</see>
    ///</summary>
    public interface ILogger
    {

       ///<summary>
       ///  Error Thread    
       ///</summary>
        Incident Exception  {set;}

        ///<summary>
        ///  Minor Error log 
        ///</summary>
        ILogger Minor  {get;}

        ///<summary>
        ///  Critical Error log 
        ///</summary>
        ILogger Critical  {get;}

        ///<summary>
        ///  Register a new listerner
        ///</summary>
        void Register(IOnLog observer);

        ///<summary>
        ///  Revoke a registered listener
        ///</summary>
        void UnRegister(IOnLog observer);

        ///<summary>
        ///  Broadcasts a error thread to all listerners.
        ///</summary>
        void NotifyAll(Incident exceptionEnv);
    }
}