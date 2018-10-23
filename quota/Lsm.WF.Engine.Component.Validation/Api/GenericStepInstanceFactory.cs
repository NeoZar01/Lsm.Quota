using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.WI.Tools
{
    using Annotations.Exceptions;
    using Context;
    using Data.Repositories;

    public abstract class GenericStepInstanceFactory : ProcessStepsFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public string preceedingStepId = "";

        /// <summary>
        /// 
        /// </summary>
        public string preceedingStepInstanceId = "";

        /// <summary>
        /// 
        /// </summary>
        public string currentStepInstanceId = "";


        /// <summary>
        ///     This method should does the following
        ///     * Get the current step which the item is residing....
       ///      * Prepares the preceeding step - <c>initialise preceedingStepId</c> with the thrown Id and returns the ProcessStepFactory
        /// </summary>
        /// <param name="instanceCaseId"></param>
        /// <param name="dataStoreManager"></param>
        /// <param name="depndObject_0001"></param>
        /// <returns></returns>
        public override ProcessStepsFactory PreConfig(string instanceCaseId, IRepositoryStoreManager dataStoreManager, params object[] dp_objects)
        {

            if (string.IsNullOrEmpty(instanceCaseId)) throw new ArgumentNullException(nameof(instanceCaseId));
            if (dataStoreManager == null) throw new ArgumentNullException(nameof(dataStoreManager));

                dataStoreManager.WI.ProcessInstanceParkingStep(instanceCaseId, out preceedingStepId, out preceedingStepInstanceId);

            if(preceedingStepId.Equals("") || preceedingStepInstanceId.Equals(""))
            {
                throw new FailedTransactionException("Failed to initialise dependancies for the preceeding step");
            }
            return this;
        }

        /// <summary>
        ///     Creates a snapshot of the payload
        /// </summary>
        /// <returns></returns>        
        public override ProcessStepsFactory Start(ProcessWorkItem payload, IRepositoryStoreManager dataStoreManager)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            if (dataStoreManager == null) throw new ArgumentNullException(nameof(dataStoreManager));

            dataStoreManager.WI.CreateInstanceSnapShot<ProcessWorkItem>(payload, currentStepInstanceId, preceedingStepId, preceedingStepInstanceId, payload.IdentityToken, payload.ProcessInstanceId, payload.InstanceEntityType,
                                    payload.param_001, payload.param_002, payload.param_003, payload.param_004, payload.param_005, payload.param_006, payload.param_007, payload.param_008, payload.param_009, payload.param_0010);
            return this;
        }


        public override ProcessStepsFactory Instantiate()
        {
            return this;
        }

        public override ProcessStepsFactory Process(ProcessWorkItem payload)
        {
            return this;
        }

        public override Task<ProcessStepsFactory> End()
        {
            return null;
        }
    }
}
