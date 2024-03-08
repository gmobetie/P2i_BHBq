using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class Projetboolinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Init",
                table: "Projets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Init",
                table: "Projets");
        }
    }
}
