using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Contro_Plagas.Migrations
{
    /// <inheritdoc />
    public partial class Fix_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plague",
                newName: "PlagueName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlagueName",
                table: "Plague",
                newName: "Name");
        }
    }
}
