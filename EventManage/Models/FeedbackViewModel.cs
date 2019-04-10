using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class FeedbackViewModel
    {
        [Key]
        public int IdFB { get; set; }
        public int RateFB { get; set; }
        public string DescFB { get; set; }
        public int EventFK { get; set; }
        public EvenementViewModel Events { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantFK { get; set; }
       // public ParticipantViewModel Participant { get; set; }
    }
}