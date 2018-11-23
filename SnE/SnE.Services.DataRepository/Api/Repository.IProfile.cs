using DoE.Lsm.Data.Repositories;
using DoE.Lsm.Data.Repositories.EF;

namespace DoE.Lsm.Data.Repositories.Profile
{

    public interface IProfileRepository : IRepository<object>
    {

        object GerUserProfileByRankAndStation(string emisCode, short station);

        //IEnumerable<AspNetProfile> GetProfileByMetaData(string keyword);

        //AspNetProfile GetUserProfile(int emisCode);

        //Task<IEnumerable<AspNetProfile>> GetProfileByMetaDataAsync(string keyword);



        //IEnumerable<AspNetProfile> GetProfilesByStation(int rankCode);

        //IEnumerable<AspNetProfile> GetUsersPerPosition(int rankCD, int level);
    }
}
