﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace INT422TestTwo.Models
{
    /// <summary>
    /// Class can be used to query/store data in Database
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Default Constructor, passes name to DbContext
        /// </summary>
        public DataContext() : base("name=INT422TestTwoDataContext") { }

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
    }
}
