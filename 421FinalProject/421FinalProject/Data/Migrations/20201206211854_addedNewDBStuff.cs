using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _421FinalProject.Data.Migrations
{
    public partial class addedNewDBStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageA",
                table: "Location",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageB",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageC",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageD",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationKey",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficialSite",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageA",
                table: "GenInfo",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageB",
                table: "GenInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationKey",
                table: "GenInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficialSite",
                table: "GenInfo",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageA",
                table: "Destination",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageB",
                table: "Destination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageC",
                table: "Destination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageD",
                table: "Destination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationKey",
                table: "Destination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficialSite",
                table: "Destination",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageA",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "ImageB",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "ImageC",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "ImageD",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LocationKey",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "OfficialSite",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "ImageA",
                table: "GenInfo");

            migrationBuilder.DropColumn(
                name: "ImageB",
                table: "GenInfo");

            migrationBuilder.DropColumn(
                name: "LocationKey",
                table: "GenInfo");

            migrationBuilder.DropColumn(
                name: "OfficialSite",
                table: "GenInfo");

            migrationBuilder.DropColumn(
                name: "ImageA",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "ImageB",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "ImageC",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "ImageD",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "LocationKey",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "OfficialSite",
                table: "Destination");
        }
    }
}
