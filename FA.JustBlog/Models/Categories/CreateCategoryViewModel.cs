using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models.Categories
{
    public class CreateCategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be left blank")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "UrlSlug cannot be left blank")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Description cannot be left blank")]
        [MaxLength(200, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}