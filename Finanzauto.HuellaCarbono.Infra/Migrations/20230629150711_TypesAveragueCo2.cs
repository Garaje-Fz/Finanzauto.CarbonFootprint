using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzauto.HuellaCarbono.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TypesAveragueCo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "averague",
                schema: "hhcc",
                table: "Types",
                newName: "averagueKm");

            migrationBuilder.AddColumn<string>(
                name: "averagueCo2",
                schema: "hhcc",
                table: "Types",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "hhcc",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 6, 29, 10, 7, 10, 992, DateTimeKind.Local).AddTicks(4450), new DateTime(2023, 6, 29, 10, 7, 10, 992, DateTimeKind.Local).AddTicks(4462) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "averagueCo2",
                schema: "hhcc",
                table: "Types");

            migrationBuilder.RenameColumn(
                name: "averagueKm",
                schema: "hhcc",
                table: "Types",
                newName: "averague");

            migrationBuilder.UpdateData(
                schema: "hhcc",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 5, 25, 15, 59, 4, 35, DateTimeKind.Local).AddTicks(7490), new DateTime(2023, 5, 25, 15, 59, 4, 35, DateTimeKind.Local).AddTicks(7523) });
        }
    }
}
