﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class WSUserModel 
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
       // public string Image { get; set; }
       // public ICollection< CustomRole> roles { get; set; }
    }
}