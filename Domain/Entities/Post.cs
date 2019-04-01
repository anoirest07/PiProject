using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
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
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
