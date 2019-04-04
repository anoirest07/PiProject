using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrganizerSer
{
    public interface IOrganizerService : IService<Organizer>
    {
        IEnumerable<Organizer> ListOrganizers();
    }
}
