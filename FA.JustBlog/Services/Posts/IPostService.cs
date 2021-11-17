using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Posts;
using FA.JustBlog.Models.Results;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Posts
{
    public interface IPostService
    {
        ResponseResult Create(CreatePostViewModel request);
        Post GetById(int id);
        ResponseResult Update(CreatePostViewModel request, int id);
        IEnumerable<PostViewModel> GetAll();

        void Delete(int id);

        IList<Post> GetPostsByCategory(string category);

    }
}