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
    public class ReclamationConfig : EntityTypeConfiguration<Reclamation>
    {
        public ReclamationConfig()
        {
            HasRequired<Evenement>(t => t.Events).WithMany(t => t.Reclamations).HasForeignKey(t => t.IdEvent);
            HasRequired<Participant>(t => t.Participant).WithMany(t => t.ReclamationParticipant).HasForeignKey(t => t.Idpar);
        }
    }
}
