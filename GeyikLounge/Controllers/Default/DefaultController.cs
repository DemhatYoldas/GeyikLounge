using GeyikLounge.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeyikLounge.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GeyikLoungeContext _context;

        public DefaultController()
        {
            _context = new GeyikLoungeContext(); // DB bağlantısını manuel kurduk
        }
        public ActionResult Index()
        {
            //var menus = _context.Categories.ToList();
            var menu = _context.Menus.ToList();
            return View(menu);
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