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
    public enum NomTache { create, edit, deleteop }
    public class Tache
    {
        public int IdTache { get; set; }
        public NomTache Nom { get; set; }
        public string DescTache { get; set; }
        public DateTime DeadlineTache { get; set; }
        public EtatTache EtatdeTache { get; set; }

        //relation

        public int OragnisateurFk { get; set; }
        public Organizer Organisateur { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        //id team
        //id president
        //id organisateur
    }
}
