using FA.JustBlog.Core;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private IUnitOfWork iUnitOfWork;
        // GET: Category
        public ActionResult Index()
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Category> categories = iUnitOfWork.CategoryRepository.GetAll().ToList();
            return View(categories);
        }


        public ActionResult View(string name)
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Post> posts = iUnitOfWork.PostRepository.GetPostsByCategory(name).ToList();
            return View(posts);
        }


    }
}