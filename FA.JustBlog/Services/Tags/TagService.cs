using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Results;
using FA.JustBlog.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateTagViewModel request)
        {
            try
            {
                var tag = new Tag()
                {
                    Name = request.Name,
                    UrlSlug = request.UrlSlug,
                    Description = request.Description,
                    Count=request.Count,
                };
                this.unitOfWork.TagRepository.Add(tag);
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
            this.unitOfWork.TagRepository.Delete(id);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<TagViewModel> GetAll()
        {
            var tags = this.unitOfWork.TagRepository.GetAll();
            return Mapper.Map<IEnumerable<TagViewModel>>(tags);
        }

        public Tag GetById(int id)
        {
            var tag = this.unitOfWork.TagRepository.GetById(id);
            return tag;
        }

        public ResponseResult Update(CreateTagViewModel request, int id)
        {
            try
            {
                var tag = GetById(id);

                tag.Name = request.Name;
                tag.UrlSlug = request.UrlSlug;
                tag.Description = request.Description;
                tag.Count = request.Count;

                this.unitOfWork.TagRepository.Update(tag);
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