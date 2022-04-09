using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.DataAccess.Interfaces;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (_db.GetAll()
                   .Select(c => c.DisplayOrder)
                   .Contains(obj.DisplayOrder))

            {
                string error = "Cannot have same display order";
                ModelState.AddModelError("CustomError", error);
                TempData["error"] = error;
            }


            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Created object with success!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _db.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();  

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            var category = _db.GetAll();
            if (ModelState.IsValid)
            {
                if (!category.Select(c => c.DisplayOrder).Contains(obj.DisplayOrder))
                {
                    _db.Update(obj);
                    _db.Save();
                    TempData["success"] = "Object updated with success!";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Cannot have same display order";
                return View(obj);
            }
            TempData["error"] = "Model isn't valid";
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _db.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
                return NotFound();

            _db.Remove(obj);
            _db.Save();
            TempData["success"] = "Deleted object with success!";
            return RedirectToAction("Index");
        }
    }
}