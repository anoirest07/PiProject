using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class UserViewModel : ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public string Password { get; set; }

        public DateTime DateCrea = DateTime.Now;
    }
}