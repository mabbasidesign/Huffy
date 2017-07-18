namespace Huffy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoPulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Jazz')");
        }
        
        public override void Down()
        {
            //Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");

        }
    }
}
