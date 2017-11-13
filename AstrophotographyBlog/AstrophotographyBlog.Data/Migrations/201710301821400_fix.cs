namespace AstrophotographyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "ImageTarget", c => c.String(maxLength: 50));
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Location", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Location", c => c.String());
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String());
            AlterColumn("dbo.Posts", "ImageTarget", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
    }
}
