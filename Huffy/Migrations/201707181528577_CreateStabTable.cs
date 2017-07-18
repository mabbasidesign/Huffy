namespace Huffy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStabTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stabs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artist_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stabs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Stabs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Stabs", new[] { "Genre_Id" });
            DropIndex("dbo.Stabs", new[] { "Artist_Id" });
            DropTable("dbo.Stabs");
            DropTable("dbo.Genres");
        }
    }
}
