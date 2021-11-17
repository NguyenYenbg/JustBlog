using FA.JustBlog.Models.Tags;
using FA.JustBlog.Services.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagService tagService;
        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        // GET: Admin/Tags
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
        public ActionResult Create(CreateTagViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.tagService.Create(request);
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
            var tags = this.tagService.GetAll();
            return View(tags);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.tagService.Delete(id);
            return RedirectToAction("Show");
        }

        public ActionResult Edit(int id)
        {
            var data = this.tagService.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CreateTagViewModel request, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.tagService.Update(request, id);
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
            var data = this.tagService.GetById(id);
            return View(data);
        }
    }
}