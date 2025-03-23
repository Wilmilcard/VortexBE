using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VortexBE.Domain.Migrations
{
    /// <inheritdoc />
    public partial class crearBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cine",
                columns: table => new
                {
                    CineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cine", x => x.CineId);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaId);
                    table.ForeignKey(
                        name: "FK_Sala_Cine_CineId",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "CineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    SesionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.SesionId);
                    table.ForeignKey(
                        name: "FK_Sesion_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcion",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcion", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funcion_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcion_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_Entrada_Funcion_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funcion",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pago_Entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entrada",
                        principalColumn: "EntradaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cine",
                columns: new[] { "CineId", "Ciudad", "CreatedAt", "CreatedBy", "Direccion", "Nombre", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Ibagué", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Centro Comercial Multicentro", "CineColombia", null },
                    { 2, "Medellín", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Av. Siempre Viva 742", "Cinemark", null },
                    { 3, "Cali", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Mall Plaza", "Royal Films", null },
                    { 4, "Barranquilla", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Centro Comercial Unicentro", "Royal Films", null },
                    { 5, "Cartagena", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Plaza Central", "Cinemark", null },
                    { 6, "Bogotá D.C.", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Centro Comercial Andino", "Multiplex Andino", null },
                    { 7, "Bucaramanga", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Cra. 50 #20-30", "CineColombia", null },
                    { 8, "Pereira", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Carrera 15 #45-67", "Cinemark", null },
                    { 9, "Manizales", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Av. 68 #22-15", "CineColombia", null },
                    { 10, "Cúcuta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Centro Comercial Ventura", "Cinemark", null }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "PeliculaId", "Clasificacion", "CreatedAt", "CreatedBy", "Descripcion", "Director", "Duracion", "FechaEstreno", "Genero", "PosterUrl", "Titulo", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "PG", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Nulla voluptate ratione laudantium veniam eius. At reiciendis maxime blanditiis. Modi nihil nulla nihil nisi aut quo quos. Ut architecto ipsum.", "Ridley Scott", 128, new DateTime(2020, 8, 2, 18, 50, 45, 418, DateTimeKind.Utc).AddTicks(8721), "Drama", "image-1", "Flow", null },
                    { 2, "NC-17", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "In qui et maxime. Non est eos sit id consequuntur alias repudiandae. Quidem aut saepe sed cupiditate sint minus non. Sunt quia alias omnis suscipit sequi aliquid nam quia aliquid. Id quibusdam dolore.", "Martin Scorsese", 107, new DateTime(2025, 5, 5, 15, 26, 7, 681, DateTimeKind.Utc).AddTicks(1450), "Drama", "image-2", "Superman", null },
                    { 3, "G", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "A excepturi praesentium possimus omnis distinctio omnis ipsam eos. Recusandae deserunt qui hic facilis hic aliquid voluptate. Non dolor saepe aspernatur dolore. Rem omnis accusantium deserunt rerum.", "Christopher Nolan", 91, new DateTime(2023, 11, 8, 0, 52, 26, 71, DateTimeKind.Utc).AddTicks(4221), "Terror", "image-3", "Star Wars III", null },
                    { 4, "PG-13", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Et doloribus deserunt. Ipsa fugiat repellat non quis ut sit sunt libero molestias. Sed atque ut neque. Fugiat amet non. Illum enim quo minus aut similique dolor.", "Quentin Tarantino", 109, new DateTime(2025, 3, 30, 19, 29, 14, 890, DateTimeKind.Utc).AddTicks(836), "Drama", "image-4", "Up", null },
                    { 5, "G", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "Temporibus fuga similique ipsa error consequuntur corporis eos. In mollitia esse in et itaque. Commodi voluptatem vel maxime praesentium minus suscipit eos voluptatem vel. Nostrum odit soluta ullam culpa iusto sit numquam nisi omnis. Nostrum neque ipsum qui.", "Christopher Nolan", 156, new DateTime(2022, 1, 23, 7, 13, 29, 999, DateTimeKind.Utc).AddTicks(1113), "Terror", "image-5", "Sin Limites", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "CreatedBy", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Rod_Kautzer" },
                    { 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Kimberly.Turner22" },
                    { 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Wiley_Walsh" },
                    { 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Delbert.Turner" },
                    { 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Magnolia15" },
                    { 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Emil_Cremin34" },
                    { 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Meaghan_Pacocha18" },
                    { 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Roy.Funk10" },
                    { 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Elisha21" },
                    { 10, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Aisha36" },
                    { 11, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Kariane78" },
                    { 12, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Una_Beier" },
                    { 13, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Laverna_Oberbrunner32" },
                    { 14, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Shawna0" },
                    { 15, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Quinn.Prosacco10" },
                    { 16, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Stone19" },
                    { 17, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Weston93" },
                    { 18, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Claudine9" },
                    { 19, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Katherine5" },
                    { 20, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Hayden_Nicolas99" },
                    { 21, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Mercedes.Lowe" },
                    { 22, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Mohammed15" },
                    { 23, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Dan.Feeney32" },
                    { 24, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Ona.Nicolas" },
                    { 25, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Bryce_Ferry43" },
                    { 26, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", "81DC9BDB52D04DC223B621240E3DD8B7", null, "Juan" }
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "SalaId", "Capacidad", "CineId", "CreatedAt", "CreatedBy", "Numero", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 200, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 2, 250, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 3, 100, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 4, 80, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 5, 250, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 6, 80, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 7, 100, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 8, 150, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 9, 100, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 10, 100, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 11, 80, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 12, 250, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 13, 150, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 14, 100, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 15, 250, 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 16, 150, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 17, 250, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 18, 200, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 19, 150, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 20, 80, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 21, 250, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 22, 200, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 23, 200, 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 24, 100, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 25, 200, 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 26, 150, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 27, 100, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 28, 250, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 29, 150, 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 30, 250, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 31, 250, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 32, 80, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 33, 100, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 34, 100, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 35, 200, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 36, 150, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 37, 150, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 38, 100, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 39, 80, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 40, 200, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 41, 100, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 42, 250, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 43, 80, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 44, 150, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 45, 250, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 46, 80, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 47, 100, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 48, 150, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 49, 80, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 50, 150, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 51, 150, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 52, 80, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 53, 80, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 54, 250, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 55, 80, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 56, 250, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 57, 200, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 58, 200, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 59, 200, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 60, 200, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 61, 80, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 62, 200, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 63, 200, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 64, 200, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 65, 200, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 66, 250, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 67, 200, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 68, 80, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 69, 150, 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 70, 250, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 71, 250, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 72, 250, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 73, 250, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 74, 150, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null },
                    { 75, 200, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 76, 150, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 77, 80, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 78, 250, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 79, 80, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 80, 80, 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 81, 200, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 82, 80, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 83, 250, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 84, 100, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 85, 200, 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 86, 150, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 87, 200, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 88, 150, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 89, 80, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 90, 250, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 91, 100, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 92, 250, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 93, 80, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 94, 250, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 95, 200, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 96, 250, 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 97, 80, 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 98, 200, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, null },
                    { 99, 100, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, null },
                    { 100, 200, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Funcion",
                columns: new[] { "FuncionId", "CreatedAt", "CreatedBy", "FechaHora", "PeliculaId", "Precio", "SalaId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 5, 15, 59, 55, 545, DateTimeKind.Utc).AddTicks(8739), 3, 16815m, 25, null },
                    { 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 4, 4, 44, 11, 461, DateTimeKind.Utc).AddTicks(9459), 2, 20467m, 96, null },
                    { 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 4, 23, 48, 27, 635, DateTimeKind.Utc).AddTicks(7507), 3, 12832m, 82, null },
                    { 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 11, 19, 54, 275, DateTimeKind.Utc).AddTicks(6094), 1, 24463m, 4, null },
                    { 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 26, 22, 6, 8, 638, DateTimeKind.Utc).AddTicks(8032), 2, 26341m, 71, null },
                    { 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 0, 2, 52, 423, DateTimeKind.Utc).AddTicks(5274), 3, 12738m, 59, null },
                    { 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 13, 2, 32, 57, 503, DateTimeKind.Utc).AddTicks(7867), 3, 30511m, 84, null },
                    { 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 22, 22, 56, 2, 910, DateTimeKind.Utc).AddTicks(3373), 3, 12135m, 17, null },
                    { 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 2, 45, 44, 194, DateTimeKind.Utc).AddTicks(3601), 1, 15248m, 43, null },
                    { 10, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 27, 11, 52, 27, 306, DateTimeKind.Utc).AddTicks(5990), 2, 46504m, 47, null },
                    { 11, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 10, 11, 21, 0, 448, DateTimeKind.Utc).AddTicks(7874), 2, 31044m, 56, null },
                    { 12, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 22, 14, 57, 35, 998, DateTimeKind.Utc).AddTicks(3183), 1, 18276m, 73, null },
                    { 13, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 16, 20, 25, 12, 486, DateTimeKind.Utc).AddTicks(7003), 1, 45234m, 32, null },
                    { 14, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 3, 43, 4, 236, DateTimeKind.Utc).AddTicks(5637), 1, 22849m, 30, null },
                    { 15, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 1, 16, 1, 36, 407, DateTimeKind.Utc).AddTicks(1568), 2, 49812m, 53, null },
                    { 16, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 28, 20, 40, 0, 886, DateTimeKind.Utc).AddTicks(6058), 2, 35454m, 5, null },
                    { 17, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 7, 20, 12, 41, 845, DateTimeKind.Utc).AddTicks(3467), 3, 48542m, 82, null },
                    { 18, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 12, 5, 43, 24, 610, DateTimeKind.Utc).AddTicks(8288), 2, 15808m, 57, null },
                    { 19, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 17, 7, 43, 36, 247, DateTimeKind.Utc).AddTicks(8901), 2, 22226m, 91, null },
                    { 20, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 14, 23, 31, 43, 615, DateTimeKind.Utc).AddTicks(4918), 3, 36508m, 94, null },
                    { 21, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 7, 19, 44, 55, 384, DateTimeKind.Utc).AddTicks(6316), 3, 40670m, 15, null },
                    { 22, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 10, 20, 36, 15, 75, DateTimeKind.Utc).AddTicks(3536), 1, 15443m, 58, null },
                    { 23, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 11, 26, 29, 942, DateTimeKind.Utc).AddTicks(1097), 3, 20682m, 86, null },
                    { 24, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 2, 20, 11, 53, 45, DateTimeKind.Utc).AddTicks(9131), 3, 24365m, 94, null },
                    { 25, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 6, 11, 26, 25, 928, DateTimeKind.Utc).AddTicks(7801), 1, 21619m, 95, null },
                    { 26, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 6, 20, 57, 9, 202, DateTimeKind.Utc).AddTicks(4441), 2, 25919m, 4, null },
                    { 27, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 21, 8, 49, 43, 379, DateTimeKind.Utc).AddTicks(1819), 3, 49115m, 73, null },
                    { 28, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 4, 44, 42, 111, DateTimeKind.Utc).AddTicks(5829), 1, 43763m, 82, null },
                    { 29, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 10, 10, 1, 42, 184, DateTimeKind.Utc).AddTicks(813), 2, 39990m, 56, null },
                    { 30, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 9, 13, 53, 22, 80, DateTimeKind.Utc).AddTicks(4683), 3, 23875m, 52, null },
                    { 31, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 30, 4, 53, 14, 516, DateTimeKind.Utc).AddTicks(3788), 3, 14450m, 33, null },
                    { 32, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 2, 3, 52, 313, DateTimeKind.Utc).AddTicks(1225), 2, 20243m, 97, null },
                    { 33, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 10, 15, 3, 36, 170, DateTimeKind.Utc).AddTicks(3474), 1, 49787m, 33, null },
                    { 34, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 20, 11, 44, 17, 182, DateTimeKind.Utc).AddTicks(89), 1, 25232m, 73, null },
                    { 35, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 13, 12, 39, 9, 17, DateTimeKind.Utc).AddTicks(7290), 3, 29778m, 50, null },
                    { 36, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 30, 1, 53, 27, 570, DateTimeKind.Utc).AddTicks(3036), 1, 46003m, 91, null },
                    { 37, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 28, 23, 54, 49, 17, DateTimeKind.Utc).AddTicks(3703), 1, 26485m, 63, null },
                    { 38, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 16, 16, 42, 41, 605, DateTimeKind.Utc).AddTicks(3324), 2, 21396m, 66, null },
                    { 39, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 12, 16, 20, 25, 532, DateTimeKind.Utc).AddTicks(5173), 3, 49693m, 32, null },
                    { 40, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 23, 53, 33, 617, DateTimeKind.Utc).AddTicks(456), 1, 23147m, 34, null },
                    { 41, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 8, 4, 40, 57, 528, DateTimeKind.Utc).AddTicks(8231), 1, 38483m, 23, null },
                    { 42, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 0, 41, 45, 264, DateTimeKind.Utc).AddTicks(2768), 3, 25304m, 9, null },
                    { 43, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 3, 50, 57, 821, DateTimeKind.Utc).AddTicks(4148), 2, 34628m, 20, null },
                    { 44, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 2, 11, 14, 27, 185, DateTimeKind.Utc).AddTicks(6414), 3, 29806m, 93, null },
                    { 45, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 30, 23, 22, 35, 70, DateTimeKind.Utc).AddTicks(5317), 2, 32328m, 23, null },
                    { 46, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 16, 22, 51, 29, 133, DateTimeKind.Utc).AddTicks(5008), 3, 17317m, 61, null },
                    { 47, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 16, 17, 12, 44, 87, DateTimeKind.Utc).AddTicks(1859), 1, 33885m, 37, null },
                    { 48, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 28, 2, 52, 22, 205, DateTimeKind.Utc).AddTicks(1687), 2, 29546m, 73, null },
                    { 49, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 1, 17, 45, 0, 742, DateTimeKind.Utc).AddTicks(6658), 1, 24938m, 90, null },
                    { 50, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 11, 4, 54, 8, 118, DateTimeKind.Utc).AddTicks(2915), 3, 43947m, 6, null },
                    { 51, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 2, 8, 8, 17, 114, DateTimeKind.Utc).AddTicks(2006), 1, 11167m, 56, null },
                    { 52, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 10, 8, 36, 55, 130, DateTimeKind.Utc).AddTicks(3028), 2, 13529m, 28, null },
                    { 53, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 24, 8, 52, 47, 49, DateTimeKind.Utc).AddTicks(1823), 1, 10851m, 75, null },
                    { 54, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 15, 4, 49, 18, 857, DateTimeKind.Utc).AddTicks(7253), 3, 39651m, 65, null },
                    { 55, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 1, 18, 43, 5, 141, DateTimeKind.Utc).AddTicks(5566), 2, 43780m, 44, null },
                    { 56, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 16, 2, 18, 29, 6, DateTimeKind.Utc).AddTicks(3496), 1, 19372m, 75, null },
                    { 57, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 30, 18, 2, 29, 756, DateTimeKind.Utc).AddTicks(1195), 2, 11488m, 77, null },
                    { 58, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 10, 42, 26, 102, DateTimeKind.Utc).AddTicks(9207), 2, 41630m, 76, null },
                    { 59, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 6, 19, 21, 22, 642, DateTimeKind.Utc).AddTicks(9589), 3, 49514m, 18, null },
                    { 60, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 13, 4, 29, 13, 52, DateTimeKind.Utc).AddTicks(1762), 1, 40540m, 30, null },
                    { 61, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 4, 7, 13, 28, 765, DateTimeKind.Utc).AddTicks(9692), 2, 36510m, 84, null },
                    { 62, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 1, 1, 38, 3, 306, DateTimeKind.Utc).AddTicks(8689), 1, 37310m, 33, null },
                    { 63, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 24, 10, 52, 25, 357, DateTimeKind.Utc).AddTicks(4560), 1, 31517m, 39, null },
                    { 64, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 9, 13, 42, 8, 73, DateTimeKind.Utc).AddTicks(3670), 3, 10942m, 34, null },
                    { 65, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 11, 0, 52, 3, 972, DateTimeKind.Utc).AddTicks(7146), 2, 43380m, 3, null },
                    { 66, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 31, 2, 20, 10, 46, DateTimeKind.Utc).AddTicks(4448), 2, 46808m, 97, null },
                    { 67, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 14, 19, 41, 12, 549, DateTimeKind.Utc).AddTicks(1235), 2, 30802m, 18, null },
                    { 68, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 25, 20, 49, 14, 315, DateTimeKind.Utc).AddTicks(4631), 1, 27305m, 7, null },
                    { 69, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 30, 13, 51, 54, 177, DateTimeKind.Utc).AddTicks(1803), 2, 28832m, 45, null },
                    { 70, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 7, 7, 43, 19, 130, DateTimeKind.Utc).AddTicks(3130), 3, 24374m, 18, null },
                    { 71, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 22, 14, 29, 57, 134, DateTimeKind.Utc).AddTicks(4024), 1, 41106m, 22, null },
                    { 72, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 8, 23, 57, 9, 497, DateTimeKind.Utc).AddTicks(643), 2, 33965m, 73, null },
                    { 73, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 31, 3, 19, 12, 902, DateTimeKind.Utc).AddTicks(1957), 3, 11815m, 12, null },
                    { 74, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 27, 9, 36, 9, 690, DateTimeKind.Utc).AddTicks(6932), 2, 47705m, 37, null },
                    { 75, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 28, 12, 16, 59, 941, DateTimeKind.Utc).AddTicks(1066), 1, 43315m, 61, null },
                    { 76, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 14, 2, 26, 25, 127, DateTimeKind.Utc).AddTicks(575), 2, 38621m, 58, null },
                    { 77, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 14, 8, 44, 35, 586, DateTimeKind.Utc).AddTicks(8616), 2, 38839m, 48, null },
                    { 78, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 24, 18, 52, 42, 587, DateTimeKind.Utc).AddTicks(9923), 2, 40193m, 60, null },
                    { 79, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 7, 13, 28, 247, DateTimeKind.Utc).AddTicks(2528), 2, 33420m, 43, null },
                    { 80, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 12, 15, 54, 37, 671, DateTimeKind.Utc).AddTicks(7953), 1, 17542m, 48, null },
                    { 81, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 13, 22, 54, 38, 833, DateTimeKind.Utc).AddTicks(4174), 1, 14705m, 39, null },
                    { 82, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 11, 5, 59, 2, 598, DateTimeKind.Utc).AddTicks(2890), 1, 33343m, 97, null },
                    { 83, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 23, 3, 44, 12, 254, DateTimeKind.Utc).AddTicks(530), 3, 27463m, 10, null },
                    { 84, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 1, 57, 55, 768, DateTimeKind.Utc).AddTicks(1923), 1, 24503m, 89, null },
                    { 85, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 4, 19, 3, 11, 177, DateTimeKind.Utc).AddTicks(3618), 1, 43184m, 17, null },
                    { 86, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 30, 16, 13, 29, 903, DateTimeKind.Utc).AddTicks(7363), 2, 45195m, 88, null },
                    { 87, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 27, 18, 40, 36, 681, DateTimeKind.Utc).AddTicks(8730), 3, 12083m, 74, null },
                    { 88, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 26, 0, 25, 0, 715, DateTimeKind.Utc).AddTicks(4524), 3, 12713m, 37, null },
                    { 89, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 29, 12, 25, 43, 723, DateTimeKind.Utc).AddTicks(4860), 2, 28756m, 33, null },
                    { 90, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 13, 19, 3, 41, 376, DateTimeKind.Utc).AddTicks(747), 3, 13918m, 63, null },
                    { 91, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 18, 1, 55, 54, 179, DateTimeKind.Utc).AddTicks(9021), 3, 22228m, 34, null },
                    { 92, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 15, 5, 41, 54, 487, DateTimeKind.Utc).AddTicks(3621), 2, 25034m, 58, null },
                    { 93, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 3, 21, 44, 43, 586, DateTimeKind.Utc).AddTicks(3448), 3, 10992m, 48, null },
                    { 94, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 12, 1, 3, 44, 220, DateTimeKind.Utc).AddTicks(8348), 3, 22534m, 79, null },
                    { 95, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 1, 6, 53, 3, 287, DateTimeKind.Utc).AddTicks(6630), 1, 26211m, 35, null },
                    { 96, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 21, 15, 25, 23, 702, DateTimeKind.Utc).AddTicks(2003), 1, 21912m, 38, null },
                    { 97, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 21, 10, 45, 27, 772, DateTimeKind.Utc).AddTicks(9295), 2, 39035m, 16, null },
                    { 98, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 10, 4, 14, 51, 814, DateTimeKind.Utc).AddTicks(9545), 2, 42777m, 18, null },
                    { 99, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 17, 8, 12, 34, 673, DateTimeKind.Utc).AddTicks(971), 3, 26706m, 72, null },
                    { 100, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 4, 13, 23, 10, 55, 804, DateTimeKind.Utc).AddTicks(3470), 2, 25092m, 76, null }
                });

            migrationBuilder.InsertData(
                table: "Entrada",
                columns: new[] { "EntradaId", "Cantidad", "CreatedAt", "CreatedBy", "FechaCompra", "FuncionId", "Total", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 28, 3, 35, 9, 156, DateTimeKind.Local).AddTicks(4049), 17, 117.366977249367360m, null, 5 },
                    { 2, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 14, 20, 1, 38, 916, DateTimeKind.Local).AddTicks(8537), 5, 90.544685439325560m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 20 },
                    { 3, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 19, 10, 14, 42, 186, DateTimeKind.Local).AddTicks(2570), 55, 44.356250814653760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 9 },
                    { 4, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 1, 5, 1, 43, 870, DateTimeKind.Local).AddTicks(2912), 54, 122.436704831897880m, null, 25 },
                    { 5, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 22, 0, 58, 50, 896, DateTimeKind.Local).AddTicks(2019), 95, 125.346344036225520m, null, 4 },
                    { 6, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 4, 14, 21, 5, 567, DateTimeKind.Local).AddTicks(4207), 51, 25.44951307429120m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 24 },
                    { 7, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 9, 23, 0, 20, 726, DateTimeKind.Local).AddTicks(989), 92, 20.875198379863520m, null, 24 },
                    { 8, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 12, 21, 29, 27, 17, DateTimeKind.Local).AddTicks(6604), 95, 65.358413559011840m, null, 17 },
                    { 9, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 9, 11, 5, 11, 390, DateTimeKind.Local).AddTicks(9034), 36, 243.528817379709400m, null, 24 },
                    { 10, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 7, 8, 41, 14, 476, DateTimeKind.Local).AddTicks(4311), 81, 92.503832747380400m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 25 },
                    { 11, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 3, 30, 4, 53, 16, 677, DateTimeKind.Local).AddTicks(4983), 16, 100.814326910529120m, null, 25 },
                    { 12, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 20, 1, 13, 53, 984, DateTimeKind.Local).AddTicks(9234), 31, 39.795940887855280m, null, 22 },
                    { 13, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 20, 22, 4, 42, 560, DateTimeKind.Local).AddTicks(9289), 3, 47.666837491997880m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 18 },
                    { 14, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 19, 14, 30, 31, 911, DateTimeKind.Local).AddTicks(5025), 21, 173.797284495373800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 10 },
                    { 15, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 10, 16, 52, 55, 622, DateTimeKind.Local).AddTicks(4304), 22, 47.738576579697960m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 4 },
                    { 16, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 20, 16, 33, 28, 102, DateTimeKind.Local).AddTicks(9172), 58, 98.22152478631000m, null, 20 },
                    { 17, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 3, 8, 48, 34, 280, DateTimeKind.Local).AddTicks(4980), 78, 72.011748295564800m, null, 23 },
                    { 18, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 6, 15, 20, 3, 479, DateTimeKind.Local).AddTicks(8348), 42, 99.822264706127800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 23 },
                    { 19, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 23, 7, 3, 28, 362, DateTimeKind.Local).AddTicks(6264), 63, 84.294369377179040m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 26 },
                    { 20, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 26, 23, 35, 49, 10, DateTimeKind.Local).AddTicks(275), 68, 218.842182933580800m, null, 6 },
                    { 21, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 31, 7, 0, 38, 366, DateTimeKind.Local).AddTicks(8198), 98, 45.684971143496640m, null, 2 },
                    { 22, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 12, 21, 34, 31, 192, DateTimeKind.Local).AddTicks(6174), 73, 66.924555384764880m, null, 1 },
                    { 23, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 6, 13, 0, 7, 760, DateTimeKind.Local).AddTicks(5906), 7, 80.17176302155600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 24 },
                    { 24, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 31, 5, 57, 18, 756, DateTimeKind.Local).AddTicks(8351), 79, 25.99327154961160m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 25, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 5, 18, 27, 22, 301, DateTimeKind.Local).AddTicks(7258), 2, 51.13219559125001800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 20 },
                    { 26, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 27, 4, 59, 3, 197, DateTimeKind.Local).AddTicks(1161), 27, 200.47702936553000m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 11 },
                    { 27, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 29, 17, 29, 13, 956, DateTimeKind.Local).AddTicks(7851), 83, 23.6809333483316720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 10 },
                    { 28, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 13, 8, 27, 49, 833, DateTimeKind.Local).AddTicks(432), 93, 176.49085768063200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 2 },
                    { 29, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 8, 7, 34, 51, 148, DateTimeKind.Local).AddTicks(9363), 78, 26.686154933594080m, null, 2 },
                    { 30, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 16, 8, 27, 11, 942, DateTimeKind.Local).AddTicks(8163), 55, 17.565649532803880m, null, 25 },
                    { 31, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 12, 6, 41, 31, 678, DateTimeKind.Local).AddTicks(4224), 4, 84.71249623687520m, null, 25 },
                    { 32, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 7, 9, 1, 41, 46, DateTimeKind.Local).AddTicks(7216), 15, 125.616131704121200m, null, 16 },
                    { 33, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 29, 15, 23, 39, 193, DateTimeKind.Local).AddTicks(5641), 100, 113.912554326082400m, null, 9 },
                    { 34, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 3, 24, 13, 33, 12, 529, DateTimeKind.Local).AddTicks(4692), 56, 98.589269786836720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 14 },
                    { 35, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 12, 22, 22, 46, 422, DateTimeKind.Local).AddTicks(6969), 9, 143.708167046386080m, null, 12 },
                    { 36, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 14, 10, 24, 24, 710, DateTimeKind.Local).AddTicks(6735), 14, 48.559057700975280m, null, 25 },
                    { 37, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 7, 0, 26, 48, 354, DateTimeKind.Local).AddTicks(6519), 55, 32.562554228556760m, null, 26 },
                    { 38, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 1, 18, 9, 7, 297, DateTimeKind.Local).AddTicks(4747), 71, 133.351229238123840m, null, 1 },
                    { 39, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 18, 13, 6, 31, 169, DateTimeKind.Local).AddTicks(8738), 47, 19.810280717063040m, null, 17 },
                    { 40, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 29, 19, 32, 45, 199, DateTimeKind.Local).AddTicks(5242), 9, 71.630520666718080m, null, 16 },
                    { 41, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 23, 4, 45, 46, 708, DateTimeKind.Local).AddTicks(7840), 66, 77.083271936253120m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 2 },
                    { 42, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 27, 16, 45, 34, 336, DateTimeKind.Local).AddTicks(1425), 75, 132.55568054343600m, null, 10 },
                    { 43, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 2, 7, 17, 55, 890, DateTimeKind.Local).AddTicks(376), 20, 134.7159601064200m, null, 10 },
                    { 44, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 28, 15, 57, 40, 3, DateTimeKind.Local).AddTicks(428), 52, 142.882897382694240m, null, 24 },
                    { 45, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 22, 4, 18, 8, 583, DateTimeKind.Local).AddTicks(7236), 45, 42.630001953809720m, null, 1 },
                    { 46, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 21, 5, 21, 39, 549, DateTimeKind.Local).AddTicks(1977), 59, 39.721166516293120m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 4 },
                    { 47, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 21, 16, 16, 51, 265, DateTimeKind.Local).AddTicks(2180), 58, 47.895217394928720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 17 },
                    { 48, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 4, 18, 16, 9, 292, DateTimeKind.Local).AddTicks(9497), 62, 92.675980993851000m, null, 6 },
                    { 49, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 3, 23, 7, 24, 98, DateTimeKind.Local).AddTicks(2619), 3, 125.41526976416960m, null, 1 },
                    { 50, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 1, 19, 51, 53, 537, DateTimeKind.Local).AddTicks(1609), 20, 47.500076488707360m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 8 },
                    { 51, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 10, 9, 22, 22, 295, DateTimeKind.Local).AddTicks(6707), 36, 61.406039075177280m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 52, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 6, 23, 29, 20, 295, DateTimeKind.Local).AddTicks(7830), 84, 109.419524101602720m, null, 6 },
                    { 53, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 13, 22, 25, 26, 479, DateTimeKind.Local).AddTicks(3399), 9, 23.771814549800280m, null, 25 },
                    { 54, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 8, 17, 35, 47, 710, DateTimeKind.Local).AddTicks(7505), 86, 60.120993223420080m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 11 },
                    { 55, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 14, 7, 33, 25, 742, DateTimeKind.Local).AddTicks(3831), 7, 49.948903664977200m, null, 22 },
                    { 56, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 1, 8, 54, 58, 750, DateTimeKind.Local).AddTicks(5378), 47, 178.016321650843600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 24 },
                    { 57, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 1, 18, 8, 30, 61, DateTimeKind.Local).AddTicks(1697), 21, 56.912136447628080m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 25 },
                    { 58, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 5, 2, 59, 33, 53, DateTimeKind.Local).AddTicks(3224), 87, 61.817170226073120m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 24 },
                    { 59, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 8, 21, 22, 48, 552, DateTimeKind.Local).AddTicks(5916), 25, 18.790935514346560m, null, 16 },
                    { 60, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 15, 15, 23, 40, 817, DateTimeKind.Local).AddTicks(3591), 93, 51.558565825343360m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 1 },
                    { 61, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 2, 9, 13, 32, 192, DateTimeKind.Local).AddTicks(2515), 72, 84.278607531325040m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 10 },
                    { 62, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 31, 5, 26, 43, 282, DateTimeKind.Local).AddTicks(5834), 41, 99.122304183196640m, null, 21 },
                    { 63, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 3, 31, 11, 50, 7, 537, DateTimeKind.Local).AddTicks(4138), 47, 48.868787892650080m, null, 18 },
                    { 64, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 2, 8, 13, 56, 693, DateTimeKind.Local).AddTicks(6948), 78, 27.427548637894320m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 2 },
                    { 65, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 6, 5, 58, 35, 344, DateTimeKind.Local).AddTicks(7119), 67, 71.156841671175840m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 7 },
                    { 66, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 6, 8, 12, 13, 203, DateTimeKind.Local).AddTicks(6523), 71, 37.205526734337440m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 16 },
                    { 67, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 7, 12, 9, 14, 961, DateTimeKind.Local).AddTicks(4253), 80, 38.367157539248560m, null, 17 },
                    { 68, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 27, 16, 1, 11, 351, DateTimeKind.Local).AddTicks(228), 51, 104.469073442859840m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 6 },
                    { 69, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 26, 13, 52, 24, 959, DateTimeKind.Local).AddTicks(2287), 17, 11.2842284455992200m, null, 17 },
                    { 70, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 26, 0, 13, 54, 555, DateTimeKind.Local).AddTicks(7019), 45, 55.724308652109280m, null, 16 },
                    { 71, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 16, 16, 34, 9, 536, DateTimeKind.Local).AddTicks(2835), 67, 102.446783376295200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 18 },
                    { 72, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 30, 20, 35, 47, 774, DateTimeKind.Local).AddTicks(1572), 30, 10.27080480498270280m, null, 1 },
                    { 73, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 3, 13, 13, 1, 6, DateTimeKind.Local).AddTicks(359), 99, 88.511477082683400m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 6 },
                    { 74, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 8, 11, 1, 46, 984, DateTimeKind.Local).AddTicks(8953), 20, 31.405192148351560m, null, 3 },
                    { 75, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 29, 22, 54, 4, 120, DateTimeKind.Local).AddTicks(6511), 16, 150.322452736123400m, null, 5 },
                    { 76, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 1, 16, 34, 9, 679, DateTimeKind.Local).AddTicks(7749), 69, 100.771870455541680m, null, 20 },
                    { 77, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 7, 6, 8, 58, 426, DateTimeKind.Local).AddTicks(7265), 61, 64.65454674554640m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 1 },
                    { 78, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 9, 4, 11, 34, 175, DateTimeKind.Local).AddTicks(3714), 76, 104.829264013490560m, null, 18 },
                    { 79, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 16, 19, 15, 34, 839, DateTimeKind.Local).AddTicks(8423), 93, 78.935991924870560m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 6 },
                    { 80, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 24, 20, 35, 15, 39, DateTimeKind.Local).AddTicks(3607), 11, 63.467659688970560m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 14 },
                    { 81, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 2, 17, 57, 38, 328, DateTimeKind.Local).AddTicks(5350), 80, 92.478300290491800m, null, 23 },
                    { 82, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 6, 15, 45, 58, 952, DateTimeKind.Local).AddTicks(8267), 43, 165.282248163844400m, null, 16 },
                    { 83, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 21, 4, 35, 28, 925, DateTimeKind.Local).AddTicks(3862), 20, 18.614073082528600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 84, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 14, 3, 43, 9, 330, DateTimeKind.Local).AddTicks(7192), 72, 229.631145906499000m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 16 },
                    { 85, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 25, 22, 12, 31, 121, DateTimeKind.Local).AddTicks(5621), 97, 36.8538834227159040m, null, 25 },
                    { 86, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 5, 5, 35, 26, 711, DateTimeKind.Local).AddTicks(5722), 65, 171.124739341342200m, null, 2 },
                    { 87, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 7, 10, 6, 24, 499, DateTimeKind.Local).AddTicks(6242), 69, 21.1290758161939040m, null, 5 },
                    { 88, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 30, 1, 24, 55, 906, DateTimeKind.Local).AddTicks(7441), 5, 97.944030142487760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 89, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 19, 20, 16, 42, 314, DateTimeKind.Local).AddTicks(1720), 46, 46.893961901170240m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 90, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 15, 13, 59, 33, 601, DateTimeKind.Local).AddTicks(8964), 97, 22.354188041366560m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 25 },
                    { 91, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 4, 9, 22, 48, 376, DateTimeKind.Local).AddTicks(3641), 23, 19.709436415531880m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 3 },
                    { 92, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 30, 16, 50, 24, 260, DateTimeKind.Local).AddTicks(3090), 24, 124.501954213391200m, null, 19 },
                    { 93, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 22, 11, 17, 4, 83, DateTimeKind.Local).AddTicks(3804), 95, 113.16190879592800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 25 },
                    { 94, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 7, 2, 13, 1, 419, DateTimeKind.Local).AddTicks(3183), 52, 87.08945722327120m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 23 },
                    { 95, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 10, 10, 15, 23, 87, DateTimeKind.Local).AddTicks(1352), 87, 140.647406234823000m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 13 },
                    { 96, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 19, 5, 30, 9, 653, DateTimeKind.Local).AddTicks(2339), 76, 26.409053641438720m, null, 7 },
                    { 97, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 1, 21, 19, 35, 692, DateTimeKind.Local).AddTicks(3225), 2, 61.210352560519680m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 8 },
                    { 98, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 2, 4, 35, 44, 8, DateTimeKind.Local).AddTicks(9797), 36, 26.029470344647840m, null, 9 },
                    { 99, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 20, 0, 59, 58, 470, DateTimeKind.Local).AddTicks(9051), 39, 183.460673345652480m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 100, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 13, 6, 43, 46, 467, DateTimeKind.Local).AddTicks(2305), 80, 28.113779626192960m, null, 16 },
                    { 101, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 4, 1, 45, 25, 266, DateTimeKind.Local).AddTicks(6778), 27, 63.669174219708560m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 7 },
                    { 102, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 16, 13, 44, 34, 594, DateTimeKind.Local).AddTicks(3661), 47, 177.110339393094720m, null, 12 },
                    { 103, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 24, 1, 34, 43, 359, DateTimeKind.Local).AddTicks(2137), 58, 22.018269766648080m, null, 9 },
                    { 104, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 22, 10, 54, 29, 585, DateTimeKind.Local).AddTicks(9361), 52, 86.907960449705760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 8 },
                    { 105, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 4, 17, 3, 25, 875, DateTimeKind.Local).AddTicks(8999), 92, 14.714443793305400m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 2 },
                    { 106, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 3, 18, 21, 21, 585, DateTimeKind.Local).AddTicks(6119), 4, 99.702830562146960m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 22 },
                    { 107, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 12, 8, 15, 0, 439, DateTimeKind.Local).AddTicks(2925), 68, 147.147878859445000m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 18 },
                    { 108, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 7, 22, 28, 48, 391, DateTimeKind.Local).AddTicks(7448), 21, 68.6848653855362600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 6 },
                    { 109, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 30, 17, 34, 15, 530, DateTimeKind.Local).AddTicks(6319), 97, 23.719486207234760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 110, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 2, 23, 55, 36, 914, DateTimeKind.Local).AddTicks(8881), 20, 24.009855014218880m, null, 23 },
                    { 111, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 24, 5, 24, 6, 137, DateTimeKind.Local).AddTicks(5627), 62, 111.082059190721200m, null, 17 },
                    { 112, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 23, 11, 25, 3, 28, DateTimeKind.Local).AddTicks(2110), 85, 131.581029940497920m, null, 6 },
                    { 113, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 10, 19, 58, 24, 958, DateTimeKind.Local).AddTicks(2139), 32, 73.92760564072560m, null, 18 },
                    { 114, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 26, 10, 47, 54, 67, DateTimeKind.Local).AddTicks(7267), 57, 71.565485948263680m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 6 },
                    { 115, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 11, 2, 23, 21, 431, DateTimeKind.Local).AddTicks(6432), 45, 87.714004505301760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 23 },
                    { 116, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 3, 2, 51, 42, 435, DateTimeKind.Local).AddTicks(8637), 21, 197.973997704839200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 7 },
                    { 117, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 4, 7, 35, 39, 233, DateTimeKind.Local).AddTicks(6635), 57, 21.280260376324520m, null, 19 },
                    { 118, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 22, 19, 39, 14, 143, DateTimeKind.Local).AddTicks(4743), 75, 75.716642575723800m, null, 6 },
                    { 119, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 25, 23, 22, 6, 512, DateTimeKind.Local).AddTicks(6281), 1, 69.420513975741040m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 8 },
                    { 120, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 10, 21, 56, 40, 718, DateTimeKind.Local).AddTicks(6482), 31, 39.556626875019520m, null, 5 },
                    { 121, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 22, 4, 12, 9, 799, DateTimeKind.Local).AddTicks(2839), 21, 45.934035562876480m, null, 23 },
                    { 122, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 12, 18, 35, 56, 867, DateTimeKind.Local).AddTicks(6311), 90, 34.896522734040880m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 4 },
                    { 123, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 24, 15, 25, 7, 398, DateTimeKind.Local).AddTicks(9949), 19, 45.436627517474840m, null, 20 },
                    { 124, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 16, 7, 0, 51, 186, DateTimeKind.Local).AddTicks(9557), 6, 247.287160842590600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 125, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 17, 0, 55, 26, 354, DateTimeKind.Local).AddTicks(618), 3, 12.1600553504231080m, null, 26 },
                    { 126, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 2, 18, 39, 46, 515, DateTimeKind.Local).AddTicks(8123), 10, 184.959507068545760m, null, 4 },
                    { 127, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 11, 19, 33, 23, 326, DateTimeKind.Local).AddTicks(64), 75, 18.350701803545720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 13 },
                    { 128, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 6, 1, 51, 48, 128, DateTimeKind.Local).AddTicks(7432), 24, 92.677995596279520m, null, 3 },
                    { 129, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 30, 11, 22, 55, 798, DateTimeKind.Local).AddTicks(59), 7, 56.321603121394680m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 17 },
                    { 130, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 20, 21, 32, 53, 942, DateTimeKind.Local).AddTicks(6399), 74, 112.509767713059240m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 18 },
                    { 131, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 23, 7, 6, 18, 990, DateTimeKind.Local).AddTicks(5081), 98, 22.8442340914564400m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 5 },
                    { 132, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 15, 15, 11, 48, 755, DateTimeKind.Local).AddTicks(7474), 24, 239.313075249149400m, null, 23 },
                    { 133, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 3, 23, 23, 20, 15, 105, DateTimeKind.Local).AddTicks(3927), 7, 30.101602447318520m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 24 },
                    { 134, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 22, 23, 5, 24, 53, DateTimeKind.Local).AddTicks(8581), 97, 177.836929229157760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 2 },
                    { 135, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 15, 22, 48, 31, 974, DateTimeKind.Local).AddTicks(238), 62, 36.8472333914476560m, null, 15 },
                    { 136, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 6, 1, 16, 32, 577, DateTimeKind.Local).AddTicks(8703), 62, 138.802564550726600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 137, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 4, 4, 5, 14, 490, DateTimeKind.Local).AddTicks(2355), 15, 100.334741346721920m, null, 21 },
                    { 138, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 29, 5, 16, 58, 980, DateTimeKind.Local).AddTicks(6967), 3, 113.621167546007800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 19 },
                    { 139, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 4, 3, 33, 38, 794, DateTimeKind.Local).AddTicks(1711), 72, 138.962511907358200m, null, 2 },
                    { 140, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 8, 10, 48, 41, 221, DateTimeKind.Local).AddTicks(5273), 96, 124.485178373700480m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 12 },
                    { 141, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 11, 21, 54, 26, 520, DateTimeKind.Local).AddTicks(7389), 29, 23.8759317289289440m, null, 25 },
                    { 142, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 7, 13, 43, 58, 710, DateTimeKind.Local).AddTicks(495), 39, 29.092983182036720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 11 },
                    { 143, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 2, 17, 21, 12, 35, DateTimeKind.Local).AddTicks(836), 45, 22.285938192160040m, null, 2 },
                    { 144, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 22, 14, 10, 14, 684, DateTimeKind.Local).AddTicks(6157), 5, 22.442329183590840m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 8 },
                    { 145, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 24, 5, 6, 16, 290, DateTimeKind.Local).AddTicks(6990), 72, 186.385909227027800m, null, 10 },
                    { 146, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 23, 8, 58, 29, 887, DateTimeKind.Local).AddTicks(8831), 44, 18.720887987961520m, null, 3 },
                    { 147, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 27, 18, 20, 3, 464, DateTimeKind.Local).AddTicks(3621), 24, 245.250763071190400m, null, 2 },
                    { 148, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 21, 23, 28, 11, 899, DateTimeKind.Local).AddTicks(9719), 13, 110.050912746805600m, null, 19 },
                    { 149, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 27, 12, 14, 39, 189, DateTimeKind.Local).AddTicks(7420), 94, 103.976550007079000m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 17 },
                    { 150, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 18, 21, 1, 39, 394, DateTimeKind.Local).AddTicks(8105), 76, 94.855732001705400m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 2 },
                    { 151, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 5, 0, 20, 47, 935, DateTimeKind.Local).AddTicks(8254), 58, 82.664922713910600m, null, 19 },
                    { 152, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 5, 4, 38, 19, 459, DateTimeKind.Local).AddTicks(6000), 14, 81.719668976739120m, null, 3 },
                    { 153, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 3, 30, 2, 17, 37, 507, DateTimeKind.Local).AddTicks(9304), 25, 157.591985021174080m, null, 3 },
                    { 154, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 30, 10, 19, 59, 400, DateTimeKind.Local).AddTicks(7570), 13, 74.032673148656800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 155, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 2, 3, 46, 52, 638, DateTimeKind.Local).AddTicks(4435), 47, 146.373288236730240m, null, 6 },
                    { 156, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 10, 7, 25, 6, 989, DateTimeKind.Local).AddTicks(7206), 75, 183.641011358520320m, null, 25 },
                    { 157, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 18, 15, 19, 38, 220, DateTimeKind.Local).AddTicks(6451), 45, 27.230382807046960m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 13 },
                    { 158, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 6, 3, 28, 17, 992, DateTimeKind.Local).AddTicks(8722), 63, 79.433915391794280m, null, 22 },
                    { 159, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 21, 23, 2, 18, 64, DateTimeKind.Local).AddTicks(6331), 33, 156.365270863794200m, null, 2 },
                    { 160, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 11, 17, 20, 35, 41, 907, DateTimeKind.Local).AddTicks(9952), 7, 156.615831592870720m, null, 15 },
                    { 161, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 21, 0, 45, 22, 18, DateTimeKind.Local).AddTicks(5764), 66, 48.267926719383840m, null, 25 },
                    { 162, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 19, 12, 27, 46, 373, DateTimeKind.Local).AddTicks(5295), 40, 28.522274044588560m, null, 5 },
                    { 163, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 6, 4, 8, 19, 244, DateTimeKind.Local).AddTicks(5433), 25, 31.419303868864160m, null, 11 },
                    { 164, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 29, 15, 39, 42, 674, DateTimeKind.Local).AddTicks(7590), 3, 44.878940607500640m, null, 25 },
                    { 165, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 25, 23, 15, 36, 260, DateTimeKind.Local).AddTicks(4753), 63, 183.941194724341440m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 166, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 18, 3, 26, 49, 228, DateTimeKind.Local).AddTicks(4620), 53, 74.078678032078200m, null, 26 },
                    { 167, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 2, 14, 2, 9, 333, DateTimeKind.Local).AddTicks(9108), 86, 68.688378547635280m, null, 2 },
                    { 168, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 13, 14, 48, 42, 737, DateTimeKind.Local).AddTicks(585), 76, 35.275549112415680m, null, 26 },
                    { 169, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 11, 14, 51, 41, 100, DateTimeKind.Local).AddTicks(7091), 85, 10.39267403407235760m, null, 7 },
                    { 170, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 18, 3, 56, 30, 579, DateTimeKind.Local).AddTicks(5297), 22, 80.54080333434720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 10 },
                    { 171, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 5, 2, 1, 44, 639, DateTimeKind.Local).AddTicks(8118), 39, 91.539342743064160m, null, 5 },
                    { 172, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 30, 17, 25, 19, 39, DateTimeKind.Local).AddTicks(5441), 86, 26.9915245299110720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 7 },
                    { 173, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 3, 3, 56, 13, 33, DateTimeKind.Local).AddTicks(4460), 60, 38.876714803347720m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 24 },
                    { 174, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 3, 4, 46, 30, 303, DateTimeKind.Local).AddTicks(7192), 22, 58.1429579772091600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 7 },
                    { 175, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 6, 5, 12, 16, 13, 714, DateTimeKind.Local).AddTicks(5890), 48, 169.055741178839040m, null, 9 },
                    { 176, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 20, 22, 4, 42, 252, DateTimeKind.Local).AddTicks(4984), 61, 164.983277985616600m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 5 },
                    { 177, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 26, 3, 1, 19, 891, DateTimeKind.Local).AddTicks(2914), 72, 155.008883647599040m, null, 18 },
                    { 178, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 17, 1, 3, 20, 340, DateTimeKind.Local).AddTicks(392), 21, 14.772506111886760m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 3 },
                    { 179, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 7, 8, 38, 47, 500, DateTimeKind.Local).AddTicks(2899), 94, 197.98656664576320m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 180, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 6, 8, 33, 32, 548, DateTimeKind.Local).AddTicks(7751), 48, 53.66867832695120m, null, 20 },
                    { 181, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 29, 9, 48, 35, 924, DateTimeKind.Local).AddTicks(6913), 14, 20.20218906505802720m, null, 24 },
                    { 182, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 1, 8, 3, 20, 8, 379, DateTimeKind.Local).AddTicks(1746), 28, 38.8062159448409520m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 20 },
                    { 183, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 24, 1, 16, 22, 965, DateTimeKind.Local).AddTicks(361), 82, 232.646083109023200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 184, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 3, 14, 5, 41, 40, 175, DateTimeKind.Local).AddTicks(7329), 82, 73.991940126561920m, null, 13 },
                    { 185, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 30, 21, 30, 29, 82, DateTimeKind.Local).AddTicks(2449), 9, 93.786654303469320m, null, 18 },
                    { 186, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 20, 4, 51, 14, 769, DateTimeKind.Local).AddTicks(2756), 15, 76.464739056728960m, null, 19 },
                    { 187, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 18, 0, 26, 31, 151, DateTimeKind.Local).AddTicks(4816), 39, 121.472393144745440m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 15 },
                    { 188, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 12, 3, 57, 31, 947, DateTimeKind.Local).AddTicks(3373), 7, 173.185586608367200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 23 },
                    { 189, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 4, 8, 51, 52, 810, DateTimeKind.Local).AddTicks(6525), 54, 87.810784940376320m, null, 19 },
                    { 190, 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2025, 2, 2, 7, 7, 44, 692, DateTimeKind.Local).AddTicks(2758), 83, 168.737452970746200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 18 },
                    { 191, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 30, 6, 9, 57, 791, DateTimeKind.Local).AddTicks(1823), 96, 72.987392119247520m, null, 11 },
                    { 192, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 8, 5, 13, 58, 9, 534, DateTimeKind.Local).AddTicks(4601), 46, 168.969476481596000m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 193, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 26, 12, 46, 27, 544, DateTimeKind.Local).AddTicks(9703), 35, 73.375045070833840m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 6 },
                    { 194, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 9, 15, 21, 5, 49, 984, DateTimeKind.Local).AddTicks(4637), 92, 14.876713613042200m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 4 },
                    { 195, 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 18, 23, 10, 57, 175, DateTimeKind.Local).AddTicks(9686), 3, 25.3036033110947360m, null, 6 },
                    { 196, 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 12, 28, 1, 27, 49, 769, DateTimeKind.Local).AddTicks(688), 73, 32.8879354302581040m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 5 },
                    { 197, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 4, 15, 9, 58, 57, 420, DateTimeKind.Local).AddTicks(4050), 47, 170.76175218172320m, null, 2 },
                    { 198, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 10, 17, 12, 5, 47, 124, DateTimeKind.Local).AddTicks(1907), 38, 22.69765932207160m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 21 },
                    { 199, 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 7, 5, 15, 30, 34, 275, DateTimeKind.Local).AddTicks(6864), 44, 12.8991963795121800m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 25 },
                    { 200, 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", new DateTime(2024, 5, 26, 15, 6, 51, 811, DateTimeKind.Local).AddTicks(9800), 9, 82.389265986767040m, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), 4 }
                });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "PagoId", "CreatedAt", "CreatedBy", "EntradaId", "Estado", "FechaPago", "MetodoPago", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 1, "Pendiente", new DateTime(2024, 9, 5, 2, 20, 34, 889, DateTimeKind.Local).AddTicks(3929), "Nequi", null },
                    { 2, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 2, "Pagado", new DateTime(2025, 3, 23, 5, 33, 3, 758, DateTimeKind.Local).AddTicks(7618), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 3, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 3, "Fallido", new DateTime(2024, 7, 5, 8, 7, 18, 640, DateTimeKind.Local).AddTicks(1719), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 4, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 4, "Pagado", new DateTime(2024, 8, 29, 23, 9, 21, 656, DateTimeKind.Local).AddTicks(4381), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 5, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 5, "Pagado", new DateTime(2024, 10, 24, 10, 27, 16, 922, DateTimeKind.Local).AddTicks(7832), "Tarjeta", null },
                    { 6, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 6, "Fallido", new DateTime(2024, 8, 18, 3, 49, 58, 420, DateTimeKind.Local).AddTicks(9755), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 7, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 7, "Fallido", new DateTime(2024, 8, 10, 6, 48, 3, 432, DateTimeKind.Local).AddTicks(8963), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 8, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 8, "Pagado", new DateTime(2024, 5, 21, 12, 8, 1, 568, DateTimeKind.Local).AddTicks(2113), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 9, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 9, "Pagado", new DateTime(2024, 10, 6, 21, 32, 27, 815, DateTimeKind.Local).AddTicks(57), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 10, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 10, "Pendiente", new DateTime(2024, 10, 15, 1, 50, 1, 246, DateTimeKind.Local).AddTicks(1396), "Nequi", null },
                    { 11, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 11, "Fallido", new DateTime(2024, 7, 23, 14, 1, 12, 931, DateTimeKind.Local).AddTicks(7488), "Efectivo", null },
                    { 12, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 12, "Pagado", new DateTime(2024, 12, 31, 21, 16, 49, 689, DateTimeKind.Local).AddTicks(9959), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 13, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 13, "Pagado", new DateTime(2024, 6, 23, 12, 32, 35, 559, DateTimeKind.Local).AddTicks(8317), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 14, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 14, "Pagado", new DateTime(2024, 10, 17, 22, 26, 3, 405, DateTimeKind.Local).AddTicks(2952), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 15, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 15, "Pagado", new DateTime(2024, 11, 16, 22, 15, 30, 637, DateTimeKind.Local).AddTicks(6473), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 16, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 16, "Fallido", new DateTime(2024, 8, 5, 14, 53, 49, 316, DateTimeKind.Local).AddTicks(6300), "Tarjeta", null },
                    { 17, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 17, "Pendiente", new DateTime(2024, 11, 10, 15, 23, 34, 433, DateTimeKind.Local).AddTicks(740), "Efectivo", null },
                    { 18, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 18, "Pagado", new DateTime(2024, 8, 8, 4, 4, 30, 186, DateTimeKind.Local).AddTicks(6866), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 19, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 19, "Pagado", new DateTime(2024, 9, 5, 2, 19, 34, 987, DateTimeKind.Local).AddTicks(3289), "Tarjeta", null },
                    { 20, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 20, "Pendiente", new DateTime(2024, 10, 29, 0, 50, 23, 89, DateTimeKind.Local).AddTicks(6305), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 21, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 21, "Pendiente", new DateTime(2024, 11, 25, 7, 46, 16, 623, DateTimeKind.Local).AddTicks(6226), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 22, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 22, "Fallido", new DateTime(2024, 12, 5, 20, 40, 58, 938, DateTimeKind.Local).AddTicks(9630), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 23, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 23, "Fallido", new DateTime(2025, 3, 15, 11, 19, 35, 33, DateTimeKind.Local).AddTicks(9475), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 24, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 24, "Pagado", new DateTime(2024, 12, 17, 14, 4, 42, 412, DateTimeKind.Local).AddTicks(5735), "Nequi", null },
                    { 25, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 25, "Fallido", new DateTime(2025, 1, 10, 22, 23, 47, 261, DateTimeKind.Local).AddTicks(7280), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 26, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 26, "Pendiente", new DateTime(2024, 7, 24, 18, 24, 59, 904, DateTimeKind.Local).AddTicks(7315), "Efectivo", null },
                    { 27, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 27, "Pagado", new DateTime(2024, 3, 28, 16, 7, 13, 41, DateTimeKind.Local).AddTicks(3553), "Nequi", null },
                    { 28, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 28, "Fallido", new DateTime(2024, 9, 26, 19, 4, 34, 928, DateTimeKind.Local).AddTicks(8383), "PSE", null },
                    { 29, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 29, "Pagado", new DateTime(2024, 8, 16, 20, 52, 32, 625, DateTimeKind.Local).AddTicks(9928), "Nequi", null },
                    { 30, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 30, "Pagado", new DateTime(2025, 1, 6, 18, 3, 7, 717, DateTimeKind.Local).AddTicks(8769), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 31, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 31, "Fallido", new DateTime(2024, 12, 12, 9, 9, 16, 664, DateTimeKind.Local).AddTicks(2422), "PSE", null },
                    { 32, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 32, "Pendiente", new DateTime(2024, 3, 30, 19, 9, 58, 554, DateTimeKind.Local).AddTicks(1533), "Nequi", null },
                    { 33, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 33, "Pendiente", new DateTime(2024, 7, 25, 9, 23, 30, 637, DateTimeKind.Local).AddTicks(1813), "Tarjeta", null },
                    { 34, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 34, "Fallido", new DateTime(2024, 5, 4, 21, 2, 39, 327, DateTimeKind.Local).AddTicks(5702), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 35, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 35, "Pagado", new DateTime(2025, 1, 26, 15, 25, 36, 506, DateTimeKind.Local).AddTicks(4068), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 36, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 36, "Pagado", new DateTime(2025, 1, 6, 4, 40, 2, 3, DateTimeKind.Local).AddTicks(9457), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 37, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 37, "Pendiente", new DateTime(2024, 8, 19, 20, 43, 3, 33, DateTimeKind.Local).AddTicks(4515), "Tarjeta", null },
                    { 38, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 38, "Pagado", new DateTime(2024, 10, 1, 2, 2, 58, 588, DateTimeKind.Local).AddTicks(9794), "Tarjeta", null },
                    { 39, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 39, "Pendiente", new DateTime(2024, 5, 11, 4, 10, 5, 958, DateTimeKind.Local).AddTicks(1370), "Nequi", null },
                    { 40, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 40, "Pendiente", new DateTime(2024, 10, 23, 20, 56, 9, 958, DateTimeKind.Local).AddTicks(2944), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 41, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 41, "Fallido", new DateTime(2024, 12, 24, 1, 46, 42, 277, DateTimeKind.Local).AddTicks(767), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 42, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 42, "Fallido", new DateTime(2025, 1, 21, 9, 12, 50, 627, DateTimeKind.Local).AddTicks(6886), "PSE", null },
                    { 43, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 43, "Pendiente", new DateTime(2025, 1, 15, 5, 17, 2, 615, DateTimeKind.Local).AddTicks(91), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 44, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 44, "Fallido", new DateTime(2024, 9, 14, 3, 13, 54, 851, DateTimeKind.Local).AddTicks(2547), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 45, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 45, "Fallido", new DateTime(2024, 10, 27, 23, 49, 44, 630, DateTimeKind.Local).AddTicks(2767), "Tarjeta", null },
                    { 46, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 46, "Fallido", new DateTime(2024, 10, 14, 8, 57, 58, 822, DateTimeKind.Local).AddTicks(673), "Efectivo", null },
                    { 47, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 47, "Fallido", new DateTime(2024, 9, 17, 21, 27, 39, 443, DateTimeKind.Local).AddTicks(8569), "Tarjeta", null },
                    { 48, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 48, "Pendiente", new DateTime(2024, 7, 19, 2, 58, 25, 532, DateTimeKind.Local).AddTicks(9698), "PSE", null },
                    { 49, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 49, "Fallido", new DateTime(2024, 5, 26, 23, 35, 12, 691, DateTimeKind.Local).AddTicks(9750), "Tarjeta", null },
                    { 50, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 50, "Pendiente", new DateTime(2024, 10, 3, 11, 23, 57, 801, DateTimeKind.Local).AddTicks(8942), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 51, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 51, "Pendiente", new DateTime(2024, 10, 23, 21, 53, 46, 89, DateTimeKind.Local).AddTicks(566), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 52, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 52, "Fallido", new DateTime(2025, 3, 16, 12, 13, 41, 847, DateTimeKind.Local).AddTicks(9254), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 53, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 53, "Pagado", new DateTime(2024, 4, 30, 14, 5, 38, 114, DateTimeKind.Local).AddTicks(6249), "Tarjeta", null },
                    { 54, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 54, "Pendiente", new DateTime(2025, 3, 14, 2, 17, 24, 367, DateTimeKind.Local).AddTicks(6957), "Tarjeta", null },
                    { 55, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 55, "Pagado", new DateTime(2024, 3, 25, 18, 11, 57, 587, DateTimeKind.Local).AddTicks(9893), "Nequi", null },
                    { 56, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 56, "Fallido", new DateTime(2025, 1, 10, 15, 31, 33, 205, DateTimeKind.Local).AddTicks(248), "PSE", null },
                    { 57, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 57, "Pendiente", new DateTime(2024, 7, 24, 16, 49, 27, 398, DateTimeKind.Local).AddTicks(2396), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 58, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 58, "Fallido", new DateTime(2024, 4, 30, 17, 36, 40, 422, DateTimeKind.Local).AddTicks(5957), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 59, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 59, "Pendiente", new DateTime(2024, 7, 9, 9, 18, 42, 996, DateTimeKind.Local).AddTicks(9100), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 60, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 60, "Pagado", new DateTime(2024, 12, 16, 23, 0, 45, 524, DateTimeKind.Local).AddTicks(2601), "Efectivo", null },
                    { 61, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 61, "Fallido", new DateTime(2025, 3, 12, 16, 8, 6, 550, DateTimeKind.Local).AddTicks(2630), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 62, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 62, "Pendiente", new DateTime(2024, 3, 24, 3, 35, 46, 689, DateTimeKind.Local).AddTicks(9608), "Tarjeta", null },
                    { 63, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 63, "Pendiente", new DateTime(2024, 9, 27, 20, 8, 9, 505, DateTimeKind.Local).AddTicks(6561), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 64, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 64, "Pendiente", new DateTime(2024, 7, 28, 3, 31, 15, 71, DateTimeKind.Local).AddTicks(2562), "Efectivo", null },
                    { 65, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 65, "Fallido", new DateTime(2024, 7, 9, 9, 2, 39, 551, DateTimeKind.Local).AddTicks(1438), "Efectivo", null },
                    { 66, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 66, "Fallido", new DateTime(2024, 12, 20, 22, 0, 42, 804, DateTimeKind.Local).AddTicks(6367), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 67, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 67, "Fallido", new DateTime(2024, 5, 30, 5, 41, 28, 669, DateTimeKind.Local).AddTicks(1419), "Nequi", null },
                    { 68, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 68, "Pagado", new DateTime(2024, 5, 1, 2, 18, 13, 633, DateTimeKind.Local).AddTicks(965), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 69, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 69, "Fallido", new DateTime(2024, 10, 28, 1, 10, 26, 976, DateTimeKind.Local).AddTicks(7478), "PSE", null },
                    { 70, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 70, "Fallido", new DateTime(2025, 1, 27, 1, 47, 30, 714, DateTimeKind.Local).AddTicks(7096), "PSE", null },
                    { 71, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 71, "Pendiente", new DateTime(2024, 12, 8, 12, 1, 7, 683, DateTimeKind.Local).AddTicks(5730), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 72, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 72, "Pagado", new DateTime(2024, 11, 11, 12, 20, 29, 848, DateTimeKind.Local).AddTicks(5373), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 73, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 73, "Fallido", new DateTime(2024, 12, 7, 1, 3, 51, 822, DateTimeKind.Local).AddTicks(3174), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 74, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 74, "Pendiente", new DateTime(2024, 10, 4, 3, 59, 39, 332, DateTimeKind.Local).AddTicks(8097), "Tarjeta", null },
                    { 75, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 75, "Fallido", new DateTime(2025, 2, 11, 16, 5, 22, 799, DateTimeKind.Local).AddTicks(4889), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 76, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 76, "Pagado", new DateTime(2024, 8, 3, 15, 41, 52, 836, DateTimeKind.Local).AddTicks(5346), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 77, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 77, "Pendiente", new DateTime(2024, 12, 17, 13, 57, 45, 978, DateTimeKind.Local).AddTicks(4232), "Tarjeta", null },
                    { 78, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 78, "Pagado", new DateTime(2025, 1, 22, 10, 15, 3, 579, DateTimeKind.Local).AddTicks(4521), "Tarjeta", null },
                    { 79, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 79, "Fallido", new DateTime(2024, 11, 13, 18, 32, 58, 541, DateTimeKind.Local).AddTicks(2602), "PSE", null },
                    { 80, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 80, "Pagado", new DateTime(2024, 8, 2, 2, 38, 26, 399, DateTimeKind.Local).AddTicks(8864), "Efectivo", null },
                    { 81, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 81, "Pendiente", new DateTime(2024, 10, 20, 8, 39, 28, 735, DateTimeKind.Local).AddTicks(9472), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 82, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 82, "Pendiente", new DateTime(2024, 12, 16, 22, 55, 39, 57, DateTimeKind.Local).AddTicks(3472), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 83, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 83, "Pendiente", new DateTime(2025, 1, 13, 10, 19, 38, 236, DateTimeKind.Local).AddTicks(6323), "Tarjeta", null },
                    { 84, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 84, "Pendiente", new DateTime(2025, 1, 13, 21, 4, 2, 391, DateTimeKind.Local).AddTicks(3390), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 85, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 85, "Pagado", new DateTime(2024, 8, 17, 22, 58, 2, 83, DateTimeKind.Local).AddTicks(6842), "Tarjeta", null },
                    { 86, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 86, "Pagado", new DateTime(2024, 9, 1, 0, 10, 42, 237, DateTimeKind.Local).AddTicks(6279), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 87, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 87, "Pendiente", new DateTime(2024, 12, 26, 2, 44, 40, 997, DateTimeKind.Local).AddTicks(6565), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 88, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 88, "Pendiente", new DateTime(2024, 4, 20, 7, 24, 31, 990, DateTimeKind.Local).AddTicks(8289), "Nequi", null },
                    { 89, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 89, "Pagado", new DateTime(2024, 9, 10, 18, 22, 58, 445, DateTimeKind.Local).AddTicks(9771), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 90, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 90, "Pagado", new DateTime(2024, 4, 19, 10, 40, 51, 442, DateTimeKind.Local).AddTicks(8236), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 91, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 91, "Fallido", new DateTime(2024, 11, 17, 7, 34, 21, 544, DateTimeKind.Local).AddTicks(6159), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 92, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 92, "Fallido", new DateTime(2024, 4, 29, 1, 50, 37, 521, DateTimeKind.Local).AddTicks(5745), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 93, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 93, "Pagado", new DateTime(2025, 1, 9, 12, 45, 36, 82, DateTimeKind.Local).AddTicks(7875), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 94, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 94, "Fallido", new DateTime(2024, 5, 22, 5, 17, 7, 425, DateTimeKind.Local).AddTicks(9104), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 95, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 95, "Pendiente", new DateTime(2024, 10, 13, 15, 45, 43, 216, DateTimeKind.Local).AddTicks(7893), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 96, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 96, "Pendiente", new DateTime(2024, 10, 16, 0, 14, 40, 856, DateTimeKind.Local).AddTicks(1088), "Efectivo", null },
                    { 97, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 97, "Pendiente", new DateTime(2024, 7, 5, 13, 56, 35, 28, DateTimeKind.Local).AddTicks(9389), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 98, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 98, "Pendiente", new DateTime(2024, 8, 3, 16, 6, 21, 822, DateTimeKind.Local).AddTicks(1101), "Nequi", null },
                    { 99, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 99, "Pagado", new DateTime(2025, 1, 24, 21, 19, 17, 437, DateTimeKind.Local).AddTicks(5784), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 100, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 100, "Pendiente", new DateTime(2024, 4, 18, 1, 3, 45, 148, DateTimeKind.Local).AddTicks(1299), "Efectivo", null },
                    { 101, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 101, "Pendiente", new DateTime(2024, 6, 14, 15, 25, 53, 107, DateTimeKind.Local).AddTicks(9550), "Tarjeta", null },
                    { 102, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 102, "Pendiente", new DateTime(2024, 3, 31, 20, 42, 49, 787, DateTimeKind.Local).AddTicks(6736), "Nequi", null },
                    { 103, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 103, "Pendiente", new DateTime(2024, 11, 22, 22, 43, 50, 670, DateTimeKind.Local).AddTicks(1183), "PSE", null },
                    { 104, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 104, "Fallido", new DateTime(2024, 11, 24, 23, 39, 17, 650, DateTimeKind.Local).AddTicks(5388), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 105, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 105, "Pendiente", new DateTime(2024, 9, 1, 8, 36, 23, 787, DateTimeKind.Local).AddTicks(3739), "Tarjeta", null },
                    { 106, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 106, "Pendiente", new DateTime(2025, 1, 17, 13, 16, 58, 814, DateTimeKind.Local).AddTicks(2347), "Tarjeta", null },
                    { 107, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 107, "Fallido", new DateTime(2025, 1, 8, 3, 42, 58, 41, DateTimeKind.Local).AddTicks(1490), "PSE", null },
                    { 108, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 108, "Fallido", new DateTime(2024, 4, 21, 14, 46, 4, 542, DateTimeKind.Local).AddTicks(9901), "Efectivo", null },
                    { 109, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 109, "Pendiente", new DateTime(2024, 5, 4, 5, 41, 53, 47, DateTimeKind.Local).AddTicks(2723), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 110, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 110, "Fallido", new DateTime(2024, 7, 15, 14, 6, 27, 973, DateTimeKind.Local).AddTicks(8036), "Tarjeta", null },
                    { 111, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 111, "Pagado", new DateTime(2024, 11, 9, 19, 45, 58, 171, DateTimeKind.Local).AddTicks(191), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 112, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 112, "Pagado", new DateTime(2024, 4, 6, 21, 9, 14, 341, DateTimeKind.Local).AddTicks(9058), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 113, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 113, "Pendiente", new DateTime(2025, 2, 27, 17, 1, 26, 88, DateTimeKind.Local).AddTicks(1127), "Nequi", null },
                    { 114, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 114, "Pendiente", new DateTime(2025, 2, 22, 0, 40, 26, 336, DateTimeKind.Local).AddTicks(3820), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 115, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 115, "Fallido", new DateTime(2024, 8, 31, 1, 31, 19, 565, DateTimeKind.Local).AddTicks(3579), "Efectivo", null },
                    { 116, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 116, "Fallido", new DateTime(2024, 12, 2, 19, 49, 5, 570, DateTimeKind.Local).AddTicks(3944), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 117, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 117, "Fallido", new DateTime(2024, 12, 12, 6, 43, 51, 339, DateTimeKind.Local).AddTicks(926), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 118, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 118, "Fallido", new DateTime(2024, 4, 8, 5, 36, 2, 627, DateTimeKind.Local).AddTicks(9474), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 119, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 119, "Pendiente", new DateTime(2024, 10, 26, 18, 12, 45, 675, DateTimeKind.Local).AddTicks(2932), "Tarjeta", null },
                    { 120, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 120, "Pagado", new DateTime(2024, 4, 10, 17, 20, 5, 402, DateTimeKind.Local).AddTicks(5419), "Efectivo", null },
                    { 121, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 121, "Fallido", new DateTime(2024, 5, 30, 23, 12, 35, 8, DateTimeKind.Local).AddTicks(8109), "Nequi", null },
                    { 122, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 122, "Pagado", new DateTime(2024, 10, 23, 3, 53, 17, 749, DateTimeKind.Local).AddTicks(8939), "Tarjeta", null },
                    { 123, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 123, "Pagado", new DateTime(2025, 1, 3, 4, 43, 56, 664, DateTimeKind.Local).AddTicks(236), "Nequi", null },
                    { 124, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 124, "Pagado", new DateTime(2024, 6, 6, 4, 17, 36, 357, DateTimeKind.Local).AddTicks(1710), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 125, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 125, "Pendiente", new DateTime(2024, 10, 19, 22, 21, 5, 264, DateTimeKind.Local).AddTicks(5009), "Nequi", null },
                    { 126, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 126, "Fallido", new DateTime(2024, 11, 29, 18, 7, 37, 477, DateTimeKind.Local).AddTicks(7392), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 127, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 127, "Fallido", new DateTime(2025, 2, 26, 23, 31, 32, 932, DateTimeKind.Local).AddTicks(6533), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 128, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 128, "Fallido", new DateTime(2024, 9, 13, 15, 52, 27, 136, DateTimeKind.Local).AddTicks(7287), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 129, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 129, "Pagado", new DateTime(2025, 2, 4, 19, 58, 45, 899, DateTimeKind.Local).AddTicks(717), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 130, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 130, "Pendiente", new DateTime(2025, 1, 21, 6, 9, 56, 751, DateTimeKind.Local).AddTicks(747), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 131, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 131, "Fallido", new DateTime(2024, 5, 19, 20, 13, 4, 747, DateTimeKind.Local).AddTicks(9810), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 132, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 132, "Pagado", new DateTime(2025, 2, 18, 13, 56, 48, 318, DateTimeKind.Local).AddTicks(6434), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 133, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 133, "Pendiente", new DateTime(2024, 7, 8, 13, 41, 16, 788, DateTimeKind.Local).AddTicks(2098), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 134, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 134, "Fallido", new DateTime(2024, 6, 9, 16, 26, 57, 635, DateTimeKind.Local).AddTicks(6167), "Nequi", null },
                    { 135, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 135, "Pendiente", new DateTime(2024, 12, 22, 1, 50, 6, 824, DateTimeKind.Local).AddTicks(2607), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 136, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 136, "Fallido", new DateTime(2024, 6, 16, 1, 42, 33, 801, DateTimeKind.Local).AddTicks(2405), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 137, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 137, "Pendiente", new DateTime(2025, 3, 3, 22, 16, 12, 679, DateTimeKind.Local).AddTicks(7193), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 138, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 138, "Fallido", new DateTime(2024, 8, 19, 9, 59, 51, 436, DateTimeKind.Local).AddTicks(9948), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 139, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 139, "Fallido", new DateTime(2025, 1, 14, 7, 32, 25, 913, DateTimeKind.Local).AddTicks(4167), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 140, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 140, "Fallido", new DateTime(2024, 5, 9, 13, 15, 45, 742, DateTimeKind.Local).AddTicks(3495), "Nequi", null },
                    { 141, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 141, "Pagado", new DateTime(2025, 3, 1, 5, 14, 22, 729, DateTimeKind.Local).AddTicks(888), "Tarjeta", null },
                    { 142, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 142, "Fallido", new DateTime(2024, 9, 26, 21, 6, 45, 125, DateTimeKind.Local).AddTicks(8901), "Tarjeta", null },
                    { 143, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 143, "Pagado", new DateTime(2024, 8, 4, 15, 19, 26, 807, DateTimeKind.Local).AddTicks(3063), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 144, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 144, "Fallido", new DateTime(2024, 8, 7, 7, 4, 11, 996, DateTimeKind.Local).AddTicks(9031), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 145, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 145, "Pendiente", new DateTime(2024, 4, 2, 12, 52, 6, 175, DateTimeKind.Local).AddTicks(6207), "Tarjeta", null },
                    { 146, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 146, "Fallido", new DateTime(2024, 10, 21, 12, 11, 8, 414, DateTimeKind.Local).AddTicks(8871), "Tarjeta", null },
                    { 147, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 147, "Pendiente", new DateTime(2024, 6, 10, 0, 0, 4, 898, DateTimeKind.Local).AddTicks(947), "Tarjeta", null },
                    { 148, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 148, "Pendiente", new DateTime(2024, 12, 31, 21, 35, 27, 957, DateTimeKind.Local).AddTicks(7924), "Nequi", null },
                    { 149, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 149, "Pagado", new DateTime(2025, 1, 10, 11, 19, 51, 289, DateTimeKind.Local).AddTicks(3468), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 150, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 150, "Fallido", new DateTime(2024, 8, 27, 17, 40, 18, 571, DateTimeKind.Local).AddTicks(1108), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 151, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 151, "Pagado", new DateTime(2025, 1, 13, 12, 20, 42, 960, DateTimeKind.Local).AddTicks(4344), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 152, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 152, "Pagado", new DateTime(2024, 6, 29, 13, 26, 52, 881, DateTimeKind.Local).AddTicks(4486), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 153, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 153, "Fallido", new DateTime(2025, 2, 4, 17, 42, 24, 860, DateTimeKind.Local).AddTicks(4824), "Tarjeta", null },
                    { 154, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 154, "Pagado", new DateTime(2024, 7, 1, 11, 7, 23, 614, DateTimeKind.Local).AddTicks(4728), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 155, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 155, "Pagado", new DateTime(2025, 1, 10, 0, 8, 20, 5, DateTimeKind.Local).AddTicks(6620), "Nequi", null },
                    { 156, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 156, "Fallido", new DateTime(2025, 2, 10, 14, 50, 31, 754, DateTimeKind.Local).AddTicks(7583), "Efectivo", null },
                    { 157, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 157, "Pendiente", new DateTime(2024, 10, 25, 22, 37, 58, 124, DateTimeKind.Local).AddTicks(8432), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 158, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 158, "Fallido", new DateTime(2024, 8, 17, 18, 43, 48, 770, DateTimeKind.Local).AddTicks(8079), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 159, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 159, "Fallido", new DateTime(2025, 1, 15, 14, 21, 5, 881, DateTimeKind.Local).AddTicks(4487), "Tarjeta", null },
                    { 160, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 160, "Fallido", new DateTime(2024, 8, 22, 5, 11, 40, 346, DateTimeKind.Local).AddTicks(5972), "Efectivo", null },
                    { 161, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 161, "Pagado", new DateTime(2024, 12, 28, 0, 24, 18, 651, DateTimeKind.Local).AddTicks(2490), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 162, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 162, "Pagado", new DateTime(2025, 3, 6, 4, 32, 28, 926, DateTimeKind.Local).AddTicks(111), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 163, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 163, "Fallido", new DateTime(2024, 3, 30, 9, 8, 45, 570, DateTimeKind.Local).AddTicks(4255), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 164, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 164, "Pagado", new DateTime(2025, 2, 19, 16, 37, 5, 469, DateTimeKind.Local).AddTicks(7551), "PSE", null },
                    { 165, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 165, "Pendiente", new DateTime(2024, 5, 9, 16, 38, 7, 478, DateTimeKind.Local).AddTicks(707), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 166, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 166, "Pendiente", new DateTime(2024, 4, 16, 4, 11, 25, 108, DateTimeKind.Local).AddTicks(2502), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 167, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 167, "Fallido", new DateTime(2024, 9, 12, 14, 10, 26, 256, DateTimeKind.Local).AddTicks(4696), "Tarjeta", null },
                    { 168, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 168, "Fallido", new DateTime(2024, 6, 29, 22, 12, 35, 669, DateTimeKind.Local).AddTicks(9266), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 169, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 169, "Pagado", new DateTime(2024, 12, 6, 11, 5, 15, 910, DateTimeKind.Local).AddTicks(6220), "Nequi", null },
                    { 170, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 170, "Pendiente", new DateTime(2024, 5, 25, 13, 31, 37, 581, DateTimeKind.Local).AddTicks(5835), "Efectivo", null },
                    { 171, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 171, "Pendiente", new DateTime(2025, 1, 3, 1, 20, 27, 390, DateTimeKind.Local).AddTicks(3346), "Tarjeta", null },
                    { 172, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 172, "Pagado", new DateTime(2024, 11, 4, 12, 54, 28, 14, DateTimeKind.Local).AddTicks(9973), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 173, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 173, "Pendiente", new DateTime(2024, 8, 26, 2, 17, 23, 175, DateTimeKind.Local).AddTicks(8887), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 174, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 174, "Fallido", new DateTime(2024, 12, 14, 12, 8, 4, 769, DateTimeKind.Local).AddTicks(1833), "PSE", null },
                    { 175, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 175, "Fallido", new DateTime(2024, 5, 22, 11, 55, 2, 914, DateTimeKind.Local).AddTicks(294), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 176, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 176, "Pendiente", new DateTime(2024, 5, 11, 22, 25, 8, 210, DateTimeKind.Local).AddTicks(7030), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 177, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 177, "Pendiente", new DateTime(2024, 8, 22, 13, 23, 28, 782, DateTimeKind.Local).AddTicks(6809), "Efectivo", null },
                    { 178, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 178, "Pagado", new DateTime(2024, 8, 8, 17, 0, 11, 318, DateTimeKind.Local).AddTicks(805), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 179, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 179, "Pagado", new DateTime(2024, 11, 18, 13, 31, 34, 739, DateTimeKind.Local).AddTicks(5925), "Efectivo", null },
                    { 180, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 180, "Pagado", new DateTime(2024, 10, 11, 6, 34, 3, 830, DateTimeKind.Local).AddTicks(6697), "Nequi", null },
                    { 181, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 181, "Pendiente", new DateTime(2024, 11, 21, 19, 30, 43, 167, DateTimeKind.Local).AddTicks(6241), "PSE", null },
                    { 182, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 182, "Pendiente", new DateTime(2024, 6, 3, 10, 53, 45, 338, DateTimeKind.Local).AddTicks(8264), "Tarjeta", null },
                    { 183, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 183, "Pendiente", new DateTime(2024, 12, 28, 3, 41, 5, 476, DateTimeKind.Local).AddTicks(9102), "Efectivo", null },
                    { 184, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 184, "Pagado", new DateTime(2024, 9, 2, 21, 37, 54, 708, DateTimeKind.Local).AddTicks(1083), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 185, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 185, "Pendiente", new DateTime(2025, 1, 30, 20, 51, 54, 21, DateTimeKind.Local).AddTicks(641), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 186, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 186, "Fallido", new DateTime(2024, 4, 6, 16, 59, 33, 153, DateTimeKind.Local).AddTicks(3712), "Efectivo", null },
                    { 187, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 187, "Fallido", new DateTime(2024, 7, 14, 21, 15, 30, 464, DateTimeKind.Local).AddTicks(7503), "Efectivo", null },
                    { 188, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 188, "Pendiente", new DateTime(2024, 5, 24, 20, 17, 24, 256, DateTimeKind.Local).AddTicks(6759), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 189, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 189, "Fallido", new DateTime(2024, 12, 15, 0, 50, 4, 557, DateTimeKind.Local).AddTicks(3536), "Nequi", null },
                    { 190, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 190, "Pendiente", new DateTime(2024, 5, 14, 22, 54, 39, 445, DateTimeKind.Local).AddTicks(9824), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 191, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 191, "Pagado", new DateTime(2025, 1, 23, 6, 21, 36, 440, DateTimeKind.Local).AddTicks(7058), "Nequi", null },
                    { 192, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 192, "Pagado", new DateTime(2024, 11, 4, 13, 36, 32, 345, DateTimeKind.Local).AddTicks(9865), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 193, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 193, "Fallido", new DateTime(2024, 7, 8, 8, 37, 25, 570, DateTimeKind.Local).AddTicks(4102), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 194, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 194, "Fallido", new DateTime(2024, 7, 12, 20, 33, 16, 668, DateTimeKind.Local).AddTicks(2230), "Efectivo", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 195, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 195, "Pagado", new DateTime(2024, 6, 29, 3, 15, 22, 766, DateTimeKind.Local).AddTicks(2497), "Nequi", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 196, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 196, "Pendiente", new DateTime(2024, 5, 18, 17, 21, 17, 269, DateTimeKind.Local).AddTicks(3949), "PSE", null },
                    { 197, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 197, "Pendiente", new DateTime(2024, 6, 2, 17, 19, 25, 332, DateTimeKind.Local).AddTicks(7278), "Tarjeta", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 198, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 198, "Fallido", new DateTime(2025, 1, 28, 5, 29, 53, 258, DateTimeKind.Local).AddTicks(5051), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) },
                    { 199, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 199, "Fallido", new DateTime(2024, 5, 1, 14, 44, 42, 63, DateTimeKind.Local).AddTicks(7964), "Tarjeta", null },
                    { 200, new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842), "Api User", 200, "Pendiente", new DateTime(2024, 6, 7, 10, 1, 52, 98, DateTimeKind.Local).AddTicks(5307), "PSE", new DateTime(2025, 3, 23, 14, 15, 31, 356, DateTimeKind.Utc).AddTicks(842) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_FuncionId",
                table: "Entrada",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_UserId",
                table: "Entrada",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_PeliculaId",
                table: "Funcion",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_SalaId",
                table: "Funcion",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_EntradaId",
                table: "Pago",
                column: "EntradaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_CineId",
                table: "Sala",
                column: "CineId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_UserId",
                table: "Sesion",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Funcion");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Cine");
        }
    }
}
