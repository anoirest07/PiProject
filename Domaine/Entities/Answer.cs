using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
    public class Answer
    {
        public int AnswerID {get ; set;}
        public string Name { get; set; }
        public string Css { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
