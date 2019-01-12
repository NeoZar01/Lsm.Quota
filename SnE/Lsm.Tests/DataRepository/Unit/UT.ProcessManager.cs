using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoE.Lsm.Tests
{
    using Logger;
    using Data.Repositories;
    using Data.Repositories.EF;

    [TestClass]
    public class ProcessManager_Tests
    {

        [DataTestMethod]
        [DataRow("8AB8D0DF-9762-4911-8D18-795B767DD489", "8AB8D0DF-9762-4911-8D18-795B767DD490", "C5596A65-41B8-4E08-B1C9-0DB62E29363B", "INMEMORY" )]
        public void ProcessManagerRepostory_CreateFlowInstance_ShouldBeNull(string flowId, string entityId, string createdby, string state)
        {
            var loggerMock = new Moq.Mock<ILogger>();

            var datarepository = new RepositoryStoreManager(loggerMock.Object.ConfigureWarning);

            var flowInstanceId = string.Empty;// datarepository.WFProcessStore.CreateFlowInstance<Requisition>(flowId, entityId, createdby, state);

            Assert.IsNull(flowInstanceId);

        }

        [DataTestMethod]
        [DataRow("8AB8D0DF-9762-4911-8D18-795B767DD489", "8AB8D0DF-9762-4911-8D18-795B767DD490", "C5596A65-41B8-4E08-B1C9-0DB62E29363B", "INMEMORY")]
        public void WorkflowManagementRepostory_CreateFlowInstanceAsync_ShouldBeNull(string flowId, string entityId, string createdby, string state)
        {
            var loggerMock = new Moq.Mock<ILogger>();

            var datarepository = new RepositoryStoreManager(loggerMock.Object.ConfigureWarning);

            var flowInstanceId = "";// datarepository.WFProcessStore.CreateFlowInstanceAsync<Requisition>(flowId, entityId, createdby, state);

            Assert.IsNull(flowInstanceId);

        }
    }
}
