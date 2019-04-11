using data.Infrastructure;
using Domain.Entities;
using Domaine.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RewardService
{
   public class RewardService : Service<Reward>, IRewardService
    {
       private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public RewardService() : base(unit)
        {
        }
    }
}
