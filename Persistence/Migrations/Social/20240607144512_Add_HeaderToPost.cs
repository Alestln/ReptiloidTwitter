using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Add_HeaderToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                schema: "Social",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                schema: "Social",
                table: "Posts");
        }
    }
}
