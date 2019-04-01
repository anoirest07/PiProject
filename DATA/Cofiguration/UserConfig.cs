
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class UserConfig : EntityTypeConfiguration<User>
    {

        public UserConfig()
        {
            Map<President>(c =>
            {
                c.Requires("Role").HasValue("President"); //Type is the descriminator
            });
            Map<Organizer>(c =>
            {
                c.Requires("Role").HasValue("Organizer");
            });
            Map<Participant>(c =>
            {
                c.Requires("Role").HasValue("Participant"); //Type is the descriminator
            });

        }
    }
}
