namespace Huffy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForienKeyPropertToStabs : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Stabs", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Stabs", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Stabs", name: "IX_Artist_Id", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Stabs", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Stabs", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Stabs", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Stabs", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Stabs", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
