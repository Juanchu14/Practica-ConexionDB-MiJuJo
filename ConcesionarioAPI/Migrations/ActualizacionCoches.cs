using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConcesionarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarCochesReales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "Id", "ImagenUrl", "Nombre", "Stock" },
                values: new object[,]
                {
                    { 1, "/imagenes/a45.png", "Mercedes-Benz A45 AMG", 3 },
                    { 2, "/imagenes/c63.png", "Mercedes-Benz C63 AMG", 2 },
                    { 3, "/imagenes/cla45.png", "Mercedes-Benz CLA 45 AMG", 4 },
                    { 4, "/imagenes/cls63.png", "Mercedes-Benz CLS 63 AMG", 1 },
                    { 5, "/imagenes/g63.png", "Mercedes-Benz G63 AMG", 2 },
                    { 6, "/imagenes/gle63.png", "Mercedes-Benz GLE 63 AMG", 3 },
                    { 7, "/imagenes/gls.png", "Mercedes-Benz GLS", 5 },
                    { 8, "/imagenes/gt63.png", "Mercedes-AMG GT 63", 1 },
                    { 9, "/imagenes/maybach.png", "Mercedes-Maybach", 1 },
                    { 10, "/imagenes/sls.png", "Mercedes-Benz SLS AMG", 1 },
                    { 11, "/imagenes/alpinab7.png", "BMW Alpina B7", 2 },
                    { 12, "/imagenes/i8.png", "BMW i8", 2 },
                    { 13, "/imagenes/m2.png", "BMW M2", 4 },
                    { 14, "/imagenes/m3competitiontouring.png", "BMW M3 Competition Touring", 3 },
                    { 15, "/imagenes/m4competition.png", "BMW M4 Competition", 3 },
                    { 16, "/imagenes/m5cs.png", "BMW M5 CS", 1 },
                    { 17, "/imagenes/m8competition.png", "BMW M8 Competition", 2 },
                    { 18, "/imagenes/serie8convertible.png", "BMW Serie 8 Convertible", 3 },
                    { 19, "/imagenes/xm.png", "BMW XM", 2 },
                    { 20, "/imagenes/z4m40i.png", "BMW Z4 M40i", 4 },
                    { 21, "/imagenes/q8e-tron.png", "Audi Q8 e-tron", 5 },
                    { 22, "/imagenes/r8.png", "Audi R8", 1 },
                    { 23, "/imagenes/rs3.png", "Audi RS3", 4 },
                    { 24, "/imagenes/rs5coupe.png", "Audi RS5 Coupe", 3 },
                    { 25, "/imagenes/rs6.png", "Audi RS6 Avant", 2 },
                    { 26, "/imagenes/rs7.png", "Audi RS7", 2 },
                    { 27, "/imagenes/rse-trongt.png", "Audi RS e-tron GT", 2 },
                    { 28, "/imagenes/rsq8.png", "Audi RSQ8", 3 },
                    { 29, "/imagenes/s8.png", "Audi S8", 2 },
                    { 30, "/imagenes/ttrs.png", "Audi TT RS", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
