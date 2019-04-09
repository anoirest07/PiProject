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

        //public IEnumerable<Post> ListCategorie()
        //{
        //    //var c = GetMany(t => t.Category == Categorie.type1);
        //    //foreach (var item in c)
        //    //{
        //    //    Console.WriteLine(" code " + item.IdPost + " Nom " + item.Title+ " Departement" + item.Description +"    " + item.Photo +"  "+item.PostedOn);
        //    //}
        //    //return c;
        //}

        //public IEnumerable<Post> ListCategorie2()
        //{
        //    //var c = GetMany(t => t.Category == Categorie.type2);
        //    //foreach (var item in c)
        //    //{
        //    //    Console.WriteLine(" code " + item.IdPost + " Nom " + item.Title + " Departement" + item.Description + "    " + item.Photo + "  " + item.PostedOn);
        //    //}
        //    //return c;
        //}
    }
}
