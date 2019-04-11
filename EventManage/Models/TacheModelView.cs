using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManage.Models
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
    public class TacheModelView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTache { get; set; }

        [Required]
        public NomTache Nom { get; set; }
        public string DescTache { get; set; }
        [Required]
        public DateTime DeadlineTache { get; set; }
        [Required]
        public EtatTache EtatdeTache { get; set; }

        //relation
        [Required]
        public int OragnisateurFk { get; set; }
        public OrganizerModelView Organisateur { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string OrgNom { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}