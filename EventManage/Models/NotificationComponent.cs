using Domain.Entities;
using Microsoft.AspNet.SignalR;
using Service.OrganizerSer;
using Service.TacheSer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace EventManage.Models
{
    public class NotificationComponent
    {
       // int test = 0;

        ITacheService ts;
        public int id;


        //Here we will add a function for register notification (will add sql dependency)
        public void RegisterNotification(DateTime currentTime )
        {
           
            string conStr = ConfigurationManager.ConnectionStrings["EventDB"].ConnectionString;
            string sqlCommand = @"SELECT [IdTache],[DescTache],[EtatdeTache] from [dbo].[Taches] where [DeadlineTache] > @AddedOn ";
            //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@AddedOn", currentTime);
                //cmd.Parameters.AddWithValue("@Iduser", Iduser);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                //we must have to execute the command here
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                  //  Console.WriteLine(String.Format("{0}", reader["IdTache"]));
                    // nothing need to add here now
                }
            }
        }

        void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            
            ts = new TacheService();


            // test = Int32.Parse(HttpContext.Current.User.Identity.GetUserId());
            int currentUserId = 0;
            try
            {
                var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                currentUserId = Int32.Parse(userId);
                if (userId != null)
                {
                    currentUserId = Int32.Parse(userId);
                }
            }
            catch (System.NullReferenceException)
            {
                // If no user is logged in, leave SESSION_CONTEXT null (all rows will be filtered)
            }
            


            Console.WriteLine("l id -sssssssssssssssssssssssssss  =    ");
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;

                //from here we will send notification message to client
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

              //  notificationHub.Clients.All.notify("added");
               
                if (ts.Matache(EventManage.Controllers.OrganizerController.test) == true)
                {
                    notificationHub.Clients.All.notify("ok");
                }
                
                //re-register notification
                RegisterNotification(DateTime.Now);

            }
            //else
            //{
            //    SqlDependency sqlDep = sender as SqlDependency;
            //    sqlDep.OnChange -= sqlDep_OnChange;

            //    //from here we will send notification message to client
            //    var notificationHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            //    notificationHub.Clients.All.notify("display");

            //    //re-register notification
            //    RegisterNotification(DateTime.Now);

            //}
        }

        public List<TacheModelView> GetContacts(DateTime afterDate)
        {
            using (ITacheService Ts = new TacheService())
            {
                IOrganizerService Os = new OrganizerService();
                List<Tache> listtache= Ts.GetAll().Where(a => a.DeadlineTache > afterDate).OrderByDescending(a => a.DeadlineTache).ToList();
                List<TacheModelView> lists = new List<TacheModelView>();
                //  List<Tache> liststache = new List<Tache>();
               // listtache = Ts.GetAll().Where(x => x.IsDeleted == false).ToList();
                foreach (var item in listtache)
                {
                    TacheModelView dvm = new TacheModelView();
                    dvm.IdTache = item.IdTache;
                    dvm.Nom = (EventManage.Models.NomTache)item.Nom;
                    if (item.DescTache.Length > 50)
                    {
                        var des = item.DescTache.Substring(0, 23) + " ...";
                        dvm.DescTache = des;
                    }
                    else
                    {
                        dvm.DescTache = item.DescTache;
                    }

                    dvm.DeadlineTache = item.DeadlineTache;
                    dvm.EtatdeTache = (EventManage.Models.EtatTache)item.EtatdeTache;
                    dvm.OrgNom = Os.GetById(item.OragnisateurFk).FirstName;
                    //dvm.Etat.Equals(item.Etat);
                    lists.Add(dvm);

                }

                return lists;
            }
        }
    }
}