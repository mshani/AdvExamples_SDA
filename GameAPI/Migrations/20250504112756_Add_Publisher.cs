using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "VideoGames");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "VideoGames",
                newName: "CreatedTime");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "VideoGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Publishers_PublisherId",
                table: "VideoGames",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Publishers_PublisherId",
                table: "VideoGames");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "VideoGames");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "VideoGames",
                newName: "CreateTime");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "VideoGames",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
