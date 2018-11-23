using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.Component.DocumentsManager.Repositories
{
    using System.Data.Entity;
    using Api;
    using EF;

    public class MirrorRepository : RepositoryFactory<Mirror>, IMirrorRepository
    {
        public MirrorRepository(DbContext context) : base(context)
        {}

        public  async Task<string> MapMirror(string curator, string documentToken, string originalName, string extension, byte[] bytes, string entityType, string interfaceKey)
        {
            return await Task.FromResult("FAILED");
        }
    }
}
