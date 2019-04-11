﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class CommentViewModel
    {
        [Key]
        public int CommentId { get; set; }
        public string ContenuCom { get; set; }
        public DateTime DateCom { get; set; }


        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }

        public Participant Participants { get; set; }

        public int PostId { get; set; }


        public Post Posts { get; set; }

    }
}