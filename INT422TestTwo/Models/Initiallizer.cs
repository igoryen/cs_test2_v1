using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using INT422TestTwo.Models;

namespace INT422TestTwo.Models
{
    public class Initiallizer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext dc)
        {
          InitializeIdentityForEF(dc);
          InitializeTables(dc);
          base.Seed(dc);
        }

        private void InitializeIdentityForEF(DataContext context) {

          var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
          var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

          string AdminRole = "Admin";
          if (!RoleManager.RoleExists(AdminRole)) {
            var AdminRoleCreateResult = RoleManager.Create(new IdentityRole(AdminRole));
          }

          string UserRole = "User";
          if (!RoleManager.RoleExists(UserRole)) {
            var UserRoleCreateResult = RoleManager.Create(new IdentityRole(UserRole));
          }


          var user1 = new ApplicationUser();
          string user1Pw = "123456";
          var user1Info = new MyUserInfo() { FirstName = "User", LastName = "Uno", PhoneNo = "647-111-1111" };
          user1.UserName = "UserUno";
          user1.MyUserInfo = user1Info;
          var user1CreateResult = UserManager.Create(user1, user1Pw);
          if (user1CreateResult.Succeeded) {
            var addUser1ToAdminRoleResult = UserManager.AddToRole(user1.Id, AdminRole);
          }

          var user2 = new ApplicationUser();
          string user2Pw = "123456";
          var user2Info = new MyUserInfo() { FirstName = "User", LastName = "Duo", PhoneNo = "647-222-2222" };
          user2.UserName = "UserDuo";
          user2.MyUserInfo = user2Info;
          var user2CreateResult = UserManager.Create(user2, user2Pw);
          if (user2CreateResult.Succeeded) {
            var addUser2ToUserRoleResult = UserManager.AddToRole(user2.Id, UserRole);
          }

        }

        private void InitializeTables(DataContext dc)
        {
            Genre g = new Genre("Fantasy");
            dc.Genres.Add(g);
            Genre g1 = new Genre("Drama");
            dc.Genres.Add(g1);
            Genre g2 = new Genre("Comedy");
            dc.Genres.Add(g2);
            Genre g3 = new Genre("Adventure");
            dc.Genres.Add(g3);
            Genre g4 = new Genre("War");
            dc.Genres.Add(g4);
            Genre g5 = new Genre("Crime");
            dc.Genres.Add(g5);

            Director d = new Director("Goldwyn");
            dc.Directors.Add(d);
            Movie mo = new Movie();
            mo.Title = "Darkfall Resurection";
            mo.TicketPrice = 15.99m;
            mo.Director = d;
            mo.Genres.Add(g);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            
            mo = null;
            d = null;

            d = new Director("Hill");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.Title = "The Life & Adventures of Santa Claus";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g);
            mo.Genres.Add(g2);
            dc.Movies.Add(mo);
            mo = null;
            d = null;

            d = new Director("Lean");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.Title = "Lawrence of Arabia";
            mo.TicketPrice = 14.99m;
            mo.Director = d;
            mo.Genres.Add(g4);
            mo.Genres.Add(g3);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            mo = null;

            mo = new Movie();
            mo.Title = "A Passage to India";
            mo.TicketPrice = 16.99m;
            mo.Director = d;
            mo.Genres.Add(g1);
            mo.Genres.Add(g3);
            dc.Movies.Add(mo);
            mo = null;
            d = null;

            d = new Director("Aldrich");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.Title = "The Dirty Dozen";
            mo.TicketPrice = 15.99m;
            mo.Director = d;
            mo.Genres.Add(g4);
            mo.Genres.Add(g2);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            mo = null;

            mo = new Movie();
            mo.Title = "The Choirboys";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g1);
            mo.Genres.Add(g2);
            mo.Genres.Add(g5);
            dc.Movies.Add(mo);
            mo = null;

            mo = new Movie();
            mo.Title = "The Longest Yard";
            mo.TicketPrice = 13.99m;
            mo.Director = d;
            mo.Genres.Add(g1);
            mo.Genres.Add(g2);
            mo.Genres.Add(g5);
            dc.Movies.Add(mo);
            mo = null;
            d = null;

            d = new Director("Scott");
            dc.Directors.Add(d);
            mo = new Movie();
            mo.Title = "True Romance";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g5);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);
            mo = null;

            mo = new Movie();
            mo.Title = "Unstoppable";
            mo.TicketPrice = 12.99m;
            mo.Director = d;
            mo.Genres.Add(g3);
            mo.Genres.Add(g1);
            dc.Movies.Add(mo);

            dc.SaveChanges();
        }

    }
}