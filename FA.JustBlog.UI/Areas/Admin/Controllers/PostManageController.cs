using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("PostManage/{action}")]
    [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
    public class PostManageController : Controller
    {

        private readonly IUnitOfWork _uow;
        public PostManageController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: PostManageController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1); 

            var posts = _uow.Post.GetAll()
                                .OrderByDescending(p => p.PostId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = _uow.Post.GetAll().Count();
            return View(posts);

        }

        // GET: PostManageController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = _uow.Post.GetEntityById(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: PostManageController/Create
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        public ActionResult Create()
        {
            var cate = _uow.Category.GetAll();
            var list = new List<SelectListItem>();
            foreach (var item in cate)
            {
                list.Add(new SelectListItem() { Value = item.CategoryId.ToString(), Text = item.Name });
            }
            ViewData["categories"] = list;
        
            return View();
        }

        // POST: PostManageController/Create
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Posts posts)
        {
            posts.UrlSlug = SeoUrlHelper.GenerateSlug(posts.Title);
            posts.PostedOn = DateTime.Now;
            posts.Modified = DateTime.Now;

            _uow.Post.Add(posts);
            _uow.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: PostManageController/Edit/5
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cate = _uow.Category.GetAll();
            var list = new List<SelectListItem>();
            foreach (var item in cate)
            {
                list.Add(new SelectListItem() { Value = item.CategoryId.ToString(), Text = item.Name });
            }
            ViewData["categories"] = list;

            Posts posts = _uow.Post.GetEntityById(id.Value);

            if (posts == null)
            {
                return NotFound();
            }
            return View(posts);
        }

        // POST: PostManageController/Edit/5
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts posts)
        {
            posts.UrlSlug = SeoUrlHelper.GenerateSlug(posts.Title);
            posts.PostedOn = DateTime.Now;
            posts.Modified = DateTime.Now;
            _uow.Post.Update(posts);
            _uow.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: PostManageController/Delete/5
        [Authorize(Roles = ("Admin, Blog Owner"))]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                _uow.Post.Delete(id.Value);
                _uow.SaveChange();
            }
            return RedirectToAction("Index");
        }

        public ActionResult LastedPost()
        {

            var posts = _uow.Post.GetLatestPost(5);

            return View(posts.ToList());
        }

        public ActionResult MostViewedPosts()
        {
            var posts = _uow.Post.GetMostViewedPost(5);

            return View(posts.ToList());
        }

        [Authorize(Roles = ("Admin, Blog Owner"))]
        public ActionResult PublisedPosts()
        {
            var posts = _uow.Post.GetPublisedPosts();

            return View(posts.ToList());
        }

        [Authorize(Roles = ("Admin, Blog Owner"))]
        public ActionResult UnpublisedPosts()
        {
            var posts = _uow.Post.GetUnpublisedPosts();

            return View(posts.ToList());
        }
    }
}
