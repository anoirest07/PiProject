using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public enum EtatRecom { valide, notvalide, inprogress }
    
   public class Recomendation
    {
       
        public int IdRecom { get; set; }

       
        public int EventId { get; set; }


   
        public int ParticipantId { get; set; }
        

        public Evenement Events { get; set; }
        public Participant Participants { get; set; }
        public string MailRecomd { get; set; }
        public EtatRecom EtaRec { get; set; }
    }
}
