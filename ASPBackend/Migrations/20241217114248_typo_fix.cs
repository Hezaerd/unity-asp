using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPBackend.Migrations
{
    /// <inheritdoc />
    public partial class typo_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gems",
                table: "Users",
                newName: "Gems");

            migrationBuilder.RenameColumn(
                name: "coins",
                table: "Users",
                newName: "Coins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gems",
                table: "Users",
                newName: "gems");

            migrationBuilder.RenameColumn(
                name: "Coins",
                table: "Users",
                newName: "coins");
        }
    }
}
