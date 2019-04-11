using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RecommendationService
{
   public class RecommendationService :Service<Recomendation>,IRecommendationService
    {
         private static IDatabaseFactory databaseFactory = new DatabaseFactory();
    private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public RecommendationService() : base(unit)
        {
        }
        public List<Recomendation> GetByIdEvent(int id)
        {

            List<Recomendation> list = unit.getRepository<Recomendation>().GetAll().ToList();
            list = list.FindAll(x => x.IdEvent.Equals(id)).ToList();
            return list;
        }
        //public List<Recomendation> GetSuccess(string email)
        //{

        //    List<Recomendation> list = unit.getRepository<Recomendation>().GetAll().ToList();
        //    list = list.FindAll(x => x.IdEvent.Equals(id)).ToList();
        //    return list;
        //}


    }

}
