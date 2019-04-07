using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketSer
{
   public interface ITicketService : IService<Ticket>
    {
    }
}
