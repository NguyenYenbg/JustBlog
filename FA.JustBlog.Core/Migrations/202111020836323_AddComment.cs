namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Modified", c => c.String());
            AddColumn("dbo.Posts", "ViewCount", c => c.Int());
            AddColumn("dbo.Posts", "RateCount", c => c.Int());
            AddColumn("dbo.Posts", "TotalRate", c => c.Int());
            AddColumn("dbo.Posts", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Rate");
            DropColumn("dbo.Posts", "TotalRate");
            DropColumn("dbo.Posts", "RateCount");
            DropColumn("dbo.Posts", "ViewCount");
            DropColumn("dbo.Posts", "Modified");
        }
    }
}
