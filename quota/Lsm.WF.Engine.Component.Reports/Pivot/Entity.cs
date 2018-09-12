using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace DoE.Models.dp_mdata_dist.Publications
{
    public class Entity
    {

        public enum Publications_Indicators
        {
                    districtsPrPhasePerSector = 0
        }

        public static IList<Row> lst_districtIndicators = new List<Row>();

        //private static int totalNmOfSchools;
        //private static int totalNmOfPubPrimSchools;

        public static int? migrateEachRow<T>( Row rw, Publications_Indicators i )
        {
            switch (i)
            {
                case Publications_Indicators.districtsPrPhasePerSector:
                        return Plug(rw).Count();
                default:
                       return -1;
            }
        }

        private static IList<Row> Plug(Row rw)
        {
                 lst_districtIndicators.Add(rw); 
                 return lst_districtIndicators;
        }


        //public class  Migrate
        //{

        //    private static readonly MasterdataConfig db = new MasterdataConfig();

        //    public async static Task<List<ft_SchoolsPrDistrictPrSector>> forEachAsync<T>(int IdxFilter ){
        //        var mt = (from m in db.ft_SchoolsPrDistrictPrSector where m.EIDistrict == IdxFilter select m).ToListAsync();
        //                    return await mt;
        //}

            //public async static Task<ft_SchoolsPrDistrictPrSector> DistrictAsync(int IdxFilter)
            //{
            //    var mt = await (from m in db.ft_SchoolsPrDistrictPrSector where m.EIDistrict == IdxFilter select m).FirstOrDefaultAsync();
            //    return mt;
            //}
            
        //}
    }
}