using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domaine.Entities;

namespace Domain.Entities
{
   public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        public float Prix { get; set; }
        //id participant
        //id evenement
        public Evenement Evenement { get; set; }
        public int IdEvent { get; set; }
       // public virtual ICollection<Participant> ParticipantAchat { get; set; }
        public virtual ICollection<Achat> Achats { get; set; }
    }
}
