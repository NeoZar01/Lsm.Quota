using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Data.Repositories.Repositories
{
    using EF;
    using DataExtract;
    using Logger;
    using System.Data.Entity;

    public class DataExtractRepository : RepositoryFactory<DataExtract>, IDataExtractRepository
    {

        public void ExtractData<T>(string extractName, string surveyKey, string consortiumGroupName, string entityId, string consortiumMemberId, string data_001, string data_002, string data_003, string data_004, string data_005, string data_006, string data_007, string data_008, string data_009, string data_010) where T : class
        {

        }

        public void ScheduleEntityMigration<T>(string extractId, string surveyId, string consortiumGroupId, string entityType, string entityId, string consortiumMemberId, string schema, string dimension, string key_001, string data_001, string data_002, string data_003, string data_004, string data_005, string data_006, string data_007, string data_008, string data_009, string data_010, out string outcome) where T : class
        {

            var entity = new ExtractSchedulerQueue
            {
                 ConsoriumGroupId       = consortiumGroupId,
                 CreationDate           = DateTime.Now,
                 Dimension              = dimension,
                 DimensionSchema        = schema,
                 EntityType             = entityType,
                 EntityId               = entityId,
                 ExtractId              = extractId,
                 KEY_001                = key_001,
                 LastModifiedDate       = DateTime.Now,
                 MemberId               = consortiumMemberId,
                 Status                 = "PENDING",
                 SurveyId               = surveyId,
                 DATA_001 = data_001,
                 DATA_002 = data_002,
                 DATA_003 = data_003,
                 DATA_004 = data_004,
                 DATA_005 = data_005,
                 DATA_006 = data_006,
                 DATA_007 = data_007,
                 DATA_008 = data_008,
                 DATA_009 = data_009,
                 DATA_010 = data_010
            };

            Db.ExtractSchedulerQueues.Add(entity);

            var task = Db.SaveChanges();

            outcome = (task == 1) ? "PENDING" : "FAILED";                                   
        }

        #region  Implementations
        public DataExtractRepository(DbContext context, ILogger logger) : base(context, logger)
        { }

        public PortalSnE Db { get { return this._DbContext as PortalSnE; } }
        #endregion
    }
}
