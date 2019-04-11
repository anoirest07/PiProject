using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class TeamViewModel
    {
        [Key]
        public int IdTeam { get; set; }
        public string NomTeam { get; set; }
        public int PesidentFK { get; set; }
        public virtual ICollection<OrganizerModelView> TeamOrganisateurs { get; set; }
      //  public PresidentViewModel President { get; set; }
        public ICollection<EvenementViewModel> Evenements { get; set; }
    }
}