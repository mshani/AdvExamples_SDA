using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMCheckin.Migrations
{
    /// <inheritdoc />
    public partial class Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Cards",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Code",
                table: "Cards",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cards_Code",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Cards");
        }
    }
}
