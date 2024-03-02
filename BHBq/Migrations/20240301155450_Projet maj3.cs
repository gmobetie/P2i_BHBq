using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class Projetmaj3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomProjet",
                table: "Projets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "DateCreation",
                table: "Projets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Etat",
                table: "Projets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "Etat",
                table: "Projets");

            migrationBuilder.AlterColumn<string>(
                name: "NomProjet",
                table: "Projets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
