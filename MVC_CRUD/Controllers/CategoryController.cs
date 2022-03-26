using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories;
            return View(categories);
        }
    }
}
