using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models.Posts
{
    public class CreatePostViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Title k được để trống")]
        [MaxLength(200, ErrorMessage ="Title k được quá 200 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short description k được để trống")]
        [MaxLength(500, ErrorMessage = "Title k được quá 500 ký tự")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Short Content k được để trống")]
        public string ShortContent { get; set; }

        [Required(ErrorMessage = "UrlSlug k được để trống")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Published k được để trống")]
        public string Published { get; set; }

        [Required(ErrorMessage = "PostedOn k được để trống")]
        public DateTime? PostedOn { get; set; }


        public string Modified { get; set; }


        [Required(ErrorMessage = "CategoryId k được để trống")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        //update
        public int? ViewCount { get; set; }
        public int? RateCount { get; set; }
        public int? TotalRate { get; set; }
        public string PostContent { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}