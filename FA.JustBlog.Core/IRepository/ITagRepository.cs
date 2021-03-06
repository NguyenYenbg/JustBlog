using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        IEnumerable<Tag> GetTagUrlSlug(string urlSlug);
    }
}
