using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public enum EtatRecom { valide, notvalide, inprogress }

    public class Recomendation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int ID { get; set; }

        public String EmailParticipent { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public EtatRecom EtaRec { get; set; }
        public int? IdEvent { get; set; }
        public virtual Evenement Event { get; set; }

        public int IdParticipant { get; set; }
        public virtual Participant Participant { get; set; }

    }
}
