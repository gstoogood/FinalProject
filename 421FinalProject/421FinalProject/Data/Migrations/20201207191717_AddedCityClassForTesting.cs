using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject421.Data.Migrations
{
    public partial class AddedCityClassForTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    OfficialLanguage = table.Column<string>(nullable: false),
                    ImageA = table.Column<byte[]>(nullable: true),
                    ImageB = table.Column<byte[]>(nullable: true),
                    ImageC = table.Column<string>(nullable: true),
                    ImageD = table.Column<string>(nullable: true),
                    OfficialSite = table.Column<string>(nullable: true),
                    LocationKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
