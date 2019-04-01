using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class TeamConfig : EntityTypeConfiguration<Team>
    {
        public TeamConfig()
        {
            //  HasMany<Organizer>(y => y.Teams).WithMany(o => o.DocumentsComments).Map(t => t.ToTable("Comment"));
            HasRequired<President>(t => t.President).WithMany(t => t.PresidentTeams).HasForeignKey(t => t.PesidentFK).WillCascadeOnDelete(true);

            //  HasKey(t => new { t.IdTeam, t.President });
            HasMany<Organizer>(y => y.TeamOrganisateurs).WithMany(o => o.OrganisateursTeam).Map(t => t.ToTable("TeamOrganizers"));

            //  HasRequired<Evenement>(t => t.Evenements).WithMany(t => t.PresidentTeams).HasForeignKey(t => t.PesidentFK).WillCascadeOnDelete(true);

        }

    }
}
