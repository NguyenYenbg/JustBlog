using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        IEnumerable<Post> FindPost(int year, int month, string urlSlug);
        IList<Post> FindPostByTitle(string title);
        IList<Post> GetPublisedPosts(string publish);
        IList<Post> GetUnPublisedPosts(string publish);
        IList<Post> GetLatestPost(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);

        //update
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
    }
}
