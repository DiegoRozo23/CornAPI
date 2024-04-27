using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Contro_Plagas.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    IdSupplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuppplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.IdSupplier);
                });

            migrationBuilder.CreateTable(
                name: "TypeCrop",
                columns: table => new
                {
                    IdTypeCrop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCropName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCrop", x => x.IdTypeCrop);
                });

            migrationBuilder.CreateTable(
                name: "TypePlague",
                columns: table => new
                {
                    IdTypePlague = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePlagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePlague", x => x.IdTypePlague);
                });

            migrationBuilder.CreateTable(
                name: "TypeUser",
                columns: table => new
                {
                    IdTypeUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUser", x => x.IdTypeUser);
                });

            migrationBuilder.CreateTable(
                name: "Pesticide",
                columns: table => new
                {
                    IdPesticide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSupplier = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesticide", x => x.IdPesticide);
                    table.ForeignKey(
                        name: "FK_Pesticide_Supplier_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Supplier",
                        principalColumn: "IdSupplier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plague",
                columns: table => new
                {
                    IdPlague = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypePlague = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plague", x => x.IdPlague);
                    table.ForeignKey(
                        name: "FK_Plague_TypePlague_IdTypePlague",
                        column: x => x.IdTypePlague,
                        principalTable: "TypePlague",
                        principalColumn: "IdTypePlague",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypeUser = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_TypeUser_IdTypeUser",
                        column: x => x.IdTypeUser,
                        principalTable: "TypeUser",
                        principalColumn: "IdTypeUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    IdCrop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdTypeCrop = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.IdCrop);
                    table.ForeignKey(
                        name: "FK_Crop_TypeCrop_IdTypeCrop",
                        column: x => x.IdTypeCrop,
                        principalTable: "TypeCrop",
                        principalColumn: "IdTypeCrop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crop_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvolutionCrop",
                columns: table => new
                {
                    IdEvolutionCrop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Record = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCrop = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionCrop", x => x.IdEvolutionCrop);
                    table.ForeignKey(
                        name: "FK_EvolutionCrop_Crop_IdCrop",
                        column: x => x.IdCrop,
                        principalTable: "Crop",
                        principalColumn: "IdCrop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extermination",
                columns: table => new
                {
                    IdExtermination = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Record = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCrop = table.Column<int>(type: "int", nullable: false),
                    IdPlague = table.Column<int>(type: "int", nullable: false),
                    IdPesticide = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extermination", x => x.IdExtermination);
                    table.ForeignKey(
                        name: "FK_Extermination_Crop_IdCrop",
                        column: x => x.IdCrop,
                        principalTable: "Crop",
                        principalColumn: "IdCrop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extermination_Pesticide_IdPesticide",
                        column: x => x.IdPesticide,
                        principalTable: "Pesticide",
                        principalColumn: "IdPesticide",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extermination_Plague_IdPlague",
                        column: x => x.IdPlague,
                        principalTable: "Plague",
                        principalColumn: "IdPlague",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crop_IdTypeCrop",
                table: "Crop",
                column: "IdTypeCrop");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_IdUser",
                table: "Crop",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionCrop_IdCrop",
                table: "EvolutionCrop",
                column: "IdCrop");

            migrationBuilder.CreateIndex(
                name: "IX_Extermination_IdCrop",
                table: "Extermination",
                column: "IdCrop");

            migrationBuilder.CreateIndex(
                name: "IX_Extermination_IdPesticide",
                table: "Extermination",
                column: "IdPesticide");

            migrationBuilder.CreateIndex(
                name: "IX_Extermination_IdPlague",
                table: "Extermination",
                column: "IdPlague");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticide_IdSupplier",
                table: "Pesticide",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Plague_IdTypePlague",
                table: "Plague",
                column: "IdTypePlague");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdTypeUser",
                table: "User",
                column: "IdTypeUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvolutionCrop");

            migrationBuilder.DropTable(
                name: "Extermination");

            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropTable(
                name: "Pesticide");

            migrationBuilder.DropTable(
                name: "Plague");

            migrationBuilder.DropTable(
                name: "TypeCrop");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "TypePlague");

            migrationBuilder.DropTable(
                name: "TypeUser");
        }
    }
}
