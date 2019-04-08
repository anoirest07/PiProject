using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
   public class Achat
    {
        [Key]
        public int IdAchat { get; set; }

        public int Quantites { get; set; }

        public int IdTicket { get; set; }
        public Ticket Tickets { get; set; }
        public int IdParticipant { get; set; }
        public Participant Participants { get; set; }

    }
}
