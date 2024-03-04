using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class Parametremaj3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormatCalcul",
                table: "Articles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormatCalcul",
                table: "Articles");
        }
    }
}
