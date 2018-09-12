using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DoE.Models.dp_mdata_dist.Publications
{
    public class When
    {

        //private static When singleton_class_instance;
        //private static Row dtIndicatorIns;
//        private static readonly MasterdataConfig db = new MasterdataConfig();
        //public static IList<Row> tablerows;

//        public async static Task<When> insertAsPivotalStructAsync()
//        {

//            if (singleton_class_instance == null)
//            {
//                           var districtsAll = (from d in db.vwd_SchoolsPerDistrict select d).ToList(); //setup an array of lst_DistrictCD

//                           foreach (var y in districtsAll)
//                           {

//                               List<ft_SchoolsPrDistrictPrSector> dist = await Entity.Migrate.forEachAsync<ft_SchoolsPrDistrictPrSector>(int.Parse(y.EIDistrict));
                          
//                               dtIndicatorIns = new Row(await Entity.Migrate.DistrictAsync(int.Parse(y.EIDistrict))); //initialize my district indicator with default values

////..
//                               for (int i = 0; i < dist.Count(); i++)
//                               {
//                                   if (dist[i].Phase.ToLower().Contains("combined") && dist[i].Sector.ToLower().Contains("independent"))
//                                   {
//                                       dtIndicatorIns.intCombinedInd = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;
//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("combined school") && dist[i].Sector.ToLower().Contains("public"))
//                                   {
//                                       dtIndicatorIns.intCombinedPub = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;

//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("primary school".ToLower()) && dist[i].Sector.ToLower().Contains("independent"))
//                                   {
//                                       dtIndicatorIns.intPrimaryInd = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;

//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("primary school") && dist[i].Sector.ToLower().Contains("public"))
//                                   {
//                                       dtIndicatorIns.intPrimaryPub = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;

//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("secondary") && dist[i].Sector.ToLower().Contains("independent"))
//                                   {
//                                       dtIndicatorIns.intSecondaryInd = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;

//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("secondary") && dist[i].Sector.ToLower().Contains("public"))
//                                   {
//                                       dtIndicatorIns.intSecondaryPub = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;

//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("intermediate") && dist[i].Sector.ToLower().Contains("public"))
//                                   {
//                                       dtIndicatorIns.intIntermediatePub = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;

//                                   }
//                                   else if (dist[i].Phase.ToLower().Contains("intermediate") && dist[i].Sector.ToLower().Contains("independent"))
//                                   {
//                                       dtIndicatorIns.intIntermediateInd = (int)dist[i].Schools;
//                                       dtIndicatorIns.Total = (int)dist[i].Schools;
//                                   }
//                               }

//                               int? bueno = Entity.migrateEachRow<ft_SchoolsPrDistrictPrSector>(dtIndicatorIns,
//                                            Entity.Publications_Indicators.districtsPrPhasePerSector);

//                               if (bueno != null)
//                               {
//                                   tablerows = Entity.lst_districtIndicators;
//                               }
//                           }



//            return singleton_class_instance = new When();
//      }
//            return singleton_class_instance;
    
//    }

        }

    
}