using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new Models.FISEntities();
            var lstItem = (from p in db.Accounts orderby p.user_id descending select p).ToList();
            Models.Account a = lstItem[0];
            return View(lstItem);
        }
    }
}