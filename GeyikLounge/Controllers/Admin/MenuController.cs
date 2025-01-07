using GeyikLounge.Context;
using GeyikLounge.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace GeyikLounge.Controllers.Admin
{
    public class MenuController : Controller
    {
        private readonly GeyikLoungeContext _context;

        public MenuController()
        {
            _context = new GeyikLoungeContext(); // DB bağlantısını manuel kurduk
        }

        public ActionResult Index()
        {
            var menus = _context.Menus.ToList();
            return View(menus);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Menu menu, HttpPostedFileBase imageFile)
        {
            if (imageFile != null)
            {
                string imagePath = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(imageFile.FileName));
                imageFile.SaveAs(imagePath);
                menu.ImagePath = "/images/" + Path.GetFileName(imageFile.FileName);
            }

            _context.Menus.Add(menu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var menu = _context.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu, HttpPostedFileBase imageFile)
        {
            var existingMenu = _context.Menus.Find(menu.Id);
            if (existingMenu != null)
            {
                existingMenu.Name = menu.Name;
                if (imageFile != null)
                {
                    string imagePath = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(imageFile.FileName));
                    imageFile.SaveAs(imagePath);
                    existingMenu.ImagePath = "/images/" + Path.GetFileName(imageFile.FileName);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        public ActionResult Delete(int id)
        {
            var menu = _context.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var menu = _context.Menus.Find(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
