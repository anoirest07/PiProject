using Domain.Entities;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class AchatConfig : EntityTypeConfiguration<Achat>
    {
        public AchatConfig()
        {
            HasRequired<Ticket>(t => t.Tickets).WithMany(t => t.Achats).HasForeignKey(t => t.IdTicket);
            HasRequired<Participant>(t => t.Participants).WithMany(t => t.Achats).HasForeignKey(t => t.IdParticipant);
        }
    }
}
