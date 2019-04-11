using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibData.Conventions;
using DATA.Conventions;
using Domain;
using Domain.Entities;
using Domaine.Entities;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DATA
{
  public  class Context : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        
        public static Context Create()
        {
            return new Context();
        }

        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        public Context() : base("name=EventManage")
        {

        }
        
        public DbSet<Evenement> Evenement { get; set; }
        public DbSet<Achat> Achat { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<Rapport> Rapport { get; set; }
        
        public DbSet<Recomendation> Recomendation { get; set; }

        public DbSet<Tache> Tache { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Reclamation> Reclamation { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Comment> CommentViewModels { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Reward> Rewards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTimeConvention());

            //Fluent API Configurations
            modelBuilder.Configurations.Add(new Cofiguration.UserConfig());
            modelBuilder.Configurations.Add(new Cofiguration.TicketConfig());
            modelBuilder.Configurations.Add(new Cofiguration.TacheConfig());
            modelBuilder.Configurations.Add(new Cofiguration.RecomendationConfig());
            modelBuilder.Configurations.Add(new Cofiguration.CommentConfig());
            modelBuilder.Configurations.Add(new Cofiguration.AchatConfig());
            modelBuilder.Configurations.Add(new Cofiguration.FeedbackConfig());
            modelBuilder.Configurations.Add(new Cofiguration.ReclamationConfig());
            modelBuilder.Configurations.Add(new Cofiguration.EvenementConfig());
            modelBuilder.Configurations.Add(new Cofiguration.RewardConfig());
            modelBuilder.Configurations.Add(new Cofiguration.LikesConfig());
            modelBuilder.Configurations.Add(new Cofiguration.PostConfig());





        }


    }
}
