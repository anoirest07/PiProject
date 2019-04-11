using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public enum EtatRecom { valide, notvalide, inprogress }

    public class RecommendationViewModel
    {

        public int ID { get; set; }
      
        public String EmailParticipent { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public EtatRecom EtaRec { get; set; }
        public int IdEvent { get; set; }
        public virtual Evenement Event { get; set; }
       
       public int IdParticipant { get; set; }
        public virtual Participant Participant { get; set; }
        
       
    }
}