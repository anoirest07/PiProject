using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
  public  class CommentConfig : EntityTypeConfiguration<Comment>
    {
      public  CommentConfig()
        {
            HasRequired<Post>(t => t.Posts).WithMany(t => t.Comments).HasForeignKey(t => t.PostId);
            HasRequired<Participant>(t => t.Participants).WithMany(t => t.Comments).HasForeignKey(t => t.ParticipantId);
        }

    }
}
