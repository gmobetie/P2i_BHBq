using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHBq.Migrations
{
    /// <inheritdoc />
    public partial class Parametremaj4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Origine",
                table: "Parametres",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origine",
                table: "Parametres");
        }
    }
}
