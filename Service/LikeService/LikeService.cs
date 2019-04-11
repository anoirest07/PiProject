using data.Infrastructure;
using Domain.Entities;
using Domaine.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LikeService
{
   

        public class LikeService : Service<Likes>, ILikeService
        {
            private static IDatabaseFactory databaseFactory = new DatabaseFactory();
            private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
            public LikeService() : base(unit)
            {
            }

        public List<Likes> nbrLike(int id)
        {

            List<Likes> list = unit.getRepository<Likes>().GetAll().ToList();
            list = list.FindAll(x => x.IdPost.Equals(id)).ToList();
            return list;
        }
        public bool Test(int id, int iduser)
        {
            if ((GetMany(x=>x.IdPost==id &&x.IdParticipant==iduser).Count())==0) {
                return false;
            }
            return true;
        }
    }
}
