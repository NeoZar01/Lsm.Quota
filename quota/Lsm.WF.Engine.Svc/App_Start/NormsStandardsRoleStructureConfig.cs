using System;

namespace DoE.Lsm.WF.Engines.Configurations
{
    using Engine.Context.Entities;
    using Data.Repositories;

    ///<summary>
    /// This can cause overheads when is loaded on every request.It should be loaded during start-up.(Currently its loaded by the Dependancy Injection container).
    ///<remark>This increases start-up time.</remark>
    ///</summary>
    public class NormsStandardsRoleStructure : IDisposable
    {

        /// <summary>
        ///     Return this as a singleton
        /// </summary>
        private static volatile NormsStandardsRoleStructure   instance;

        /// <summary>
        ///     Role for Circuit Manager
        /// </summary>
        public CircuitManager CircuitManager { get; set; }

        /// <summary>
        ///     Role for school
        /// </summary>
        public School School { get; set; }

        /// <summary>
        ///     Role for Subject Analyst
        /// </summary>
        public SubjectAnalyst SubjectAnalyst { get; set; }

        #warning Deprecated Code
        public Tickets Tickets { get; set; }

        ///<summary>
        ///     This will be thrown back to the caller as an instance.
        /// </summary>
        public NormsStandardsRoleStructure Roles(IRepositoryStore dataStore)
        {
            if (instance != null) return instance;            

            lock (_syncLock)
            {
                CircuitManager      = new CircuitManager(dataStore);
                SubjectAnalyst      = new SubjectAnalyst(dataStore);
                School              = new School(dataStore);
                Tickets             = new Tickets(dataStore);

                // We should figure out a dynamic way for one role to have multiple report structures.
                ReportsTo<School, SubjectAnalyst>(School, SubjectAnalyst);                 //Configures school to only report to the subject advisor
                
                ReportsTo<SubjectAnalyst, CircuitManager>(SubjectAnalyst, CircuitManager); //Configures subject advisor to report to the CircuitManager

                return instance;
            }
        }

        /// <summary> Sets <c> successor</c> as the Manager for <c>precessor<c>
        /// <para>  <see  cref="Role.SetSuccessor(Role successor)" />  /</para>
        /// </summary>
        private void ReportsTo<T,  T1>(Role precessor,Role successor)
        {
                            precessor.SetSuccessor(successor);
        }


        #region  doCleanup

        private bool _disposed = false;
        private static readonly object _syncLock = new object();

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }


        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                instance   = null;
                _disposed  = true;
            }
        }
        #endregion

    }
}