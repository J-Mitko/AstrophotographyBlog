namespace AstrophotographyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerequeriedfieldinuserdisplayname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DisplayName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "Country", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Country", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.AspNetUsers", "DisplayName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
