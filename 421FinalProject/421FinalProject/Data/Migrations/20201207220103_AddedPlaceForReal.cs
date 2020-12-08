using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject421.Data.Migrations
{
    public partial class AddedPlaceForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Subset = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ImageA = table.Column<byte[]>(nullable: false),
                    ImageB = table.Column<byte[]>(nullable: true),
                    OfficialSite = table.Column<string>(nullable: true),
                    LocationKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceID);
                    table.ForeignKey(
                        name: "FK_Place_City_Id",
                        column: x => x.Id,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Place_Id",
                table: "Place",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
