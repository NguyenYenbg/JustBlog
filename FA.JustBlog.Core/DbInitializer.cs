using FA.JustBlog.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class DbInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeeDate(JustBlogContext context)
        {
            base.Seed(context);



            for (int i = 0; i < 3; i++)
            {
                var category = new Category() { Name = $"Category {i}", UrlSlug = $"UrlSlug {i}", Description = "Set in Da Lat, 0.8 mi from Dalat Flower Gardens, Raon Dalat Villa offers accommodations with a restaurant, free private parking, a shared lounge and a garden" };
                context.Categories.Add(category);
                context.SaveChanges();
            }
            for (int i = 0; i < 3; i++)
            {
                //DateTime postedOn = DateTime.Parse("01/02/2020", CultureInfo.CreateSpecificCulture("fr-FR"));
                var post = new Post() { Title = $"Title {i}", ShortDescription = $"Short Description {i}", ShortContent = $"Short content {i}", UrlSlug = $"Url Slug {i}", CategoryId = 1, PostContent = $"Post content {i}" };
                context.Posts.Add(post);
                context.SaveChanges();
            }
            for (int i = 0; i < 3; i++)
            {
                var tag = new Tag() { Name = $"Name {i}", UrlSlug = $"Url slug {i}", Description = $"Description {i}" };
                context.Tags.Add(tag);
                context.SaveChanges();
            }

        }
    }
}
