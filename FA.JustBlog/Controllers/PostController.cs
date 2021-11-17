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
    public class PostController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private IUnitOfWork iUnitOfWork;
        // GET: Post
        public ActionResult Index()
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Post> posts = iUnitOfWork.PostRepository.GetLatestPost(db.Posts.Count()).ToList();
            return View(posts);
        }
        public ActionResult Details(int year, int month, string title)
        {
            iUnitOfWork = new UnitOfWork(db);
            var post = iUnitOfWork.PostRepository.FindPost(year, month, title);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        public ActionResult MostViewedPosts()
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Post> posts = iUnitOfWork.PostRepository.GetMostViewedPost(5).ToList();
            return View(posts);
        }

        public ActionResult LatestPosts()
        {
            iUnitOfWork = new UnitOfWork(db);
            List<Post> posts = iUnitOfWork.PostRepository.GetLatestPost(5).ToList();
            return View(posts);
        }


        public ActionResult FindPostByTitle(string search)
        {
            iUnitOfWork = new UnitOfWork(db);
            var posts = iUnitOfWork.PostRepository.FindPostByTitle(search);
            return View(posts);
        }

        public ActionResult GetCommentByPost(int id)
        {
            iUnitOfWork = new UnitOfWork(db);
            var comments = iUnitOfWork.CommentRepository.GetCommentsForPost(id);
            return View(comments);
        }
    }
}