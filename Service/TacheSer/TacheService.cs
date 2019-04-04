using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TacheSer
{
    public class TacheService : Service<Tache>, ITacheService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public TacheService() : base(unit)
        {

        }
        public bool DeleteTache(int IdTache)
        {
            bool result = false;
            Tache tache = Get(x => x.IdTache == IdTache && x.IsDeleted == false);

            if (tache != null)
            {
                tache.IsDeleted = true;
                result = true;
                Update(tache);
                Commit();
            }
            return result;
        }
    }
}
