using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
   public class EvenementConfig : EntityTypeConfiguration<Evenement>
    {
        public EvenementConfig()
        {
            // HasMany<Participant>(y => y.EventParticipants).WithMany(o => o.ParticipantEvents).Map(t => t.ToTable("ParticipeEvent"));
            //HasMany<Organizer>(y => y.EventOrganizers).WithMany(o => o.OrganizerEvents).Map(t => t.ToTable("OrganiseEvent"));
            // HasRequired<President>(t => t.EventPresident).WithMany(t => t.PresidentEvents).HasForeignKey(t => t.PresidentFk);
            HasRequired<Team>(t => t.Team).WithMany(t => t.Evenements).HasForeignKey(t => t.TeamFk);
            // HasRequired(t => t.Rapport).WithRequiredPrincipal(t => t.RapportEvenement);
            //HasOne<Rapport>(ad => ad.Student).WithOne(s => s.Address).HasForeignKey<StudentAddress>(ad => ad.StudId);
            //  HasOptional(s => s.Rapport).WithRequired(ad => ad.Evenement);

        }
    }
}
