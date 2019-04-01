using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class RecomendationConfig : EntityTypeConfiguration<Recomendation>
    { 

        public RecomendationConfig()
        {
            HasRequired<Evenement>(t => t.Events).WithMany(t => t.Recomendations).HasForeignKey(t => t.EventId);
            HasRequired<Participant>(t => t.Participants).WithMany(t => t.Recomendations).HasForeignKey(t => t.ParticipantId);
            HasKey(t => new { t.IdRecom, t.EventId,t.ParticipantId });
        }
    }
}
