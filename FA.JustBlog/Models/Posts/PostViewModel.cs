using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models.Posts
{
    public class PostViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string UrlSlug { get; set; }

        public string Published { get; set; }

        public DateTime? PostedOn { get; set; }

    }
}