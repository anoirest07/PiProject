using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Feedback
    {
        [Key]
        public int IdFB { get; set; }
        public int RateFB { get; set; }
        public string DescFB { get; set; }
        public int EventFK { get; set; }
        public Evenement Events { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantFK { get; set; }
        public Participant Participant { get; set; }


        //id event;
        //id participant
    }
}
