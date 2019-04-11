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
    public class LikesConfig : EntityTypeConfiguration<Likes>
    {
        public LikesConfig()
        {
            HasRequired<Post>(t => t.Posts).WithMany(t => t.Likess).HasForeignKey(t => t.IdPost);
            HasRequired<Participant>(t => t.Participants).WithMany(t => t.Likess).HasForeignKey(t => t.IdParticipant);
        }

    }

}


