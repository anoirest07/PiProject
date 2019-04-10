using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EvenementService:Service<Evenement>, IEvenementService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public EvenementService() : base(unit)
        {

        }
        public IEnumerable<Evenement> get_nbplace_dispo()             

        {
            return unit.getRepository<Evenement>().GetAll().OrderByDescending(p => p.NbPlaceEvent).Take(4).ToList();
        }
    }
}
