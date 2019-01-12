using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.Component.DocumentsManager.Repositories
{
    public interface IRepositoryStoreManager
    {

        MirrorRepository MirrorStore
        { get; set; }

    }
}
