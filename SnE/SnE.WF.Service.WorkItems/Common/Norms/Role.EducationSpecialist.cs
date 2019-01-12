using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoE.Lsm.Data.Repositories;
using DoE.Lsm.Logger;

namespace DoE.Lsm.WF.WI.Context.Norms
{
    public class EducationSpecialist : Role
    {
        public EducationSpecialist(ILogger logger, IRepositoryStoreManager repositoryStore) : base(logger, repositoryStore) {}
    }
}
