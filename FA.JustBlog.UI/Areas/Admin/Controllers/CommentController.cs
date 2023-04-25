﻿using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Comment/{action}")]
    [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CommentController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: CommentController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var comments = _uow.Comments.GetAll()
                                .OrderByDescending(p => p.CommentId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = _uow.Comments.GetAll().Count();
            return View(comments);
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var comments = _uow.Comments.GetEntityById(id.Value);
                if (comments != null)
                {
                    return View(comments);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: CommentController/Create
        [Authorize(Roles = "Admin, Blog Owner")]
        public ActionResult Create()
        {
            var posts = _uow.Post.GetAll();
            var list = new List<SelectListItem>();
            foreach (var item in posts)
            {
                list.Add(new SelectListItem() { Value = item.PostId.ToString(), Text = item.Title });
            }
            ViewData["posts"] = list;
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Blog Owner")]
        public ActionResult Create(Comments comments)
        {
            comments.CommentTime = DateTime.Now;
            _uow.Comments.Add(comments);
            _uow.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: CommentController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var posts = _uow.Post.GetAll();
            var list = new List<SelectListItem>();
            foreach (var item in posts)
            {
                list.Add(new SelectListItem() { Value = item.PostId.ToString(), Text = item.Title });
            }
            ViewData["posts"] = list;
            Comments comment = _uow.Comments.GetEntityById(id.Value);
            if (comment == null)
            {
                return NotFound();

            }
            return View(comment);
        }

        // POST: CommentController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comments comments)
        {
            comments.CommentTime = DateTime.Now;

            _uow.Comments.Update(comments);
            _uow.SaveChange();

            return RedirectToAction("Index");
        }

        // GET: CommentController/Delete/5
        [Authorize(Roles = "Admin, Blog Owner")]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                _uow.Comments.Delete(id.Value);
                _uow.SaveChange();
            }
            return RedirectToAction("Index");
        }

    }
}
