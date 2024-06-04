using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Add_PhotosToPostAndUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostPhoto",
                schema: "Social",
                columns: table => new
                {
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPhoto", x => new { x.PostId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_PostPhoto_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Social",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostPhoto_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "Social",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfilePhoto",
                schema: "Social",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfilePhoto", x => new { x.UserProfileId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_UserProfilePhoto_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Social",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfilePhoto_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "Social",
                        principalTable: "UserProfiles",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostPhoto_PhotoId",
                schema: "Social",
                table: "PostPhoto",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePhoto_PhotoId",
                schema: "Social",
                table: "UserProfilePhoto",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostPhoto",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "UserProfilePhoto",
                schema: "Social");
        }
    }
}
