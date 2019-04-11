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
   public class RewardConfig : EntityTypeConfiguration<Reward>
    {
        public RewardConfig() { 


        HasRequired<Evenement>(t => t.Event).WithMany(t => t.Rewards).HasForeignKey(t => t.EventId);
        HasRequired<Organizer>(t => t.Organizer).WithMany(t => t.ListReward).HasForeignKey(t => t.UserId);
       }

    }
}
