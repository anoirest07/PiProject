using data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.servicePosts
{
   public class ServicePost :Service<Post>,IServicePost
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ServicePost() : base(unit)
        {
        }

        public IEnumerable<Post> ListCategorie()
        {
            var c = GetMany(t => t.Category == Categories.type1);
            foreach (var item in c)
            {
                Console.WriteLine(" code " + item.IdPost + " Nom " + item.Title+ " Departement" + item.Description +"    " + item.Photo +"  "+item.PostedOn);
            }
            return c;
        }

        public IEnumerable<Post> ListCategorie2()
        {
            var c = GetMany(t => t.Category == Categories.type2);
            foreach (var item in c)
            {
                Console.WriteLine(" code " + item.IdPost + " Nom " + item.Title + " Departement" + item.Description + "    " + item.Photo + "  " + item.PostedOn);
            }
            return c;
        }


        public IEnumerable<Post> MostLikedPost()
        {
            var c = GetAll().OrderByDescending(t => t.Like).Take(2);
            foreach (var item in c)
            {
                Console.WriteLine(" code " + item.Title + " Nom " + item.ParticipantName + " salaire " + item.ParticipantId);
            }
            return c;
        }

        public IEnumerable<Post> Search(string SearchValue)
        {
            var c = GetAll().Where( x => x.Title.ToString().StartsWith(SearchValue) );
            foreach (var item in c)
            {
                Console.WriteLine(" code " + item.Title + " Nom " + item.ParticipantName + " salaire " + item.ParticipantId);
            }
            return c;
        }


    }
}
