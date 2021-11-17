using FA.JustBlog.Models.Comments;
using FA.JustBlog.Services.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        // GET: Admin/Comments
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateCommentViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.commentService.Create(request);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Congratulations, you have successfully created";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(request);
        }

        public ActionResult Show()
        {
            var comments = this.commentService.GetAll();
            return View(comments);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.commentService.Delete(id);
            return RedirectToAction("Show");
        }

        public ActionResult Edit(int id)
        {
            var data = this.commentService.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CreateCommentViewModel request, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.commentService.Update(request, id);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Congratulations, you have successfully fixed";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(request);
        }
        public ActionResult Detail(int id)
        {
            var data = this.commentService.GetById(id);
            return View(data);
        }
    }
}