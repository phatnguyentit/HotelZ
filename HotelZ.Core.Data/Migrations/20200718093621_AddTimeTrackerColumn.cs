using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelZ.Core.Data.Migrations
{
    public partial class AddTimeTrackerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "RoomTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "RoomTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Rooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Rooms",
                nullable: true);


            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetUsers");
        }
    }
}
