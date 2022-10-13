using Microsoft.AspNetCore.Mvc;
using mvcCrud.Data;
using mvcCrud.Models;

namespace mvcCrud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {

                ModelState.AddModelError("name","The DisplayOrder cannot Exectly Same");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //From Here Start Edit Functions
        //Get
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var categoryfromdb = _db.categories.Find(Id);
            if (categoryfromdb==null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {

                ModelState.AddModelError("name", "The DisplayOrder cannot Exectly Same");
            }
            if (ModelState.IsValid)
            {
                //from here update record
                _db.categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //From here Start Delete Funcions
        //Get
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var categoryfromdb = _db.categories.Find(Id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            //from here update record
            _db.categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
        }
    }
}
