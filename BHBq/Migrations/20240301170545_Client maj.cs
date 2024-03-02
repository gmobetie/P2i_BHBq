using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class Clientmaj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntreprise",
                table: "Projets");

            migrationBuilder.RenameColumn(
                name: "Particulier",
                table: "Clients",
                newName: "Categorie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categorie",
                table: "Clients",
                newName: "Particulier");

            migrationBuilder.AddColumn<int>(
                name: "IdEntreprise",
                table: "Projets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
