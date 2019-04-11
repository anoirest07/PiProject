using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class BlogViewModel
    {
        public PostViewModel PostModel { get; set; }
        public CommentViewModel CommentModel{ get; set; }
    }
}