using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("PostRepository is created");
        }

        public int CountPostsForCategory(string category)
        {
            int count = (from p in context.Posts
                       join c in context.Categories on p.CategoryId equals c.Id
                       where c.Name == category
                       select p).Count();
            return count;
        }

        public int CountPostsForTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> FindPost(int year, int month, string urlSlug)
        {
            return context.Posts.Where(p => p.PostedOn.Value.Year == year
                && p.PostedOn.Value.Month == month && p.UrlSlug == urlSlug).ToList();
        }

      

        public IList<Post> GetPostsByCategory(string category)
        {
            var list = from p in context.Posts
                       join c in context.Categories on p.CategoryId equals c.Id
                       where c.Name == category
                       select p;
            return list.ToList();   
                
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return context.Posts.Where(p => p.PostedOn == monthYear).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            var list = from p in context.Posts
                       from t in context.Tags
                       where t.Name == tag
                       select p;
            return list.ToList();
        }

        public IList<Post> GetPublisedPosts(string publish)
        {
            return context.Posts.Where(p => p.Published == publish).ToList();
        }

        public IList<Post> GetUnPublisedPosts(string publish)
        {
            return context.Posts.Where(p => p.Published != publish).ToList();

        }
        public IList<Post> GetLatestPost(int size)
        {
            var list =(from p in context.Posts
                       orderby p.PostedOn descending
                       select p).Take(size);
            return list.ToList();
        }

        //

        public IList<Post> GetMostViewedPost(int size)
        {
            var order = (from p in context.Posts
                         orderby p.ViewCount descending
                         select p).Take(size);
            return order.ToList();
        }


        public IList<Post> GetHighestPosts(int size)
        {
            throw new NotImplementedException();
        }

        public IList<Post> FindPostByTitle(string title)
        {
            return context.Posts.Where(p => p.Title == title).ToList();
        }
    }
}
