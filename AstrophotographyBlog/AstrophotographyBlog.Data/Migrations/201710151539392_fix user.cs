namespace AstrophotographyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropColumn("dbo.AspNetUsers", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Country", c => c.String(maxLength: 3));
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String(maxLength: 50));
        }
    }
}
