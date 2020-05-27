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


             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelA',(SELECT ID FROM Makes WHERE Name = 'Make1'))");
             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelB',(SELECT ID FROM Makes WHERE Name = 'Make1'))");
             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelC',(SELECT ID FROM Makes WHERE Name = 'Make1'))");

             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelA',(SELECT ID FROM Makes WHERE Name = 'Make2'))");
             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelB',(SELECT ID FROM Makes WHERE Name = 'Make2'))");
             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelC',(SELECT ID FROM Makes WHERE Name = 'Make2'))");

             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelA',(SELECT ID FROM Makes WHERE Name = 'Make3'))");
             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelB',(SELECT ID FROM Makes WHERE Name = 'Make3'))");
             migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelC',(SELECT ID FROM Makes WHERE Name = 'Make3'))");

        }

        //Downgrading migration this method will be called
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Makes WHERE Name in ('Make1','Make2','Make3')");
            migrationBuilder.Sql("DELETE FROM Models Where MakeId In (Select Id From Makes Where Name = 'Make1' OR Name = 'Make2' OR Name = 'Make3')");
           

        }
    }
}
