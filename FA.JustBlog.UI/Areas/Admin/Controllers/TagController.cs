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
    [Route("Tag/{action}")]
    [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
    public class TagController : Controller
    {
        private readonly IUnitOfWork _uow;
        public TagController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: TagController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var tags = _uow.Tag.GetAll()
                                .OrderByDescending(p => p.TagId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = _uow.Category.GetAll().Count();
            return View(tags);
        }

        // GET: TagController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var tag = _uow.Tag.GetEntityById(id.Value);
                if (tag != null)
                {
                    return View(tag);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: TagController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tags tags)
        {
            tags.UrlSlug = SeoUrlHelper.GenerateSlug(tags.Name);

            _uow.Tag.Add(tags);
            _uow.SaveChange();

            return RedirectToAction("Index", "Tag");
        }

        // GET: TagController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tags tags = _uow.Tag.GetEntityById(id.Value);

            if (tags == null)
            {
                return NotFound();
            }

            return View(tags);
        }

        // POST: TagController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tags tags)
        {
            tags.UrlSlug = SeoUrlHelper.GenerateSlug(tags.Name);
            _uow.Tag.Update(tags);
            _uow.SaveChange();

            return RedirectToAction("Index", "Tag");
        }

        // GET: TagController/Delete/5
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
