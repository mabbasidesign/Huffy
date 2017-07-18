namespace Huffy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionForStabGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stabs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Stabs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Stabs", new[] { "Artist_Id" });
            DropIndex("dbo.Stabs", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Stabs", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Stabs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Stabs", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Stabs", "Artist_Id");
            CreateIndex("dbo.Stabs", "Genre_Id");
            AddForeignKey("dbo.Stabs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Stabs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stabs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Stabs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Stabs", new[] { "Genre_Id" });
            DropIndex("dbo.Stabs", new[] { "Artist_Id" });
            AlterColumn("dbo.Stabs", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Stabs", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Stabs", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Stabs", "Genre_Id");
            CreateIndex("dbo.Stabs", "Artist_Id");
            AddForeignKey("dbo.Stabs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Stabs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
