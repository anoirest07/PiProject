using data.Infrastructure;
using DATA;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class ServiceUser
    {
        IUnitOfWork utwk;
        private Context _db;

        public ServiceUser()
        {
            _db = new Context();
        }
        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(User => User.Id == id);
        }
        public IEnumerable<User> GetAll()
        {
            return utwk.getRepository<User>().GetAll();
        }
    }
}
