namespace AstrophotographyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestouserandpostmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "MainUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "MainUser_Id" });
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Posts", name: "IX_Author_Id", newName: "IX_AuthorId");
            AddColumn("dbo.AspNetUsers", "Country", c => c.String(maxLength: 3));
            AlterColumn("dbo.AspNetUsers", "DisplayName", c => c.String( maxLength: 50));
            DropColumn("dbo.AspNetUsers", "CountryCode");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Posts", "MainUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "MainUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CountryCode", c => c.String(maxLength: 3));
            AlterColumn("dbo.AspNetUsers", "DisplayName", c => c.String(maxLength: 50));
            DropColumn("dbo.AspNetUsers", "Country");
            RenameIndex(table: "dbo.Posts", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Posts", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Posts", "MainUser_Id");
            AddForeignKey("dbo.Posts", "MainUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
