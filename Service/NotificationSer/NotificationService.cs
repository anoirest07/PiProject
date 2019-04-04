using data.Infrastructure;
using Domaine.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.NotificationSer
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public NotificationService() : base(unit)
        {
        }

    }
}
