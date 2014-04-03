using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace INT422TestTwo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      public virtual MyUserInfo MyUserInfo { get; set; }
    }

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
      public DataContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
          base.OnModelCreating(modelBuilder);
          // Change the name of the table to be Users instead of AspNetUsers
          modelBuilder.Entity<IdentityUser>().ToTable("Users");
          modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        }

        /// <summary>
        /// Will hold all the Movies stored in Database
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Will hold all the Directors stored in Database
        /// </summary>
        public DbSet<Director> Directors { get; set; }

        /// <summary>
        /// Will hold all the Genres stored in Database
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.MovieForList> MovieForLists { get; set; }
        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.MovieForDetails> MovieForDetails { get; set; }
        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.DirectorForList> DirectorForLists { get; set; }
        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.GenreForList> GenreForLists { get; set; }
        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.MovieFull> MovieFulls { get; set; }
        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.GenreFull> GenreFulls { get; set; }
        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.DirectorFull> DirectorFulls { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}