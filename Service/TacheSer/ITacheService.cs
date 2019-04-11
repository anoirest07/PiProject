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
         IEnumerable<Tache> Listedemestaches(int Iduser);
        IEnumerable<Tache> gettachenotification(DateTime afterDate, int Idusr);
         bool Matache(int IdUser);


    }
}
