namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostContent", c => c.String());
            DropColumn("dbo.Posts", "Rate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Rate", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Posts", "PostContent");
        }
    }
}
