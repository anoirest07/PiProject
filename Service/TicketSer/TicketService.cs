using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketSer
{
   public class TicketService : Service<Ticket>, ITicketService
    {

        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public TicketService() : base(uow)
        {

        }
        //public int FindidTicket(int id)
        //{

        //    // return this.GetById(e. == id);
        //    return this.GetMany().Where(e=>e.IdEvent==id);
        //}
            
            




        }
       
}

