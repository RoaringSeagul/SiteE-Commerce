namespace GrosBrasInc.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GrosBrasInc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GrosBrasInc.Models.ApplicationDbContext context)
        {
           AddRoles(context);
           AddUser(context);
           AddUserRole(context);
           AddArticlesCategorie(context);
           AddArticles(context);
        }

        private void AddArticlesCategorie(ApplicationDbContext context)
        {
            Categorie[] categories =
            {
                new Categorie() { NomCategorie = "Gros" },    
                new Categorie() { NomCategorie = "Moyen" },    
                new Categorie() { NomCategorie = "Minus" },
                new Categorie() { NomCategorie = "Coureur" }
            };

            context.Categories.AddOrUpdate(p => p.NomCategorie, categories);
            context.SaveChanges(context);
        }

        private void AddArticles(ApplicationDbContext context)
        {
            Article[] articles =
            {
                new Article() { NomArticle =  "Chest", Categorie = context.Categories.Where(p => p.NomCategorie == "Gros").FirstOrDefault(),
                                    Description = "Des affaire pour un gros chest", Prix = 12.99f },
                new Article() { NomArticle =  "Bras", Categorie = context.Categories.Where(p => p.NomCategorie == "Gros").FirstOrDefault(),
                                    Description = "Des affaire pour un gros chest", Prix = 15.99f },
                new Article() { NomArticle =  "Dos", Categorie = context.Categories.Where(p => p.NomCategorie == "Gros").FirstOrDefault(),
                                    Description = "Des affaire pour un gros chest", Prix = 17.99f },
                new Article() { NomArticle =  "Shake", Categorie = context.Categories.Where(p => p.NomCategorie == "Gros").FirstOrDefault(),
                                    Description = "Des affaire pour un gros chest", Prix = 19.99f },
                new Article() { NomArticle =  "Cancer", Categorie = context.Categories.Where(p => p.NomCategorie == "Gros").FirstOrDefault(),
                                    Description = "Des affaire pour un gros chest", Prix = 256301.00f }
            };

            context.Articles.AddOrUpdate(p => p.NomArticle, articles);
            context.SaveChanges(context);
        }

        private void AddRoles(ApplicationDbContext context)
        {
            IdentityRole[] roles =
            {
                new IdentityRole() { Id = "1", Name = "Administrateur" },
                new IdentityRole() { Id = "2", Name = "Modérateur" },
                new IdentityRole() { Id = "3", Name = "Client" },
                new IdentityRole() { Id = "4", Name = "Utilisateur" }
            };

            context.Roles.AddOrUpdate(p => p.Name, roles);
            context.SaveChanges(context);
        }

        private void AddUserRole(ApplicationDbContext context)
        {
            IdentityUserRole[] usersRole =
            {
                new IdentityUserRole()
                {
                    UserId = context.Users.Where(p => p.Email.Contains("admin@grosbrasinc.ca")).SingleOrDefault().Id,
                    RoleId = context.Roles.Where(p => p.Name.Contains("Administrateur")).First().Id
                },

                new IdentityUserRole()
                {
                    UserId = context.Users.Where(p => p.Email.Contains("mode@grosbrasinc.ca")).SingleOrDefault().Id,
                    RoleId = context.Roles.Where(p => p.Name.Contains("Modérateur")).First().Id
                },

                new IdentityUserRole()
                {
                    UserId = context.Users.Where(p => p.Email.Contains("user1@grosbrasinc.ca")).SingleOrDefault().Id,
                    RoleId = context.Roles.Where(p => p.Name.Contains("Utilisateur")).First().Id
                },

                new IdentityUserRole()
                {
                    UserId = context.Users.Where(p => p.Email.Contains("user2@grosbrasinc.ca")).SingleOrDefault().Id,
                    RoleId = context.Roles.Where(p => p.Name.Contains("Client")).First().Id
                }
            };

            context.Set<IdentityUserRole>().AddOrUpdate(p => new { p.RoleId, p.UserId }, usersRole);
            context.SaveChanges(context);
        }

        private void AddUser(ApplicationDbContext context)
        {
            PasswordHasher pass = new PasswordHasher();

            ApplicationUser[] users =
            {
                new ApplicationUser()
                {
                    Email = "admin@grosbrasinc.ca",
                    UserName = "admin@grosbrasinc.ca",
                    PasswordHash = pass.HashPassword("Gb123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new ApplicationUser()
                {
                    Email = "mode@grosbrasinc.ca",
                    UserName = "mode@grosbrasinc.ca",
                    PasswordHash = pass.HashPassword("Gb123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new ApplicationUser()
                {
                    Email = "user1@grosbrasinc.ca",
                    UserName = "user1@grosbrasinc.ca",
                    PasswordHash = pass.HashPassword("Gb123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new ApplicationUser()
                {
                    Email = "user2@grosbrasinc.ca",
                    UserName = "user2@grosbrasinc.ca",
                    PasswordHash = pass.HashPassword("Gb123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            context.Users.AddOrUpdate(p => p.Email, users);
            context.SaveChanges(context);
        }
    }
}
