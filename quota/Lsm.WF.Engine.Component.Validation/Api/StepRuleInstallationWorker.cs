using DoE.Lsm.Data.Repositories;
using DoE.Lsm.WF.Engine.Service.WorkItem.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    public class StepRuleInstallationWorker : IStepInstanceRule
    {
        protected readonly IRepositoryStoreManager _dataStore;
        protected readonly string _entityType;
        public StepRuleInstallationWorker(string entityType, IRepositoryStoreManager dataStore)
        {
            this._dataStore = dataStore;
            this._entityType = entityType;
        }

        public IStepInstanceRule EscationRules(int[] settings)
        {
            _dataStore.Processes.InstallRules(_entityType, settings);
            return this;
        }
    }
}
