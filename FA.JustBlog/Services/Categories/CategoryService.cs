using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Categories;
using FA.JustBlog.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateCategoryViewModel request)
        {
            try
            {
                var category = new Category()
                {
                    Name = request.Name,
                    UrlSlug = request.UrlSlug,
                    Description = request.Description,
                };
                this.unitOfWork.CategoryRepository.Add(category);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public void Delete(int id)
        {
            this.unitOfWork.CategoryRepository.Delete(id);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.unitOfWork.CategoryRepository.GetAll();
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public Category GetById(int id)
        {
            var category = this.unitOfWork.CategoryRepository.GetById(id);
            return category;
        }

        public ResponseResult Update(CreateCategoryViewModel request, int id)
        {
            try
            {
                var category = GetById(id);

                category.Name = request.Name;
                category.UrlSlug = request.UrlSlug;
                category.Description = request.Description;

                this.unitOfWork.CategoryRepository.Update(category);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }
    }
}