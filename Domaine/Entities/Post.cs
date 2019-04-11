
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Categories { type1 , type2 }
    public  class Post
    {
        [Key]
        public int IdPost { get; set; }

        [Required(ErrorMessage = "Title: Field is required")]
        [StringLength(500, ErrorMessage = "Title: Length should not exceed 500 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description: Field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "PostedOn: Field is required")]
        public  DateTime PostedOn { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }
        public Categories Category { get; set; }
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public int Like { get; set; }
        public int commentss { get; set; }
        // public Participant Participants { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Likes> Likess { get; set; }
    }
}
