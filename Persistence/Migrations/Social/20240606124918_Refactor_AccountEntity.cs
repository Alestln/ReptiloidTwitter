using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Refactor_AccountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccount_Role_RoleId",
                schema: "Social",
                table: "RoleAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "Social",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Social",
                newName: "Roles",
                newSchema: "Social");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "Social",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccount_Roles_RoleId",
                schema: "Social",
                table: "RoleAccount",
                column: "RoleId",
                principalSchema: "Social",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccount_Roles_RoleId",
                schema: "Social",
                table: "RoleAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "Social",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Social",
                newName: "Role",
                newSchema: "Social");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "Social",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccount_Role_RoleId",
                schema: "Social",
                table: "RoleAccount",
                column: "RoleId",
                principalSchema: "Social",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
