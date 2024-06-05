using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.Social
{
    /// <inheritdoc />
    public partial class Rename_PhotoFileProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                schema: "Social",
                table: "Photos",
                newName: "File");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                schema: "Social",
                table: "Photos",
                newName: "FilePath");
        }
    }
}
