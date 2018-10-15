using log4net;

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
        string Report  {set;}

        ///<summary>
        ///  Minor Error log 
        ///</summary>
        ILogger InitiateWarningInstace  {get;}

        ///<summary>
        ///  Critical Error log 
        ///</summary>
        ILogger InitiateAlertInstance  {get;}

    }
}