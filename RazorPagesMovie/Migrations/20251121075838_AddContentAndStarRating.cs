using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddContentAndStarRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movie",
                newName: "ContentRating");

            migrationBuilder.RenameColumn(
                name: "PosterPath",
                table: "Movie",
                newName: "PosterUrl");

            migrationBuilder.AddColumn<double>(
                name: "StarRating",
                table: "Movie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarRating",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "PosterUrl",
                table: "Movie",
                newName: "PosterPath");

            migrationBuilder.RenameColumn(
                name: "ContentRating",
                table: "Movie",
                newName: "Rating");
        }
    }
}
