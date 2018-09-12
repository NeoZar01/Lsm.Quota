using System.Data.Entity;
using System.Linq;

namespace DoE.Lsm.Data.Repositories.Profile
{
    using EF;
    using Logger;
    using Repositories;
    using Annotations.Exceptions;

    public class ProfileRepository : Repository<AspNetProfile>, IProfileRepository
    {

        public ProfileRepository(DbContext WhoIsWhoDbContext, ILogger logger) : base(WhoIsWhoDbContext, logger){}

        public AspNetProfile GerUserProfileByRankAndStation(int emisCode, short station)
        {
            var user = WioDbContext.AspNetProfiles.Where(c => c.Role == emisCode && c.PositionCode == station).SingleOrDefault();

            if (user != null)
            {
                return user;
            }

            // throw new InstanceNotFoundException("Location Was Not thrown from a try-catch block", "Unable To Find User Message ", "Ensure that user was registered.", WioDbContext.AspNetProfiles, emisCode, true, Severity.High.No);
            throw new InvalidDatabaseOperationException("Unable To Find User Message.");
        }


        //public IEnumerable<AspNetProfile> GetProfileByMetaData( string keyword)
        //{
        //    var profileResultSet = (from y in WioDbContext.AspNetProfiles
        //                            let k = WioDbContext.AspNetProfiles.Where(c => c.meta.Contains(keyword)).Select(c => c.DepartID)
        //                            where k.Contains(y.DepartID)
        //                            select y)
        //                            .OrderBy(c => c.RefName)
        //                            .OrderBy(c => c.Phase_DoE);

        //    return profileResultSet as IEnumerable<AspNetProfile>;
        //}

        //public async Task<IEnumerable<AspNetProfile>> GetProfileByMetaDataAsync(string keyword)
        //{
        //    var profileResultSet = (from y in WioDbContext.AspNetProfiles
        //                            let k = WioDbContext.AspNetProfiles.Where(c => c.meta.Contains(keyword)).Select(c => c.DepartID)
        //                            where k.Contains(y.DepartID)
        //                            select y)
        //                            .OrderBy(c => c.RefName)
        //                            .OrderBy(c => c.Phase_DoE);
        //    return await profileResultSet.ToListAsync();
        //}



        //public AspNetProfile GetUserProfile(int emisCode)
        //{
        //    try
        //    {
        //        return WioDbContext.AspNetProfiles.Where(c => c.DepartID == emisCode).SingleOrDefault();
        //    }
        //    catch(Exception e)
        //    {
        //        throw new EntityNotFoundException( e.InnerException.ToString(), "Unable To Find User Message ", "Ensure that user was registered.", WioDbContext.AspNetProfiles, emisCode, true , Severity.High.No);
        //    }
        //}

        //public IEnumerable<AspNetProfile> GetProfilesByStation(int rankCode)
        //{
        //    var PBRankCodeQuery = WioDbContext.AspNetProfiles
        //             .Where(c => c.ConfLev == true && c.rankCode == rankCode);

        //    foreach(var user in PBRankCodeQuery)
        //    {
        //        yield return user;
        //    }
        //}


        //public IEnumerable<AspNetProfile> GetUsersPerPosition(int rankCD, int level)
        //{
        //    var PPPositionQuery = WioDbContext.AspNetProfiles
        //                                        .Where(c => c.Level == level && c.rankCode == rankCD);

        //    foreach(var user in PPPositionQuery)
        //    {
        //        yield return user;
        //    }           
        //}


        public PortalAuth WioDbContext { get { return this._DbContext as PortalAuth;  } }
    }
}
