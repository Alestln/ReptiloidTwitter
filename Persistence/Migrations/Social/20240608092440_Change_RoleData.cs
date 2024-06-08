using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Change_RoleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Social",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00e73241-8b69-4076-a7bd-734c6eb04767"));

            migrationBuilder.DeleteData(
                schema: "Social",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9cd41c07-090f-4f39-bd72-e4cab367445e"));

            migrationBuilder.InsertData(
                schema: "Social",
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("6db03773-9569-4db5-9b83-461d6dfcffba"), "User" },
                    { new Guid("9b13c3e9-a4bd-4afe-a7ae-b9c60e6265e0"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Social",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6db03773-9569-4db5-9b83-461d6dfcffba"));

            migrationBuilder.DeleteData(
                schema: "Social",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b13c3e9-a4bd-4afe-a7ae-b9c60e6265e0"));

            migrationBuilder.InsertData(
                schema: "Social",
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("00e73241-8b69-4076-a7bd-734c6eb04767"), "User" },
                    { new Guid("9cd41c07-090f-4f39-bd72-e4cab367445e"), "Admin" }
                });
        }
    }
}
