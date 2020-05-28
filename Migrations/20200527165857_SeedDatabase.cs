using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        //Upgrading Migration this method will be called
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Make3')");

            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature1')");
            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature2')");
            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature3')");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelA-Feature1',(SELECT ID FROM Makes WHERE Name = 'Make1'),(SELECT ID FROM Feature WHERE Name = 'Feature1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelB-Feature1',(SELECT ID FROM Makes WHERE Name = 'Make1'),(SELECT ID FROM Feature WHERE Name = 'Feature1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelC-Feature1',(SELECT ID FROM Makes WHERE Name = 'Make1'),(SELECT ID FROM Feature WHERE Name = 'Feature1'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelA-Feature2',(SELECT ID FROM Makes WHERE Name = 'Make2'),(SELECT ID FROM Feature WHERE Name = 'Feature2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelB-Feature2',(SELECT ID FROM Makes WHERE Name = 'Make2'),(SELECT ID FROM Feature WHERE Name = 'Feature2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelC-Feature2',(SELECT ID FROM Makes WHERE Name = 'Make2'),(SELECT ID FROM Feature WHERE Name = 'Feature2'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelA-Feature3',(SELECT ID FROM Makes WHERE Name = 'Make3'),(SELECT ID FROM Feature WHERE Name = 'Feature3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelB-Feature3',(SELECT ID FROM Makes WHERE Name = 'Make3'),(SELECT ID FROM Feature WHERE Name = 'Feature3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelC-Feature3',(SELECT ID FROM Makes WHERE Name = 'Make3'),(SELECT ID FROM Feature WHERE Name = 'Feature3'))");

        }

        //Downgrading migration this method will be called
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Models");    
            migrationBuilder.Sql("DELETE FROM Makes");
            migrationBuilder.Sql("DELETE FROM Features");
            
           

        }
    }
}
