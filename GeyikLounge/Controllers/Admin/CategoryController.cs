using GeyikLounge.Context;
using GeyikLounge.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GeyikLounge.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly GeyikLoungeContext _context;

        public CategoryController()
        {
            _context = new GeyikLoungeContext();
        }

        public ActionResult Index()
        {
            var categories = _context.Categories.Include(c => c.Menu).ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(_context.Menus, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(_context.Menus, "Id", "Name", category.MenuId);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(_context.Menus, "Id", "Name", category.MenuId);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.MenuId = category.MenuId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(_context.Menus, "Id", "Name", category.MenuId);
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}