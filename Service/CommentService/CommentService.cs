using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CommentService
{
   public class CommentService : Service<Comment>, ICommentService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public CommentService() : base(unit)
        {
        }
        public int GetCommentNumber(int id)
        {
            return unit.getRepository<Comment>().GetMany(p => p.PostId == id).Count();
        }
        public List<Comment> nbrComment(int id)
        {

            List<Comment> list = unit.getRepository<Comment>().GetAll().ToList();
            list = list.FindAll(x => x.PostId.Equals(id)).ToList();
            return list;
        }

    }
}
