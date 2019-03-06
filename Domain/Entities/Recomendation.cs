using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Recomendation
    {
        public int IdRecom;
        // id particpant
        //id evenment
        public String MailRecomd;
        public enum EtatRecom { valide, notvalide,inprogress }
    }
}
