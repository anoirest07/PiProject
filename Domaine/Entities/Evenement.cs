using Domain.Entities;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Methodepaiement { Online, BoxOffice }
    public enum EtatEvent { Valide, NonValide }
    public class Evenement
    {
        [Key]
       
        public int IdEvent { get; set; }
        public string NomEvent { get; set; }
        public DateTime DateEventDebut { get; set; }
        public DateTime DateEventFin { get; set; }
        public string LocationEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public int NbPlaceEvent { get; set; }
        [DataType(DataType.ImageUrl), Required(ErrorMessage = "la proprieté image est obligatoire")]
        public string ImageEvent { get; set; }
        public string Welcometext { get; set; }
        public Methodepaiement Methodepai { get; set; }
        public EtatEvent EtatEvenement { get; set; }
        public virtual ICollection<Reclamation> Reclamations { get; set; }

        //relation
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public int TeamFk { get; set; }
        public Team Team { get; set; }
        public  Rapport Rapport { get; set; }
       public virtual ICollection<Recomendation> Recomendations { get; set; }
        //public virtual ICollection<Participant> EventParticipants { get; set; }
        //public President EventPresident { get; set; }
        //public int PresidentFk { get; set; }
    }
}
