using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixGenreName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Ganres_GenreId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ganres",
                table: "Ganres");

            migrationBuilder.RenameTable(
                name: "Ganres",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Ganres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ganres",
                table: "Ganres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Ganres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Ganres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
