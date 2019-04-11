using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain.Entities
{
    public enum EtatTache { done, undone, inprogress }
    public enum NomTache
    {
        [Display(Name = "Create the participant Fom")]
        createfrom,
        [Display(Name = "Create the ticketing system")]
        createtickiting,
        [Display(Name = "Configure the referal process")]
        configureprocess,
        [Display(Name = "Prepare and send the satisfaction survey")]
        satisfaction

    }
    public class Tache
    {

        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTache { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public NomTache Nom { get; set; }
        public string DescTache { get; set; }
        [Required]
        public DateTime DeadlineTache { get; set; }
        [Required]
        public EtatTache EtatdeTache { get; set; }

        //relation
        [Required]
        public int OragnisateurFk { get; set; }
        public Organizer Organisateur { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string OrgNom { get; set; }


        //id team
        //id president
        //id organisateur
    }
}
