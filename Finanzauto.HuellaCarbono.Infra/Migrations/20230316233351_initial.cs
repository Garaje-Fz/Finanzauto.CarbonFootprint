using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzauto.HuellaCarbono.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    typName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    averague = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.typId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "hhcc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Records",
                schema: "hhcc",
                columns: table => new
                {
                    recId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    linId = table.Column<int>(type: "int", nullable: false),
                    recKm = table.Column<int>(type: "int", nullable: false),
                    recEmisionGrKm = table.Column<double>(type: "float", nullable: false),
                    recEmisionTnKm = table.Column<double>(type: "float", nullable: false),
                    recCalculateTnKm = table.Column<double>(type: "float", nullable: false),
                    recCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.recId);
                    table.ForeignKey(
                        name: "FK_Records_Lines_linId",
                        column: x => x.linId,
                        principalSchema: "hhcc",
                        principalTable: "Lines",
                        principalColumn: "linId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "hhcc",
                table: "Identities",
                columns: new[] { "idnId", "idnDescription", "idnEquivalence", "idnImage", "idnOrden" },
                values: new object[,]
                {
                    { 1, "La huella de carbono por el uso de tu vehiculo lograría ser compensado con la siembra de @equivalence plántulas (árboles jóvenes) con una esperanza de vida de 10 años.", 15.0, "Arboles.png", 1 },
                    { 2, "La huella de carbono por el uso de tu vehiculo corresponde a cargar @equivalence teléfonos celulares inteligentes.", 110352.0, "Celulares.png", 2 },
                    { 3, "La huella de carbono por el uso de tu vehiculo corresponde a realizar aproximadamente @equivalence viajes de Bogotá a San Andrés en avión.", 9.0, "Viajes.png", 3 },
                    { 4, "La huella de carbono por el uso de tu vehiculo corresponde a mantener encendido aproximadamente @equivalence computadores durante 5 días a la semana, 9 horas al día, durante un año.", 4.5, "Computadores.png", 4 },
                    { 5, "La huella de carbono por el uso de tu vehiculo corresponde a producir @equivalence kg de carne de vaca.", 3.3900000000000001, "Carne.png", 5 }
                });

            migrationBuilder.InsertData(
                schema: "hhcc",
                table: "Users",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "State", "usrEmail", "usrLastName", "usrName", "usrPassword", "usrUserName" },
                values: new object[] { 1, new DateTime(2023, 3, 16, 18, 33, 51, 416, DateTimeKind.Local).AddTicks(6329), new DateTime(2023, 3, 16, 18, 33, 51, 416, DateTimeKind.Local).AddTicks(6340), true, "elgaraje@finanzauto.com.co", "S.A.", "Finanzauto", "NewEfRiB.#23", "DevNovedades" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Records_linId",
                schema: "hhcc",
                table: "Records",
                column: "linId");
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
                name: "Records",
                schema: "hhcc");

            migrationBuilder.DropTable(
                name: "Users",
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
