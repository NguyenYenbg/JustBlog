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

    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("CommentRepository is created");
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment() { Id = postId, Name=commentName, Email=commentEmail, CommentHeader=commentTitle, CommentText=commentBody };
            context.Comments.Add(comment);
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            var list = from c in context.Comments
                       join p in context.Posts on c.PostId equals p.Id
                       where c.PostId == postId
                       select c;
            return list.ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            var list = from c in context.Comments
                       join p in context.Posts on c.PostId equals p.Id
                       where c.PostId == post.Id
                       select c;
            return list.ToList();
        }
    }
}
