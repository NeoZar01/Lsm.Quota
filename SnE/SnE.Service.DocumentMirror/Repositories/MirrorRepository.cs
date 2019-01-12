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


        public  async Task<string> MapMirror(string curator, string originalName, string extension, byte[] bytes, string entityType, string interfaceKey, string documentToken)
        {

            var rowGuid = Guid.NewGuid();

            var mirror = new Mirror
            {
                CreationDate        = DateTime.Now,
                Curator             = curator,
                DocumentBytes       = bytes,
                DocumentEntityType  = entityType,
                DocumentToken       = documentToken,
                Extension           = extension,
                Interface           = interfaceKey,
                OriginalName        = originalName,
                RowGuid             = rowGuid
            };

            try
            {

                Db.Mirrors.Add(mirror);

                await Db.SaveChangesAsync();

                return documentToken;

            }catch
            {
                throw;
            }

        }


        protected DocumentMirror Db { get { return this._DbContext as DocumentMirror;  } }

    }
}
