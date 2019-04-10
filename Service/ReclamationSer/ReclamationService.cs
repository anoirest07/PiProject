using data.Infrastructure;
using Domain.Entities;
using Domaine.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
     public class ReclamationService : Service<Reclamation>, IReclamationService
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public ReclamationService() : base(uow)
        {
        }
        
    }
}
