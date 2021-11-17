using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models.Tags
{
    public class TagViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
       
        
    }
}