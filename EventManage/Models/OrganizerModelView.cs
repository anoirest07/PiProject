using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class OrganizerModelView : UserViewModel
    
    {
        public ICollection<TacheModelView> TachesAFaire { get; set; }
    }
}