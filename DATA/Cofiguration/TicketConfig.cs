using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
   public class TicketConfig :EntityTypeConfiguration<Ticket>
    {
        public TicketConfig()
        {
          //  HasMany<Participant>(y => y.ParticipantAchat).WithMany(o => o.AchatParticipant).Map(t => t.ToTable("Achat"));
            HasRequired<Evenement>(t => t.Evenement).WithMany(t => t.Tickets).HasForeignKey(t => t.IdEvent);

        }
    }
}
