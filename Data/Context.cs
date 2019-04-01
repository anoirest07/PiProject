﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

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

        public Context() : base("name=EventDB")
        {

        }
        
        public DbSet<Evenement> Evenement { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<Rapport> Rapport { get; set; }
        
        public DbSet<Recomendation> Recomendation { get; set; }

        public DbSet<Tache> Tache { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //Fluent API Configurations
            modelBuilder.Configurations.Add(new Cofiguration.UserConfig());
            modelBuilder.Configurations.Add(new Cofiguration.TicketConfig());
            modelBuilder.Configurations.Add(new Cofiguration.TacheConfig());
            modelBuilder.Configurations.Add(new Cofiguration.RecomendationConfig());
            modelBuilder.Configurations.Add(new Cofiguration.CommentConfig());


            


        }


    }
}
