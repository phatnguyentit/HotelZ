using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelZ.Core.Data.Migrations
{
    public partial class AddTimeTrackerForRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "AspNetUserTokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "AspNetUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
               name: "CreatedDateTime",
               table: "AspNetRoleClaims",
               nullable: false,
               defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "AspNetRoleClaims",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
               name: "CreatedDateTime",
               table: "AspNetUserLogins",
               nullable: false,
               defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "AspNetUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
              name: "CreatedDateTime",
              table: "AspNetUserClaims",
              nullable: false,
              defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "AspNetUserClaims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "AspNetUserTokens");

        }
    }
}
