using FA.JustBlog.Core.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogContext : IdentityDbContext<AppUser>
    {
        //enable-migrations
        //Add-migration 'CreateDb'
        //update-database
        public JustBlogContext() : base("name=connectionString")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment>Comments {get;set;}
        public static JustBlogContext Create()
        {
            return new JustBlogContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Post>()
                .HasMany<Tag>(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(pt =>
                {
                    pt.MapLeftKey("PostId");
                    pt.MapRightKey("TagId");
                    pt.ToTable("PostTagMap");
                });
        }
    }
}
