using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class LikesViewModel
    {
        [Key]
        public int IdLike { get; set; }
        public int IdParticipant { get; set; }
        public int IdPost { get; set; }
        public DateTime LikedDate { get; set; }
     
        public Participant Participants { get; set; }
        public Post Posts { get; set; }
    }
}