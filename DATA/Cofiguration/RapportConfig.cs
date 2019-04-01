using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Cofiguration
{
    public class RapportConfig : EntityTypeConfiguration<Rapport>
    {
        public RapportConfig()
        {
            //  HasRequired(e => e.Evenement).WithRequiredPrincipal(e => e.Rapport);

        }
    }
}
