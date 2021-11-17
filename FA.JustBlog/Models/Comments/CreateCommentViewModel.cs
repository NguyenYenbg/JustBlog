using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models.Comments
{
    public class CreateCommentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be left blank")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cannot be left blank")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PostId cannot be left blank")]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Required(ErrorMessage = "CommentHeader cannot be left blank")]
        [MaxLength(200, ErrorMessage = "CommentHeader cannot exceed 100 characters")]
        public string CommentHeader { get; set; }

        [Required(ErrorMessage = "CommentText cannot be left blank")]
        [MaxLength(200, ErrorMessage = "CommentText cannot exceed 500 characters")]
        public string CommentText { get; set; }

        [Required(ErrorMessage = "CommentTime cannot be left blank")]
        public DateTime? CommentTime { get; set; }
    }
}