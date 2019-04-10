using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
   public class FeedbackConfig : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfig()
        {   // One to Many Evenement and Feedbacks

            HasRequired<Evenement>(t => t.Events).WithMany(t => t.Feedbacks).HasForeignKey(t => t.IdEvent);
            // HasRequired<Participant>(t => t.Participant).WithMany(t => t.FeedbacksParticipant).HasForeignKey(t => t.ParticipantFK);


        }
    }
}
