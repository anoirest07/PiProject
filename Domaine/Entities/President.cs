using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class President : User
    {
        ICollection<Tache> Taches { get; set; }
        public ICollection<Team> PresidentTeams { get; set; }
        // public ICollection<Evenement> PresidentEvents { get; set; }
    }
}
