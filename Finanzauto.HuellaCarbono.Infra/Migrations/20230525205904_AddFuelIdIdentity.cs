using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzauto.HuellaCarbono.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelIdIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "hhcc",
                table: "Identities",
                keyColumn: "idnId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "hhcc",
                table: "Identities",
                keyColumn: "idnId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "hhcc",
                table: "Identities",
                keyColumn: "idnId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "hhcc",
                table: "Identities",
                keyColumn: "idnId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "hhcc",
                table: "Identities",
                keyColumn: "idnId",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "fueId",
                schema: "hhcc",
                table: "Identities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "hhcc",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 5, 25, 15, 59, 4, 35, DateTimeKind.Local).AddTicks(7490), new DateTime(2023, 5, 25, 15, 59, 4, 35, DateTimeKind.Local).AddTicks(7523) });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_fueId",
                schema: "hhcc",
                table: "Identities",
                column: "fueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Fuels_fueId",
                schema: "hhcc",
                table: "Identities",
                column: "fueId",
                principalSchema: "hhcc",
                principalTable: "Fuels",
                principalColumn: "fueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Fuels_fueId",
                schema: "hhcc",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "IX_Identities_fueId",
                schema: "hhcc",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "fueId",
                schema: "hhcc",
                table: "Identities");

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

            migrationBuilder.UpdateData(
                schema: "hhcc",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 3, 16, 18, 33, 51, 416, DateTimeKind.Local).AddTicks(6329), new DateTime(2023, 3, 16, 18, 33, 51, 416, DateTimeKind.Local).AddTicks(6340) });
        }
    }
}
