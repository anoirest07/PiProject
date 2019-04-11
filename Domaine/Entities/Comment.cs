using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set;}
        public string ContenuCom { get; set; }
        public DateTime DateCom { get; set; }

        public string ParticipantName { get; set; }

        public int ParticipantId { get; set; }


        public Participant Participants { get; set; }

       public int PostId { get; set; }


       public Post Posts { get; set; }


    }
}
