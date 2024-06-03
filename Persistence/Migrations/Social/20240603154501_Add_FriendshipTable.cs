using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Add_FriendshipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendship",
                schema: "Social",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FriendId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => new { x.UserId, x.FriendId });
                    table.CheckConstraint("CHK_Friendship_UserId_FriendId", "\"UserId\" != \"FriendId\"");
                    table.ForeignKey(
                        name: "FK_Friendship_UserProfiles_FriendId",
                        column: x => x.FriendId,
                        principalSchema: "Social",
                        principalTable: "UserProfiles",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friendship_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalSchema: "Social",
                        principalTable: "UserProfiles",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_FriendId",
                schema: "Social",
                table: "Friendship",
                column: "FriendId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendship",
                schema: "Social");
        }
    }
}
