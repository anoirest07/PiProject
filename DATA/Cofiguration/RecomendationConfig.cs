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
            HasRequired<Evenement>(t => t.Event).WithMany(t => t.Recomendations).HasForeignKey(t => t.IdEvent);
            HasRequired<Participant>(t => t.Participant).WithMany(t => t.Recomendations).HasForeignKey(t => t.IdParticipant);
        }
    }
}
