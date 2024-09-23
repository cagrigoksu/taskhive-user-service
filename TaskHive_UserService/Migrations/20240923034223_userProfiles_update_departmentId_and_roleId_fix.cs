using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskHive_UserService.Migrations
{
    /// <inheritdoc />
    public partial class userProfiles_update_departmentId_and_roleId_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserProfiles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "UserProfiles",
                newName: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserProfiles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "UserProfiles",
                newName: "Department");
        }
    }
}
