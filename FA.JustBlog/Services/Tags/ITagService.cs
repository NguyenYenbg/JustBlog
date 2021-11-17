using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Results;
using FA.JustBlog.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Services.Tags
{
    public interface ITagService
    {
        ResponseResult Create(CreateTagViewModel request);
        Tag GetById(int id);
        ResponseResult Update(CreateTagViewModel request, int id);
        IEnumerable<TagViewModel> GetAll();

        void Delete(int id);
    }
}