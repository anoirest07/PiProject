using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
   public class Rapport
    {
        [Key]
        public int IdRapport { get; set; }
        public string Contenu { get; set; }
        //id feedback 
        //id evenement
        [DataType(DataType.ImageUrl)]
        public string ImageRapport { get; set; }


    }
}
