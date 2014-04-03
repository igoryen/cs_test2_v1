using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INT422TestTwo.Models;

namespace INT422TestTwo.Controllers
{
  [Authorize]
    public class HomeController : Controller
    {
    private DataContext dc = new DataContext();
        public ActionResult Index()
        {
            return View();
          //return View(dc.Users.Where(user => user.MyUserInfo.FirstName.Equals("Uno")));
        }
    }
}