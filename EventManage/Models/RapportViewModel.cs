using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class RapportViewModel
    {
        [Key]
        public int IdRapport { get; set; }
        public string Contenu { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageRapport { get; set; }
    }
}