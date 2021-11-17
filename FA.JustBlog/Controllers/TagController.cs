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
    public class TagController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private IUnitOfWork iUnitOfWork;
        // GET: Tag
        public ActionResult Index()
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Tag> tags = iUnitOfWork.TagRepository.GetAll().ToList();
            return View(tags);
        }

        public ActionResult View(string name)
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Post> posts = iUnitOfWork.PostRepository.GetPostsByTag(name).ToList();
            return View(posts);
        }
    }
}