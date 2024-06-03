using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Add_Account_UserProfile_Photo_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Social");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Social",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "Social",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "Social",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    BirthdayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    AvatarId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Social",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Photos_AvatarId",
                        column: x => x.AvatarId,
                        principalSchema: "Social",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AvatarId",
                schema: "Social",
                table: "UserProfiles",
                column: "AvatarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "Photos",
                schema: "Social");
        }
    }
}
