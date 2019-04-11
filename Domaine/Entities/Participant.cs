using Domain.Entities;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Participant : User
    {
        public virtual ICollection<Feedback> FeedbacksParticipant { get; set; }
        //  public  ICollection<Evenement> ParticipantEvents { get; set; }
       // public virtual ICollection<Ticket> AchatParticipant { get; set; }
        public virtual ICollection<Recomendation> Recomendations { get; set; }
        public virtual ICollection<Reclamation> ReclamationParticipant { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Achat> Achats { get; set; }
        public virtual ICollection<Likes> Likess { get; set; }
    }
}
