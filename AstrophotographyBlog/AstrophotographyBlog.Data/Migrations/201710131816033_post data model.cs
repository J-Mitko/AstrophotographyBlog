namespace AstrophotographyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postdatamodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ImageUrl", c => c.String());
            AddColumn("dbo.Posts", "ImageInfo", c => c.String());
            AddColumn("dbo.Posts", "Location", c => c.String());
            DropColumn("dbo.Posts", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Content", c => c.String());
            DropColumn("dbo.Posts", "Location");
            DropColumn("dbo.Posts", "ImageInfo");
            DropColumn("dbo.Posts", "ImageUrl");
        }
    }
}
