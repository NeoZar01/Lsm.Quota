using System.Collections.Generic;
using System.Threading.Tasks;

using DoE.Lsm.Data.Repositories.EF;

namespace DoE.Lsm.Data.Repositories
{
    public interface IUIRepository : IRepository<object>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="IsAuthenticated"></param>
        /// <returns></returns>
       // IEnumerable<SearchRepository> Run(string keyword, bool IsAuthenticated);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="IsAuthenticated"></param>
        /// <returns></returns>
       // Task<IEnumerable<SearchRepository>> RunAsync(string keyword, bool IsAuthenticated);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="IsAuthenticated"></param>
        /// <returns></returns>
      //  SearchRepository MostComparitable(string keyword, bool IsAuthenticated);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="IsAuthenticated"></param>
        /// <returns></returns>
      //  Task<SearchRepository> MostComparitableAsync(string keyword, bool IsAuthenticated);

        /// <summary>
        /// 
        /// </summary>
      //  PortalLsm PortalDbContext { get; }
    }
}
