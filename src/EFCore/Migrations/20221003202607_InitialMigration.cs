using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "Address", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 9, "42240 O'Hara Brook", "Jade McLaughlin", "1-743-688-5545" },
                    { 10, "9929 Stiedemann Overpass", "Hallie Becker", "921-899-9386 x84166" },
                    { 11, "299 Russel Ports", "Eduardo Nikolaus", "359.891.4416 x332" },
                    { 12, "92204 Norwood Summit", "Clay Erdman", "1-757-609-3098" },
                    { 13, "2826 Jacinto Ramp", "Alberto Weissnat", "459-583-7295 x5350" },
                    { 14, "106 Runte Radial", "Icie Romaguera", "929-468-7877 x06312" },
                    { 15, "63835 Mary Spring", "Marlin Kiehn", "1-280-620-7883" },
                    { 16, "909 Weimann Vista", "Dion Kessler", "617-985-3966 x32492" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
