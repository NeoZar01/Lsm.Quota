namespace DoE.Lsm.Data.Repositories.DataExtract
{
    using EF;
    using Data.Repositories;

    public interface IDataExtractRepository : IRepository<DataExtract>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="extractId"></param>
        /// <param name="surveyId"></param>
        /// <param name="consortiumGroupId"></param>
        /// <param name="entityId"></param>
        /// <param name="consortiumMemberId"></param>
        /// <param name="dimension"></param>
        /// <param name="data_001"></param>
        /// <param name="data_002"></param>
        /// <param name="data_003"></param>
        /// <param name="data_004"></param>
        /// <param name="data_005"></param>
        /// <param name="data_006"></param>
        /// <param name="data_007"></param>
        /// <param name="data_008"></param>
        /// <param name="data_009"></param>
        /// <param name="data_010"></param>
        void ScheduleEntityMigration<T>(string extractId, string surveyId, string consortiumGroupId, string entityType, string entityId, string consortiumMemberId, string schema,  string dimension , string key_001, string data_001, string data_002, string data_003, string data_004, string data_005, string data_006, string data_007, string data_008, string data_009, string data_010, out string outcome) where T : class;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="extractName"></param>
        /// <param name="surveyKey"></param>
        /// <param name="consortiumGroupName"></param>
        /// <param name="entityId"></param>
        /// <param name="consortiumMemberId"></param>
        /// <param name="data_001"></param>
        /// <param name="data_002"></param>
        /// <param name="data_003"></param>
        /// <param name="data_004"></param>
        /// <param name="data_005"></param>
        /// <param name="data_006"></param>
        /// <param name="data_007"></param>
        /// <param name="data_008"></param>
        /// <param name="data_009"></param>
        /// <param name="data_010"></param>
        void ExtractData<T>(string extractName, string surveyKey, string consortiumGroupName, string entityId, string consortiumMemberId, string data_001, string data_002, string data_003, string data_004, string data_005, string data_006, string data_007, string data_008, string data_009, string data_010) where T : class;

    }

}
