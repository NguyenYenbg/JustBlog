using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Comments;
using FA.JustBlog.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Services.Comments
{
    public interface ICommentService
    {
        ResponseResult Create(CreateCommentViewModel request);
        Comment GetById(int id);
        ResponseResult Update(CreateCommentViewModel request, int id);
        IEnumerable<CommentViewModel> GetAll();

        void Delete(int id);
    }
}