using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Organizer : User
    {
        ICollection<Tache> Taches { get; set; }
        public ICollection<Team> OrganisateursTeam { get; set; }
        public ICollection<Tache> TachesAFaire { get; set; }
        // public ICollection<Evenement> OrganizerEvents { get; set; }

        //public int TeamFK { get; set; }
        // public Team Teams { get; set; }
    }
}
