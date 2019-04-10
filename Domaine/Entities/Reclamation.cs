
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reclamation
    {
        [Key]
       public int ID { get; set; }
        public string Descriptions { get; set; }
        public int? IdEvent { get; set; }
        public Evenement Events { get; set; }
        // public DateTime Date { get; set; }
        public int? Idpar { get; set; }

        public Participant Participant { get; set; }

    }
}
