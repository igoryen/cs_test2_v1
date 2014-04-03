using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using INT422TestTwo.Models;
using System.Data.Entity;
using AutoMapper;

namespace INT422TestTwo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Data.Entity.Database.SetInitializer(new INT422TestTwo.Models.Initiallizer());

            Mapper.CreateMap<Models.Director, ViewModels.DirectorForList>();
            Mapper.CreateMap<Models.Director, ViewModels.DirectorFull>();

            Mapper.CreateMap<Models.Genre, ViewModels.GenreForList>();
            Mapper.CreateMap<Models.Genre, ViewModels.GenreFull>();

            Mapper.CreateMap<Models.Movie, ViewModels.MovieForList>();
            Mapper.CreateMap<Models.Movie, ViewModels.MovieFull>();


            Mapper.CreateMap<ViewModels.DirectorForList, Models.Director>();
            Mapper.CreateMap<ViewModels.DirectorFull, Models.Director>();

            Mapper.CreateMap<ViewModels.GenreForList, Models.Genre>();
            Mapper.CreateMap<ViewModels.GenreFull, Models.Genre>();

            Mapper.CreateMap<ViewModels.MovieForList, Models.Movie>();
            Mapper.CreateMap<ViewModels.MovieFull, Models.Movie>();

        }
    }
}
