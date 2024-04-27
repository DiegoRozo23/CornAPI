using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Contro_Plagas.Migrations
{
    /// <inheritdoc />
    public partial class InitialDesigner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pesticide",
                newName: "PesticideName");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "EvolutionCrop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PesticideName",
                table: "Pesticide",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "EvolutionCrop",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
