using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrganizerSer
{
    public class OrganizerService : Service<Organizer>, IOrganizerService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public OrganizerService() : base(unit)
        {
        }
        public IEnumerable<Organizer> ListOrganizers()
        {
            var c = GetMany().OfType<Organizer>();

            return c;
        }
    }
}
