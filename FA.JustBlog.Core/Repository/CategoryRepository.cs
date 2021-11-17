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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("CategoryRepository is created");
        }

        
    }
}
