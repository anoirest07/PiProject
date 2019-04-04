using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TacheSer
{
    public interface ITacheService : IService<Tache>
    {
        // IEnumerable<Tache> IProfesseurService();
        bool DeleteTache(int employeeId);


    }
}
