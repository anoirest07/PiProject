using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class TacheConfig : EntityTypeConfiguration<Tache>
    {

        public TacheConfig()
        {
            HasRequired<Organizer>(t => t.Organisateur).WithMany(t => t.TachesAFaire).HasForeignKey(t => t.OragnisateurFk);
            HasKey(t => new { t.IdTache, t.Nom });
        }

    }
}
