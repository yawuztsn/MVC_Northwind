using MVCNorthwind_3.DesignPatterns.SingletonPattern;
using MVCNorthwind_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind_3.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DbInstance;
        }
        public ActionResult ListCategories()
        {
            return View(_db.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id) 
        {
            return View(_db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            Category guncellenecek = _db.Categories.Find(category.CategoryID);
            guncellenecek.CategoryName = category.CategoryName;
            guncellenecek.Description = category.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

    }
}