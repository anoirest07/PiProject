using Domain.Entities;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Models
{
    public class FeedbackViewModels
    {
        public int IdFB { get; set; }
        public string Answer { get; set; }
        public string DescFB { get; set; }
        public int? IdEvent { get; set; }
        public Evenement Events { get; set; }
        public string Reclamation { get; set; }

        public DateTime Date { get; set; }
        public int? Id { get; set; }
        public virtual ICollection<Evenement> Evenements { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
     

    }
}