using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Add_FKToRefreshTokenToAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AccountId",
                schema: "Social",
                table: "RefreshTokens",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Accounts_AccountId",
                schema: "Social",
                table: "RefreshTokens",
                column: "AccountId",
                principalSchema: "Social",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Accounts_AccountId",
                schema: "Social",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_AccountId",
                schema: "Social",
                table: "RefreshTokens");
        }
    }
}
