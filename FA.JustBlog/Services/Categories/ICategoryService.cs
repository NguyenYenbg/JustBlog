using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Categories;
using FA.JustBlog.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Services.Categories
{
    public interface ICategoryService
    {
        ResponseResult Create(CreateCategoryViewModel request);
        Category GetById(int id);
        ResponseResult Update(CreateCategoryViewModel request, int id);
        IEnumerable<CategoryViewModel> GetAll();

        void Delete(int id);
    }
}