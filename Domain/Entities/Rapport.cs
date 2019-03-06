using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Rapport
    {
        public int IdRapport;
        public String Contenu ;
        //id feedback 
        //id evenement
        [DataType(DataType.ImageUrl)]
        public String ImageRapport;
    }
}
