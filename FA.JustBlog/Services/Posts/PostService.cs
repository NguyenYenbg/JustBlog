
using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Posts;
using FA.JustBlog.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseResult Create(CreatePostViewModel request)
        {
            try
            {
                var post = new Post()
                {
                    Title = request.Title,
                    ShortDescription = request.ShortDescription,
                    ShortContent = request.ShortContent,
                    UrlSlug = request.UrlSlug,
                    Published = request.Published,
                    PostedOn = request.PostedOn = DateTime.Now,
                    Modified = request.Modified,
                    CategoryId = request.CategoryId,
                    ViewCount = request.ViewCount,
                    RateCount = request.RateCount,
                    TotalRate = request.TotalRate,
                    PostContent = request.PostContent,
                };
                this.unitOfWork.PostRepository.Add(post);
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
            this.unitOfWork.PostRepository.Delete(id);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public Post GetById(int id)
        {
            var post = this.unitOfWork.PostRepository.GetById(id);
            return post;
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            var posts = this.unitOfWork.PostRepository.GetPostsByCategory(category);
            return posts;
        }

        public ResponseResult Update(CreatePostViewModel request, int id)
        {
            try
            {
                var post = GetById(id);

                post.Title = request.Title;
                post.ShortDescription = request.ShortDescription;
                post.ShortContent = request.ShortContent;
                post.UrlSlug = request.UrlSlug;
                post.Published = request.Published;
                post.PostedOn = request.PostedOn = DateTime.Now;
                post.Modified = request.Modified;
                post.CategoryId = request.CategoryId;
                post.ViewCount = request.ViewCount;
                post.RateCount = request.RateCount;
                post.TotalRate = request.TotalRate;
                post.PostContent = request.PostContent;

                this.unitOfWork.PostRepository.Update(post);
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

