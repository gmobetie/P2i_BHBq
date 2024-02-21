using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class CompteBancaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComptesBancaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdEntreprise = table.Column<int>(type: "INTEGER", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    IBAN = table.Column<string>(type: "TEXT", nullable: false),
                    BIC = table.Column<string>(type: "TEXT", nullable: false),
                    NumCompte = table.Column<string>(type: "TEXT", nullable: false),
                    NomBanque = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesBancaires", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComptesBancaires");
        }
    }
}
