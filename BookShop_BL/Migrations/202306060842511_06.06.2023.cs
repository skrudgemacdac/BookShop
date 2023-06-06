namespace BookShop_BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06062023 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String());
            DropColumn("dbo.Books", "AuthorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorName", c => c.String());
            DropColumn("dbo.Books", "Author");
        }
    }
}
