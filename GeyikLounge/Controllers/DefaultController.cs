using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeyikLounge.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult partialHead()
        {
            return PartialView();
        }

        public PartialViewResult partialScript() 
        {
            return PartialView();
        }
    }
}