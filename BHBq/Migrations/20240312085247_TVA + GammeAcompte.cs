using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class TVAGammeAcompte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GammesAcompte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pourcentage1 = table.Column<double>(type: "REAL", nullable: false),
                    Pourcentage2 = table.Column<double>(type: "REAL", nullable: false),
                    Pourcentage3 = table.Column<double>(type: "REAL", nullable: false),
                    Pourcentage4 = table.Column<double>(type: "REAL", nullable: false),
                    Pourcentage5 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GammesAcompte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Taux = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVAs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GammesAcompte");

            migrationBuilder.DropTable(
                name: "TVAs");
        }
    }
}
