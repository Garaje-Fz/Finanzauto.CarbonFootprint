using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzauto.HuellaCarbono.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hhcc");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "hhcc",
                columns: table => new
                {
                    brnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brnName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brnId);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                schema: "hhcc",
                columns: table => new
                {
                    fueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fueName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.fueId);
                });

            migrationBuilder.CreateTable(
                name: "Identities",
                schema: "hhcc",
                columns: table => new
                {
                    idnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idnImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idnEquivalence = table.Column<double>(type: "float", nullable: false),
                    idnOrden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identities", x => x.idnId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "hhcc",
                columns: table => new
                {
                    typId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.typId);
                });

            migrationBuilder.CreateTable(
                name: "BrandTypes",
                schema: "hhcc",
                columns: table => new
                {
                    brtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brnId = table.Column<int>(type: "int", nullable: false),
                    typId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTypes", x => x.brtId);
                    table.ForeignKey(
                        name: "FK_BrandTypes_Brands_brnId",
                        column: x => x.brnId,
                        principalSchema: "hhcc",
                        principalTable: "Brands",
                        principalColumn: "brnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandTypes_Types_typId",
                        column: x => x.typId,
                        principalSchema: "hhcc",
                        principalTable: "Types",
                        principalColumn: "typId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                schema: "hhcc",
                columns: table => new
                {
                    linId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoFasecolda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    linYear = table.Column<int>(type: "int", nullable: false),
                    brnId = table.Column<int>(type: "int", nullable: false),
                    typId = table.Column<int>(type: "int", nullable: false),
                    fueId = table.Column<int>(type: "int", nullable: false),
                    linDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmisionesCO2GrKm = table.Column<string>(name: "EmisionesCO2_GrKm", type: "nvarchar(max)", nullable: false),
                    huellaCarbonoTonKm = table.Column<string>(name: "huellaCarbono_TonKm", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.linId);
                    table.ForeignKey(
                        name: "FK_Lines_Brands_brnId",
                        column: x => x.brnId,
                        principalSchema: "hhcc",
                        principalTable: "Brands",
                        principalColumn: "brnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lines_Fuels_fueId",
                        column: x => x.fueId,
                        principalSchema: "hhcc",
                        principalTable: "Fuels",
                        principalColumn: "fueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lines_Types_typId",
                        column: x => x.typId,
                        principalSchema: "hhcc",
                        principalTable: "Types",
                        principalColumn: "typId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "hhcc",
                table: "Identities",
                columns: new[] { "idnId", "idnDescription", "idnEquivalence", "idnImage", "idnName", "idnOrden" },
                values: new object[,]
                {
                    { 1, "Compensado con la siembra de 15 plántulas (árboles jóvenes) asumiendo una esperanza de vida de 10 años.", 15.0, "Arboles", "Compensacion en arboles.", 1 },
                    { 2, "Cargar 110352 teléfonos celulares inteligentes.", 110352.0, "Celulares.", "Consumo cargar celulares.", 2 },
                    { 3, "Realizar 9 viajes de Bogotá a San Andrés en avión..", 9.0, "Viajes.", "Consumo viajes a San Andres.", 3 },
                    { 4, "Mantener encendido 4,5 computadores durante 5 días a la semana, 9 horas al día, durante un año.", 4.5, "Computadores", "Consumo en computadores.", 4 },
                    { 5, "Producir 3,39 kg de carne de vaca.", 3.3900000000000001, "Carne", "Consumo en carne.", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandTypes_brnId",
                schema: "hhcc",
                table: "BrandTypes",
                column: "brnId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTypes_typId",
                schema: "hhcc",
                table: "BrandTypes",
                column: "typId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_brnId",
                schema: "hhcc",
                table: "Lines",
                column: "brnId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_fueId",
                schema: "hhcc",
                table: "Lines",
                column: "fueId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_typId",
                schema: "hhcc",
                table: "Lines",
                column: "typId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandTypes",
                schema: "hhcc");

            migrationBuilder.DropTable(
                name: "Identities",
                schema: "hhcc");

            migrationBuilder.DropTable(
                name: "Lines",
                schema: "hhcc");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "hhcc");

            migrationBuilder.DropTable(
                name: "Fuels",
                schema: "hhcc");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "hhcc");
        }
    }
}
