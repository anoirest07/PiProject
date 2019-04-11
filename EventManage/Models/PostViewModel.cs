using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Models
{
    public enum Categories { type1, type2 }

    public class PostViewModel
    {
        [Key]
        public int IdPost { get; set; }

        [Required(ErrorMessage = "Title: Field is required")]
        [StringLength(500, ErrorMessage = "Title: Length should not exceed 500 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description: Field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "PostedOn: Field is required")]
        public DateTime PostedOn { get; set; }
        public Categories Category { get; set; }
        
        public string Photo { get; set; }
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public int Like { get; set; }
        public int commentss { get; set; }
        //public Participant Participants { get; set; }

        public virtual ICollection<CommentViewModel> ListComments { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}