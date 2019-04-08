using data.Infrastructure;
using Domaine.Entities;
using Service.TicketSer;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AchatSer
{
   public class AchatService : Service<Achat>, IAchatService
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public AchatService() : base(uow)
        {

        }
    }

}
