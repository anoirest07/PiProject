using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
           // HasRequired<Participant>(t => t.Participants).WithMany(t => t.Posts).HasForeignKey(t => t.ParticipantId);
        }
    }
}
