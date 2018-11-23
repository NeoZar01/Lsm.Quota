using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.Component.DocumentsManager.Repositories
{
    using EF;

    public class RepositoryStoreManager : IRepositoryStoreManager
    {

        protected readonly DocumentMirror mirrorDbContext;

        public RepositoryStoreManager()
        {
            mirrorDbContext = new DocumentMirror();
            MirrorStore     = new MirrorRepository(mirrorDbContext);
        }

        public MirrorRepository MirrorStore {get; set;}
    }
}
