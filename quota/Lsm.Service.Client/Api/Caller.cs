using System;

namespace DoE.Lsm.Services.Api
{
    using Data.Repositories;
    using Logger;
    /// <summary>
    /// 
    /// </summary>
    public class Caller : IServicesFactory
    {

        /// <summary>
        ///         constructor
        /// </summary>
        /// <param name="logger"></param>
        public Caller(ILogger logger)
        {

            //newup the EventLogger from the container
            Logger       = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        public ILogger Logger
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RepositoryStoreManager RepositoryStoreService
        { get; set; }

    }

}
