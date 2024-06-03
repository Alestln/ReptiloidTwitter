using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Refactor_PostComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                schema: "Social",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_UserProfiles_UserId",
                schema: "Social",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostComments",
                schema: "Social",
                table: "PostComments");

            migrationBuilder.RenameTable(
                name: "PostComments",
                schema: "Social",
                newName: "PostComment",
                newSchema: "Social");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_UserId",
                schema: "Social",
                table: "PostComment",
                newName: "IX_PostComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_PostId",
                schema: "Social",
                table: "PostComment",
                newName: "IX_PostComment_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostComment",
                schema: "Social",
                table: "PostComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_Posts_PostId",
                schema: "Social",
                table: "PostComment",
                column: "PostId",
                principalSchema: "Social",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_UserProfiles_UserId",
                schema: "Social",
                table: "PostComment",
                column: "UserId",
                principalSchema: "Social",
                principalTable: "UserProfiles",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_Posts_PostId",
                schema: "Social",
                table: "PostComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_UserProfiles_UserId",
                schema: "Social",
                table: "PostComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostComment",
                schema: "Social",
                table: "PostComment");

            migrationBuilder.RenameTable(
                name: "PostComment",
                schema: "Social",
                newName: "PostComments",
                newSchema: "Social");

            migrationBuilder.RenameIndex(
                name: "IX_PostComment_UserId",
                schema: "Social",
                table: "PostComments",
                newName: "IX_PostComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostComment_PostId",
                schema: "Social",
                table: "PostComments",
                newName: "IX_PostComments_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostComments",
                schema: "Social",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                schema: "Social",
                table: "PostComments",
                column: "PostId",
                principalSchema: "Social",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_UserProfiles_UserId",
                schema: "Social",
                table: "PostComments",
                column: "UserId",
                principalSchema: "Social",
                principalTable: "UserProfiles",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
