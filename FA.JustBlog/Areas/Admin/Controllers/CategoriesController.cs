using FA.JustBlog.Models.Categories;
using FA.JustBlog.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: Admin/Categories
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
        public ActionResult Create(CreateCategoryViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.categoryService.Create(request);
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
            var categoryes = this.categoryService.GetAll();
            return View(categoryes);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.categoryService.Delete(id);
            return RedirectToAction("Show");
        }

        public ActionResult Edit(int id)
        {
            var data = this.categoryService.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CreateCategoryViewModel request, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.categoryService.Update(request, id);
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
            var data = this.categoryService.GetById(id);
            return View(data);
        }
    }
}