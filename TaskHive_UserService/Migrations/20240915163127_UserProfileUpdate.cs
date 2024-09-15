using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskHive_UserService.Migrations
{
    /// <inheritdoc />
    public partial class UserProfileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastEditDate",
                table: "UserProfiles",
                newName: "LastUpdateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "UserProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "UserProfiles",
                newName: "LastEditDate");
        }
    }
}
