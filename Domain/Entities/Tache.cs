using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Tache
    {
        public int IdTache;
        public String Nom;
        public String DescTache;
        public DateTime DeadlineTache;
        public enum EtatTache { done,undone,inprogress}
        //id team
        //id president
        //id organisateur

    }
}
