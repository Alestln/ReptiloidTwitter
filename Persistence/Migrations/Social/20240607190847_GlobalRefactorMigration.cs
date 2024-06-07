using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class GlobalRefactorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                schema: "Social",
                table: "Photos",
                newName: "File");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                schema: "Social",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "Social",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Expires = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Social",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccount",
                schema: "Social",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccount", x => new { x.AccountId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleAccount_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Social",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAccount_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Social",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Social",
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("00e73241-8b69-4076-a7bd-734c6eb04767"), "User" },
                    { new Guid("9cd41c07-090f-4f39-bd72-e4cab367445e"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccount_RoleId",
                schema: "Social",
                table: "RoleAccount",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "RoleAccount",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Social");

            migrationBuilder.DropColumn(
                name: "Header",
                schema: "Social",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "File",
                schema: "Social",
                table: "Photos",
                newName: "FilePath");
        }
    }
}
