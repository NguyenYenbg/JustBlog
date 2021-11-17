
using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Comments;
using FA.JustBlog.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateCommentViewModel request)
        {
            try
            {
                var comment = new Comment()
                {
                    Name = request.Name,
                    Email = request.Email,
                    PostId = request.PostId,
                    CommentHeader=request.CommentHeader,
                    CommentText=request.CommentText,
                    CommentTime=request.CommentTime,
                };
                this.unitOfWork.CommentRepository.Add(comment);
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
            this.unitOfWork.CommentRepository.Delete(id);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<CommentViewModel> GetAll()
        {
            var comments = this.unitOfWork.CommentRepository.GetAll();
            return Mapper.Map<IEnumerable<CommentViewModel>>(comments);
        }

        public Comment GetById(int id)
        {
            var comment = this.unitOfWork.CommentRepository.GetById(id);
            return comment;
        }

        public ResponseResult Update(CreateCommentViewModel request, int id)
        {
            try
            {
                var comment = GetById(id);

                comment.Name = request.Name;
                comment.Email = request.Email;
                comment.PostId = request.PostId;
                comment.CommentHeader = request.CommentHeader;
                comment.CommentText = request.CommentText;
                comment.CommentTime = request.CommentTime;

                this.unitOfWork.CommentRepository.Update(comment);
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