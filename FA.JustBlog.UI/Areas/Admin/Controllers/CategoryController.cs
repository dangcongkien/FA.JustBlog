using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Category/{action}")]
    [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: CategoryController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var categories = _uow.Category.GetAll()
                                .OrderByDescending(p => p.CategoryId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = _uow.Category.GetAll().Count();
            return View(categories);
            
        }

        //GET: CategoryController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var category = _uow.Category.GetEntityById(id.Value);
                if (category != null)
                {
                    return View(category);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categories)
        {

            categories.UrlSlug = SeoUrlHelper.GenerateSlug(categories.Name);

            _uow.Category.Add(categories);
            _uow.SaveChange();

            return RedirectToAction("Index", "Category");
        }

        // GET: CategoryController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Categories categories = _uow.Category.GetEntityById(id.Value);

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: CategoryController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories categories)
        {
            categories.UrlSlug = SeoUrlHelper.GenerateSlug(categories.Name);
            _uow.Category.Update(categories);
            _uow.SaveChange();

            return RedirectToAction("Index", "Category");

        }


        // POST: CategoryController/Delete/5
        [Authorize(Roles = "Admin, Blog Owner")]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                _uow.Category.Delete(id.Value);
                _uow.SaveChange();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
