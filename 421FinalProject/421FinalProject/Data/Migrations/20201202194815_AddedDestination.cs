using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject421.Data.Migrations
{
    public partial class AddedDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    OfficialLanguage = table.Column<string>(nullable: false),
                    Image1 = table.Column<byte[]>(nullable: false),
                    Image2 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestID);
                });

            migrationBuilder.CreateTable(
                name: "GenInfo",
                columns: table => new
                {
                    GenInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    subTitle = table.Column<string>(nullable: true),
                    TextItem1 = table.Column<string>(nullable: false),
                    TextItem2 = table.Column<string>(nullable: true),
                    Image1 = table.Column<byte[]>(nullable: false),
                    Image2 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenInfo", x => x.GenInfoID);
                    table.ForeignKey(
                        name: "FK_GenInfo_Destination_DestID",
                        column: x => x.DestID,
                        principalTable: "Destination",
                        principalColumn: "DestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestID = table.Column<int>(nullable: false),
                    Subset = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PriceRange = table.Column<string>(nullable: false),
                    Image1 = table.Column<byte[]>(nullable: false),
                    Image2 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocID);
                    table.ForeignKey(
                        name: "FK_Location_Destination_DestID",
                        column: x => x.DestID,
                        principalTable: "Destination",
                        principalColumn: "DestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenInfo_DestID",
                table: "GenInfo",
                column: "DestID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DestID",
                table: "Location",
                column: "DestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenInfo");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
