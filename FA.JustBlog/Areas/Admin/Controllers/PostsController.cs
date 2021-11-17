using FA.JustBlog.Models.Posts;
using FA.JustBlog.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }
        // GET: Admin/Posts
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
        public ActionResult Create(CreatePostViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.postService.Create(request);
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
            var posts = this.postService.GetAll();
            return View(posts);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.postService.Delete(id);
            return RedirectToAction("Show");
        }

        public ActionResult Edit(int id)
        {
            var data = this.postService.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CreatePostViewModel request, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.postService.Update(request,id);
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
            var data = this.postService.GetById(id);
            return View(data);
        }

        public ActionResult GetPostByCategory(string search)
        {
            var posts = this.postService.GetPostsByCategory(search);
            return View(posts);
        }
    }
}