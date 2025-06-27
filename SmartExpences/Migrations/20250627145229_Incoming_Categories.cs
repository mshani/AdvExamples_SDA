using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartExpenses.Migrations
{
    /// <inheritdoc />
    public partial class Incoming_Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Incomings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomings_CategoryId",
                table: "Incomings",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomings_Categories_CategoryId",
                table: "Incomings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomings_Categories_CategoryId",
                table: "Incomings");

            migrationBuilder.DropIndex(
                name: "IX_Incomings_CategoryId",
                table: "Incomings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Incomings");
        }
    }
}
