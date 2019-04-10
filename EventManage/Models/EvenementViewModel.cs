
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public enum Methodepaiement { Online, BoxOffice }
    public enum EtatEvent { Valide, NonValide }
    public enum Categorie { Academic, Entertaining, Cultural, Other }
    public class EvenementViewModel
    {
        [Key]
        public int IdEvent { get; set; }
        public string NomEvent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateEventDebut { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateEventFin { get; set; }
        public string LocationEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public int NbPlaceEvent { get; set; }
        [DataType(DataType.ImageUrl), Required(ErrorMessage = "la proprieté image est obligatoire")]
        public string ImageEvent { get; set; }
        public string Welcometext { get; set; }
        public Methodepaiement Methodepai { get; set; }
        public Categorie Category { get; set; }
        public EtatEvent EtatEvenement { get; set; }

        public ICollection<FeedbackViewModel> Feedbacks { get; set; }
        public int TeamFk { get; set; }
        public TeamViewModel Team { get; set; }
        public RapportViewModel Rapport { get; set; }
       // public virtual ICollection<RecomendationViewModel> Recomendations { get; set; }


    }
}