using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "ImagenUrl",
                value: "/images/Peperonni.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "ImagenUrl",
                value: "/images/JamonDeluxe.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "ImagenUrl",
                value: "/images/Mixta.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "ImagenUrl",
                value: "/images/Hawaiana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "ImagenUrl",
                value: "/images/FamiliarEspecial.webp");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 6,
                column: "ImagenUrl",
                value: "/images/IndividualItaliana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 7,
                column: "ImagenUrl",
                value: "/images/Vegetariana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 8,
                column: "ImagenUrl",
                value: "/images/Barbacoa.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 9,
                column: "ImagenUrl",
                value: "/images/Napolitana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 10,
                column: "ImagenUrl",
                value: "/images/CuatroQuesos.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 14,
                column: "ImagenUrl",
                value: "/images/Agua.webp");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 15,
                column: "ImagenUrl",
                value: "/images/CocaCola.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/pexels-polina-tankilevitch-4109083.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/JamonDeluxe.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/pexels-abrar-27874930.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Hawaiana.jpeg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Familiar.webp");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 6,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/IndividualItaliana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 7,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Vegetariana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 8,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Barbacoa(BBQ).jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 9,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Napolitana.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 10,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/CuatroQuesos.jpg");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 14,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Agua.webp");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 15,
                column: "ImagenUrl",
                value: "https://imagenespizza.blob.core.windows.net/pizza/Cocacola.webp");
        }
    }
}
