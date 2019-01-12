using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Data.Repositories.UI
{
    public class UIManagerRepository : RepositoryFactory<object>, IUIRepository
    {

        public UIManagerRepository(DbContext context, ILogger logger) : base(context, logger){ }

        //public IEnumerable<SearchRepository> Run(string keyword, bool IsAuthenticated)
        //{
        //    var searchResults = IsAuthenticated ? PortalDbContext.SearchRepositories
        //                                            .Where(c => c.Meta.Contains(keyword))
        //                                        : PortalDbContext.SearchRepositories
        //                                            .Where(c => c.Meta.Contains(keyword) && c.RequiresAuthentication == false);

        //    foreach (var searchItem in searchResults)
        //    {
        //        yield return searchItem;
        //    }
        //}

        //public async Task<IEnumerable<SearchRepository>> RunAsync(string keyword, bool IsAuthenticated)
        //{
        //    var searchResults = IsAuthenticated ? await PortalDbContext.SearchRepositories
        //                                                    .Where(c => c.Meta.Contains(keyword)).Take(10).ToListAsync()
        //                                        : await PortalDbContext.SearchRepositories
        //                                                    .Where(c => c.Meta.Contains(keyword) && c.RequiresAuthentication == false).Take(20).ToListAsync();

        //    return searchResults;
        //}

        //public SearchRepository MostComparitable(string keyword, bool IsAuthenticated)
        //{
        //    var searchPortal = IsAuthenticated ? PortalDbContext.SearchRepositories
        //                                                .Where(c => c.Meta.Contains(keyword))
        //                                                .Take(1).FirstOrDefault()
        //                                        : PortalDbContext.SearchRepositories
        //                                                .Where(c => c.Meta.Contains(keyword) && c.RequiresAuthentication == false)
        //                                                .Take(1).FirstOrDefault();
        //    return searchPortal;
        //}

        //public async Task<SearchRepository> MostComparitableAsync(string keyword, bool IsAuthenticated)
        //{
        //    var searchResults = IsAuthenticated ? await PortalDbContext.SearchRepositories
        //                                                .Where(c => c.Meta.Contains(keyword))
        //                                                .Take(1).FirstOrDefaultAsync()
        //                                        : await PortalDbContext.SearchRepositories
        //                                                .Where(c => c.Meta.Contains(keyword) && c.RequiresAuthentication == false)
        //                                                .Take(1).FirstOrDefaultAsync();
        //    return searchResults;
        //}

        //public PortalLsm PortalDbContext
        //{
        //    get
        //    {
        //        return this._DbContext as PortalLsm;
        //    }
        //}

    }
}
