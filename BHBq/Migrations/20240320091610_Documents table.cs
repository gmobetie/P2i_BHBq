using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class Documentstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    IdProjet = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAcompte = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTVA = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEntreprise = table.Column<int>(type: "INTEGER", nullable: false),
                    Escompte = table.Column<bool>(type: "INTEGER", nullable: false),
                    Origine = table.Column<int>(type: "INTEGER", nullable: false),
                    Num = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
