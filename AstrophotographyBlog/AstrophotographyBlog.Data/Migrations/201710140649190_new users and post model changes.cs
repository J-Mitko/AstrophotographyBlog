namespace AstrophotographyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newusersandpostmodelchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ImageTarget", c => c.String());
            AddColumn("dbo.Posts", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "MainUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CountryCode", c => c.String(maxLength: 3));
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "MainUser_Id");
            AddForeignKey("dbo.Posts", "MainUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "MainUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "MainUser_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropColumn("dbo.AspNetUsers", "CountryCode");
            DropColumn("dbo.Posts", "MainUser_Id");
            DropColumn("dbo.Posts", "Time");
            DropColumn("dbo.Posts", "ImageTarget");
        }
    }
}
