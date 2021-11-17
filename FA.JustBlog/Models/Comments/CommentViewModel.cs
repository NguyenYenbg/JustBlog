using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models.Comments
{
    public class CommentViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

    }
}