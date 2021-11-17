using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("TagRepository is created");
        }

        public IEnumerable<Tag> GetTagUrlSlug(string urlSlug)
        {
            return context.Tags.Where(t => t.UrlSlug == urlSlug).ToList();
        }
    }
}
