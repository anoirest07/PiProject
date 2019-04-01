using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
namespace Domain.Entities
{
   public class Team
    {
        [Key]
        public int IdTeam { get; set; }
        /// [Key, Column(Order = 1)]

        public string NomTeam { get; set; }

        //----------------------relation

        public int PesidentFK { get; set; }

        //id president
        // list id organisateur
        //id event

        // public int TeamPresidentFK { get; set; }
        public virtual ICollection<Organizer> TeamOrganisateurs { get; set; }
        //public int TeamEventFK { get; set; }
        //  public Evenement TeamEvent { get; set; }


        public President President { get; set; }
        //   public Organizer TeamOrganisateur { get; set; }



        public ICollection<Evenement> Evenements { get; set; }
    }
}
