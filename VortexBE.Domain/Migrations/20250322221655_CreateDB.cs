using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VortexBE.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
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
                    { 1, "Ibagué", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Centro Comercial Multicentro", "CineColombia", null },
                    { 2, "Medellín", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Av. Siempre Viva 742", "Cinemark", null },
                    { 3, "Cali", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Mall Plaza", "Royal Films", null },
                    { 4, "Barranquilla", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Centro Comercial Unicentro", "Royal Films", null },
                    { 5, "Cartagena", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Plaza Central", "Cinemark", null },
                    { 6, "Bogotá D.C.", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Centro Comercial Andino", "Multiplex Andino", null },
                    { 7, "Bucaramanga", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Cra. 50 #20-30", "CineColombia", null },
                    { 8, "Pereira", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Carrera 15 #45-67", "Cinemark", null },
                    { 9, "Manizales", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Av. 68 #22-15", "CineColombia", null },
                    { 10, "Cúcuta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Centro Comercial Ventura", "Cinemark", null }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "PeliculaId", "Clasificacion", "CreatedAt", "CreatedBy", "Descripcion", "Director", "Duracion", "FechaEstreno", "Genero", "PosterUrl", "Titulo", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "R", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Sequi in quam molestiae tempora deleniti dolores velit aut. Inventore doloremque rerum et rem eaque omnis. Inventore id id sed dolorem illo error nesciunt sit. Ut et magni quasi officia. Et omnis velit.", "Ridley Scott", 118, new DateTime(2024, 9, 9, 10, 22, 37, 942, DateTimeKind.Utc).AddTicks(795), "Animación", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/890.jpg", "Voluptatem nesciunt ad.", null },
                    { 2, "G", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Sunt nihil sit. Rem quia illum sed sunt qui in. Doloribus aliquid reprehenderit quaerat laboriosam voluptas in.", "Quentin Tarantino", 99, new DateTime(2021, 3, 20, 17, 58, 16, 932, DateTimeKind.Utc).AddTicks(9792), "Terror", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/343.jpg", "Voluptates reprehenderit nisi.", null },
                    { 3, "G", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Ad accusamus repudiandae enim necessitatibus dolorum sint aut ullam. In ipsum facere nihil asperiores. Et quos corporis magni quidem repudiandae ab corrupti ipsa. Autem ipsa vel occaecati provident dolor ratione.", "Christopher Nolan", 99, new DateTime(2021, 8, 19, 21, 34, 4, 407, DateTimeKind.Utc).AddTicks(8051), "Acción", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1105.jpg", "Quas neque dolores.", null },
                    { 4, "G", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Aut repellat aut quas ut voluptas nesciunt rerum. Nihil nemo dolor nulla vel. Deleniti sunt molestiae culpa voluptatibus. Qui at officiis ipsam qui quia repellat et. Quidem eaque molestias enim odio. Dolores repudiandae voluptatem.", "Christopher Nolan", 163, new DateTime(2020, 6, 20, 15, 42, 14, 823, DateTimeKind.Utc).AddTicks(4240), "Ciencia Ficción", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/93.jpg", "Quis maxime blanditiis.", null },
                    { 5, "PG", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Nostrum ut vel itaque illo. Fugit impedit aut dolor. Dolor accusantium molestias fugit qui neque hic ratione magnam id. Necessitatibus odio molestiae commodi nulla fuga reprehenderit tempora esse rerum. Vel dignissimos odio.", "Quentin Tarantino", 83, new DateTime(2025, 9, 3, 15, 36, 49, 876, DateTimeKind.Utc).AddTicks(566), "Drama", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/390.jpg", "Omnis aut ipsa.", null },
                    { 6, "G", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Itaque omnis at. Atque veniam et aliquid alias. Consequatur magnam est laborum eos.", "Christopher Nolan", 87, new DateTime(2023, 5, 5, 6, 41, 5, 378, DateTimeKind.Utc).AddTicks(3764), "Terror", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/167.jpg", "Voluptates velit quo.", null },
                    { 7, "R", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Sit eveniet nisi. Nam aut consequatur. Voluptatum soluta debitis qui possimus iusto deleniti. Aperiam sed velit ratione possimus dolores iusto accusantium ad. Mollitia nihil quaerat delectus quis aspernatur vitae voluptas aliquid debitis.", "Ridley Scott", 120, new DateTime(2023, 10, 29, 23, 32, 8, 196, DateTimeKind.Utc).AddTicks(2844), "Animación", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/922.jpg", "Harum nobis qui.", null },
                    { 8, "PG", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Repellat minima quia. Nulla quia alias qui accusantium rerum. Eum ipsam earum molestiae autem. Vel delectus velit temporibus et et animi labore voluptate laboriosam. Eum laudantium harum autem tenetur voluptas.", "Martin Scorsese", 135, new DateTime(2021, 12, 5, 9, 28, 21, 696, DateTimeKind.Utc).AddTicks(8476), "Comedia", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/138.jpg", "Minus possimus nemo.", null },
                    { 9, "NC-17", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Saepe optio dolores ipsam voluptatibus qui vel. Distinctio in ut nulla aut eos. Consequatur vitae qui nemo dignissimos deserunt qui autem. Quia doloribus fuga est cumque.", "Steven Spielberg", 176, new DateTime(2024, 5, 14, 18, 41, 46, 672, DateTimeKind.Utc).AddTicks(948), "Terror", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1220.jpg", "Modi aut esse.", null },
                    { 10, "PG-13", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Ullam excepturi modi. Aperiam culpa qui sit voluptatem doloribus non. Sint voluptatem culpa quia unde quibusdam tempora consectetur minus. Dolorem ut numquam corrupti.", "Quentin Tarantino", 172, new DateTime(2020, 4, 29, 5, 23, 35, 438, DateTimeKind.Utc).AddTicks(6781), "Terror", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/117.jpg", "Itaque exercitationem numquam.", null },
                    { 11, "PG-13", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Non in magni autem autem rerum rerum. Quam eum non dolorem unde. Maiores sit pariatur aut velit quo tempora rem quia. Soluta laborum ad doloribus eaque eos minima et iste voluptas. Blanditiis ab sit illum aut ut non non non. Aut repellat quam cumque quo adipisci provident.", "Steven Spielberg", 134, new DateTime(2020, 8, 10, 19, 46, 56, 685, DateTimeKind.Utc).AddTicks(8871), "Animación", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/625.jpg", "Ullam et qui.", null },
                    { 12, "R", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Qui eligendi maiores consequuntur aliquid est. Est nobis hic nihil harum doloremque molestiae id possimus qui. Necessitatibus illum optio. Sapiente atque eos ea nam qui non facilis similique qui. Excepturi nulla voluptatem beatae voluptatibus quia aut officiis.", "Steven Spielberg", 84, new DateTime(2025, 2, 7, 21, 30, 39, 749, DateTimeKind.Utc).AddTicks(5329), "Animación", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1083.jpg", "Qui perspiciatis voluptas.", null },
                    { 13, "R", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Nihil eos sint dolores omnis temporibus qui. Eos et eum voluptatum. Deserunt modi facilis autem veritatis unde reiciendis cum. Qui similique odio nostrum ipsam laboriosam fugiat. At dolores aut. Aliquid at quisquam iusto consequatur enim laborum ea sequi.", "Martin Scorsese", 132, new DateTime(2021, 6, 3, 3, 28, 44, 345, DateTimeKind.Utc).AddTicks(5464), "Ciencia Ficción", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1078.jpg", "Doloribus asperiores saepe.", null },
                    { 14, "G", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Ducimus dolor nulla quia ratione voluptas officiis. Enim ullam asperiores ipsum quam pariatur consequuntur possimus non. Laudantium deleniti nemo ipsum sed qui distinctio.", "Ridley Scott", 137, new DateTime(2023, 9, 25, 23, 53, 22, 149, DateTimeKind.Utc).AddTicks(555), "Animación", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/596.jpg", "Dolorem nam expedita.", null },
                    { 15, "R", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "Natus illo consequatur deserunt assumenda vero odit voluptatem nulla nostrum. Rerum qui sunt ducimus incidunt et. Autem possimus ut repudiandae. Autem in reprehenderit explicabo temporibus quod. Voluptatem doloremque ducimus unde ut ducimus corrupti qui.", "Steven Spielberg", 173, new DateTime(2023, 6, 11, 9, 7, 45, 633, DateTimeKind.Utc).AddTicks(7572), "Ciencia Ficción", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/725.jpg", "Dolores id ducimus.", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "CreatedBy", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Ivy89" },
                    { 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Kasandra29" },
                    { 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Trisha0" },
                    { 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Emmie80" },
                    { 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Karlee.OHara" },
                    { 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Melyssa_Sawayn58" },
                    { 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Margret47" },
                    { 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Felipa.Bergnaum" },
                    { 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Zechariah.Tremblay" },
                    { 10, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Soledad72" },
                    { 11, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Chase88" },
                    { 12, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Hollis.Stroman19" },
                    { 13, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Victoria_Reichel49" },
                    { 14, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Jamal.Kuhn79" },
                    { 15, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Domenic_Bayer32" },
                    { 16, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Noble_Reichert4" },
                    { 17, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Mike.Wisoky27" },
                    { 18, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Sam56" },
                    { 19, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Dasia56" },
                    { 20, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Constance17" },
                    { 21, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Abdullah_Wiegand94" },
                    { 22, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Christina_Wiza" },
                    { 23, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Alysson_Leuschke" },
                    { 24, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Alicia.Cole19" },
                    { 25, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "D93591BDF7860E1E33F2024487C3D0D5", null, "Fiona.Koepp3" },
                    { 26, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", "81DC9BDB52D04DC223B621240E3DD8B7", null, "Juan" }
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "SalaId", "Capacidad", "CineId", "CreatedAt", "CreatedBy", "Numero", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 100, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 2, 200, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 3, 80, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 4, 200, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 5, 200, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 6, 150, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 7, 80, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 8, 100, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 9, 150, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 10, 80, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 11, 200, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 12, 100, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 13, 250, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 14, 250, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 15, 100, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 16, 150, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 17, 80, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 18, 80, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 19, 80, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 20, 250, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 21, 80, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 22, 200, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 23, 100, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 24, 80, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 25, 250, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 26, 80, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 27, 250, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 28, 200, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 29, 250, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 30, 80, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 31, 100, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 32, 80, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 33, 150, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 34, 100, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 35, 250, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 36, 150, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 37, 100, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 38, 100, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 39, 250, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 40, 150, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 41, 80, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 42, 200, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 43, 100, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 44, 200, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 45, 100, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 46, 250, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 47, 250, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 48, 200, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 49, 200, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 50, 100, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 51, 200, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 52, 100, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 53, 200, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 54, 200, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 55, 200, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 56, 200, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 57, 150, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 58, 200, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 59, 80, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 60, 100, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 61, 150, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 62, 100, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 63, 80, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 64, 150, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 65, 200, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 66, 100, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 67, 100, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 68, 80, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 69, 150, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 70, 150, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 71, 150, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 72, 150, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 73, 80, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 74, 200, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 75, 200, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 76, 250, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 77, 80, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 78, 250, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 79, 150, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 80, 250, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 81, 150, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 82, 150, 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 83, 150, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 84, 200, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 85, 250, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 86, 100, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 87, 200, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 88, 150, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 89, 80, 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 90, 200, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 91, 250, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 92, 100, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 93, 100, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 94, 150, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, null },
                    { 95, 100, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, null },
                    { 96, 80, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 97, 150, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 98, 100, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 99, 80, 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null },
                    { 100, 250, 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Funcion",
                columns: new[] { "FuncionId", "CreatedAt", "CreatedBy", "FechaHora", "PeliculaId", "Precio", "SalaId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 8, 12, 27, 58, 859, DateTimeKind.Utc).AddTicks(1727), 14, 15806m, 51, null },
                    { 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 16, 15, 40, 23, 879, DateTimeKind.Utc).AddTicks(7658), 2, 46855m, 18, null },
                    { 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 2, 0, 28, 12, 231, DateTimeKind.Utc).AddTicks(2967), 3, 10725m, 99, null },
                    { 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 7, 21, 4, 13, 149, DateTimeKind.Utc).AddTicks(9700), 10, 45258m, 84, null },
                    { 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 13, 5, 6, 30, 599, DateTimeKind.Utc).AddTicks(4868), 11, 18237m, 12, null },
                    { 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 16, 13, 3, 20, 714, DateTimeKind.Utc).AddTicks(6427), 12, 24170m, 95, null },
                    { 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 28, 7, 5, 50, 379, DateTimeKind.Utc).AddTicks(7638), 4, 45051m, 26, null },
                    { 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 12, 11, 39, 42, 161, DateTimeKind.Utc).AddTicks(2209), 4, 41478m, 31, null },
                    { 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 5, 12, 24, 0, 193, DateTimeKind.Utc).AddTicks(2252), 1, 37587m, 93, null },
                    { 10, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 18, 59, 6, 551, DateTimeKind.Utc).AddTicks(2337), 14, 24579m, 11, null },
                    { 11, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 22, 4, 43, 46, 911, DateTimeKind.Utc).AddTicks(8428), 8, 21040m, 90, null },
                    { 12, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 28, 17, 52, 51, 14, DateTimeKind.Utc).AddTicks(4022), 3, 17783m, 56, null },
                    { 13, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 8, 10, 39, 545, DateTimeKind.Utc).AddTicks(7456), 2, 46748m, 38, null },
                    { 14, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 11, 7, 26, 45, 101, DateTimeKind.Utc).AddTicks(2123), 13, 36284m, 52, null },
                    { 15, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 30, 3, 10, 24, 230, DateTimeKind.Utc).AddTicks(7697), 7, 22195m, 19, null },
                    { 16, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 9, 13, 11, 6, 982, DateTimeKind.Utc).AddTicks(6015), 11, 34984m, 64, null },
                    { 17, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 10, 16, 59, 13, 824, DateTimeKind.Utc).AddTicks(8389), 12, 45957m, 20, null },
                    { 18, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 2, 10, 30, 36, 285, DateTimeKind.Utc).AddTicks(8679), 1, 23784m, 41, null },
                    { 19, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 4, 2, 53, 11, 197, DateTimeKind.Utc).AddTicks(7872), 13, 36915m, 51, null },
                    { 20, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 23, 16, 14, 17, 503, DateTimeKind.Utc).AddTicks(8605), 10, 48914m, 86, null },
                    { 21, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 20, 25, 28, 176, DateTimeKind.Utc).AddTicks(9514), 5, 44140m, 40, null },
                    { 22, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 25, 3, 10, 7, 736, DateTimeKind.Utc).AddTicks(4690), 4, 32090m, 92, null },
                    { 23, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 6, 2, 8, 1, 564, DateTimeKind.Utc).AddTicks(4092), 6, 44450m, 45, null },
                    { 24, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 4, 15, 6, 12, 963, DateTimeKind.Utc).AddTicks(5135), 5, 22340m, 45, null },
                    { 25, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 11, 18, 30, 52, 189, DateTimeKind.Utc).AddTicks(9005), 3, 12191m, 94, null },
                    { 26, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 20, 10, 35, 18, 649, DateTimeKind.Utc).AddTicks(9938), 13, 16307m, 54, null },
                    { 27, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 24, 14, 7, 50, 896, DateTimeKind.Utc).AddTicks(6912), 12, 48037m, 58, null },
                    { 28, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 30, 21, 4, 47, 558, DateTimeKind.Utc).AddTicks(5698), 10, 20873m, 99, null },
                    { 29, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 18, 15, 29, 56, 898, DateTimeKind.Utc).AddTicks(2587), 4, 12317m, 85, null },
                    { 30, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 20, 23, 36, 19, 299, DateTimeKind.Utc).AddTicks(9736), 8, 15230m, 14, null },
                    { 31, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 7, 23, 7, 25, 672, DateTimeKind.Utc).AddTicks(8738), 9, 29390m, 32, null },
                    { 32, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 9, 6, 28, 27, 682, DateTimeKind.Utc).AddTicks(3283), 1, 26951m, 89, null },
                    { 33, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 21, 2, 20, 41, 757, DateTimeKind.Utc).AddTicks(6344), 10, 14027m, 74, null },
                    { 34, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 5, 15, 2, 2, 404, DateTimeKind.Utc).AddTicks(6073), 7, 48536m, 44, null },
                    { 35, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 20, 27, 5, 698, DateTimeKind.Utc).AddTicks(6712), 5, 34228m, 3, null },
                    { 36, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 4, 22, 8, 26, 977, DateTimeKind.Utc).AddTicks(6259), 10, 44198m, 61, null },
                    { 37, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 4, 12, 29, 8, 995, DateTimeKind.Utc).AddTicks(2755), 13, 47758m, 29, null },
                    { 38, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 5, 9, 16, 38, 715, DateTimeKind.Utc).AddTicks(8983), 10, 33983m, 71, null },
                    { 39, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 22, 7, 15, 4, 103, DateTimeKind.Utc).AddTicks(2626), 5, 39343m, 74, null },
                    { 40, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 18, 13, 14, 54, 40, DateTimeKind.Utc).AddTicks(7930), 7, 12661m, 48, null },
                    { 41, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 3, 14, 9, 47, 531, DateTimeKind.Utc).AddTicks(6722), 14, 17088m, 31, null },
                    { 42, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 8, 15, 12, 21, 244, DateTimeKind.Utc).AddTicks(8504), 10, 18310m, 58, null },
                    { 43, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 22, 8, 9, 34, 642, DateTimeKind.Utc).AddTicks(268), 4, 33558m, 57, null },
                    { 44, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 29, 4, 8, 27, 344, DateTimeKind.Utc).AddTicks(4746), 2, 49500m, 2, null },
                    { 45, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 7, 4, 16, 13, 259, DateTimeKind.Utc).AddTicks(2145), 2, 15522m, 31, null },
                    { 46, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 4, 16, 52, 679, DateTimeKind.Utc).AddTicks(4053), 8, 19174m, 96, null },
                    { 47, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 19, 4, 55, 30, 801, DateTimeKind.Utc).AddTicks(1362), 1, 35607m, 14, null },
                    { 48, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 7, 6, 26, 3, 75, DateTimeKind.Utc).AddTicks(8148), 7, 34186m, 39, null },
                    { 49, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 18, 7, 1, 21, 430, DateTimeKind.Utc).AddTicks(5037), 4, 23660m, 31, null },
                    { 50, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 2, 15, 1, 57, 175, DateTimeKind.Utc).AddTicks(4768), 12, 31526m, 63, null },
                    { 51, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 11, 22, 20, 12, 947, DateTimeKind.Utc).AddTicks(2049), 12, 43842m, 67, null },
                    { 52, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 7, 3, 44, 50, 130, DateTimeKind.Utc).AddTicks(2739), 9, 20543m, 44, null },
                    { 53, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 20, 0, 48, 19, 819, DateTimeKind.Utc).AddTicks(9230), 1, 28713m, 9, null },
                    { 54, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 20, 59, 5, 743, DateTimeKind.Utc).AddTicks(8043), 8, 46527m, 65, null },
                    { 55, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 14, 20, 28, 16, 807, DateTimeKind.Utc).AddTicks(7713), 2, 41593m, 99, null },
                    { 56, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 21, 9, 27, 40, 501, DateTimeKind.Utc).AddTicks(8220), 2, 22098m, 76, null },
                    { 57, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 2, 2, 53, 20, 623, DateTimeKind.Utc).AddTicks(6939), 6, 29775m, 29, null },
                    { 58, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 10, 2, 28, 32, 64, DateTimeKind.Utc).AddTicks(1744), 13, 10725m, 26, null },
                    { 59, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 15, 19, 50, 140, DateTimeKind.Utc).AddTicks(2102), 4, 11761m, 27, null },
                    { 60, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 11, 10, 1, 56, 101, DateTimeKind.Utc).AddTicks(777), 5, 36050m, 54, null },
                    { 61, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 10, 59, 2, 869, DateTimeKind.Utc).AddTicks(8010), 1, 37219m, 65, null },
                    { 62, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 19, 18, 1, 48, 905, DateTimeKind.Utc).AddTicks(1463), 10, 19779m, 26, null },
                    { 63, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 1, 57, 29, 995, DateTimeKind.Utc).AddTicks(2682), 9, 36142m, 31, null },
                    { 64, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 22, 12, 54, 28, 499, DateTimeKind.Utc).AddTicks(4527), 13, 21552m, 6, null },
                    { 65, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 6, 12, 36, 0, 612, DateTimeKind.Utc).AddTicks(3042), 2, 47690m, 55, null },
                    { 66, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 11, 4, 53, 38, 39, DateTimeKind.Utc).AddTicks(2809), 7, 30316m, 22, null },
                    { 67, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 1, 51, 12, 796, DateTimeKind.Utc).AddTicks(7768), 14, 49020m, 46, null },
                    { 68, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 26, 12, 36, 39, 268, DateTimeKind.Utc).AddTicks(2267), 13, 32681m, 15, null },
                    { 69, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 18, 17, 0, 6, 120, DateTimeKind.Utc).AddTicks(549), 9, 45469m, 45, null },
                    { 70, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 25, 17, 49, 12, 245, DateTimeKind.Utc).AddTicks(9599), 4, 29567m, 73, null },
                    { 71, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 24, 16, 4, 19, 865, DateTimeKind.Utc).AddTicks(3066), 4, 31677m, 79, null },
                    { 72, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 28, 9, 7, 37, 159, DateTimeKind.Utc).AddTicks(3977), 2, 49863m, 29, null },
                    { 73, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 18, 15, 11, 37, 49, DateTimeKind.Utc).AddTicks(6633), 11, 18330m, 22, null },
                    { 74, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 19, 3, 7, 6, 395, DateTimeKind.Utc).AddTicks(7899), 3, 44960m, 63, null },
                    { 75, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 20, 4, 22, 20, 505, DateTimeKind.Utc).AddTicks(5021), 9, 43797m, 83, null },
                    { 76, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 10, 5, 49, 53, 533, DateTimeKind.Utc).AddTicks(3680), 6, 14491m, 23, null },
                    { 77, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 15, 14, 30, 12, 188, DateTimeKind.Utc).AddTicks(8904), 7, 19359m, 7, null },
                    { 78, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 19, 14, 41, 7, 836, DateTimeKind.Utc).AddTicks(9170), 3, 36348m, 95, null },
                    { 79, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 12, 17, 20, 6, 483, DateTimeKind.Utc).AddTicks(1905), 11, 11477m, 86, null },
                    { 80, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 13, 22, 59, 22, 824, DateTimeKind.Utc).AddTicks(8103), 11, 47742m, 17, null },
                    { 81, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 23, 14, 5, 47, 189, DateTimeKind.Utc).AddTicks(7547), 9, 32842m, 58, null },
                    { 82, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 30, 14, 9, 33, 463, DateTimeKind.Utc).AddTicks(8061), 2, 41509m, 84, null },
                    { 83, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 16, 19, 47, 52, 180, DateTimeKind.Utc).AddTicks(6940), 13, 34669m, 39, null },
                    { 84, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 31, 7, 22, 42, 950, DateTimeKind.Utc).AddTicks(4935), 8, 39859m, 28, null },
                    { 85, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 29, 18, 53, 22, 996, DateTimeKind.Utc).AddTicks(9187), 7, 29316m, 60, null },
                    { 86, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 14, 54, 23, 790, DateTimeKind.Utc).AddTicks(4895), 10, 49230m, 88, null },
                    { 87, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 15, 9, 2, 27, 626, DateTimeKind.Utc).AddTicks(9270), 8, 14192m, 26, null },
                    { 88, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 19, 14, 16, 295, DateTimeKind.Utc).AddTicks(6636), 9, 36655m, 87, null },
                    { 89, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 21, 1, 15, 33, 986, DateTimeKind.Utc).AddTicks(3453), 3, 38024m, 21, null },
                    { 90, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 24, 12, 20, 16, 651, DateTimeKind.Utc).AddTicks(7714), 1, 32837m, 59, null },
                    { 91, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 26, 17, 13, 49, 588, DateTimeKind.Utc).AddTicks(3730), 4, 13819m, 96, null },
                    { 92, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 12, 0, 51, 14, 656, DateTimeKind.Utc).AddTicks(2674), 9, 26436m, 9, null },
                    { 93, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 1, 11, 34, 796, DateTimeKind.Utc).AddTicks(5687), 14, 24783m, 10, null },
                    { 94, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 22, 13, 35, 27, 691, DateTimeKind.Utc).AddTicks(6758), 10, 47259m, 40, null },
                    { 95, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 29, 2, 7, 43, 853, DateTimeKind.Utc).AddTicks(7901), 14, 38611m, 31, null },
                    { 96, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 1, 5, 8, 56, 836, DateTimeKind.Utc).AddTicks(353), 3, 27763m, 25, null },
                    { 97, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 17, 20, 30, 14, 811, DateTimeKind.Utc).AddTicks(3512), 5, 14592m, 56, null },
                    { 98, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 27, 11, 4, 45, 745, DateTimeKind.Utc).AddTicks(5191), 1, 47510m, 91, null },
                    { 99, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 20, 3, 57, 25, 780, DateTimeKind.Utc).AddTicks(7796), 1, 22114m, 48, null },
                    { 100, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 4, 18, 5, 0, 13, 204, DateTimeKind.Utc).AddTicks(9565), 8, 35013m, 76, null }
                });

            migrationBuilder.InsertData(
                table: "Entrada",
                columns: new[] { "EntradaId", "Cantidad", "CreatedAt", "CreatedBy", "FechaCompra", "FuncionId", "Total", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 29, 1, 28, 9, 3, DateTimeKind.Local).AddTicks(6232), 64, 16.134810907064560m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 26 },
                    { 2, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 26, 14, 5, 5, 974, DateTimeKind.Local).AddTicks(6070), 9, 247.495563009194400m, null, 16 },
                    { 3, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 27, 15, 6, 20, 141, DateTimeKind.Local).AddTicks(3527), 52, 35.879608961250720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 16 },
                    { 4, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 8, 14, 35, 58, 488, DateTimeKind.Local).AddTicks(1372), 43, 189.892654407148320m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 25 },
                    { 5, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 1, 17, 26, 39, 166, DateTimeKind.Local).AddTicks(758), 54, 102.040277905563840m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 18 },
                    { 6, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 28, 13, 4, 52, 848, DateTimeKind.Local).AddTicks(1151), 46, 180.683686578497920m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 10 },
                    { 7, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 2, 4, 12, 19, 120, DateTimeKind.Local).AddTicks(4728), 81, 111.309486522300120m, null, 23 },
                    { 8, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 23, 16, 57, 51, 329, DateTimeKind.Local).AddTicks(8847), 89, 112.676862155097800m, null, 3 },
                    { 9, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 13, 5, 6, 18, 953, DateTimeKind.Local).AddTicks(2036), 11, 49.127326477019280m, null, 15 },
                    { 10, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 4, 15, 5, 46, 178, DateTimeKind.Local).AddTicks(6960), 77, 26.4750535080593920m, null, 21 },
                    { 11, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 15, 14, 13, 7, 652, DateTimeKind.Local).AddTicks(7853), 67, 60.5625928999257800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 13 },
                    { 12, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 3, 14, 22, 12, 348, DateTimeKind.Local).AddTicks(1708), 5, 41.215611784882640m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 13, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 9, 0, 27, 28, 165, DateTimeKind.Local).AddTicks(6002), 76, 56.147964694637760m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 11 },
                    { 14, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 13, 4, 56, 56, 171, DateTimeKind.Local).AddTicks(9348), 99, 63.509634984944240m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 8 },
                    { 15, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 20, 16, 33, 4, 263, DateTimeKind.Local).AddTicks(2879), 100, 110.307246891010400m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 13 },
                    { 16, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 11, 6, 36, 7, 338, DateTimeKind.Local).AddTicks(1502), 68, 73.300451330175040m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 17, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 26, 21, 35, 48, 58, DateTimeKind.Local).AddTicks(8435), 99, 10.9988614962016480m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 15 },
                    { 18, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 4, 17, 49, 33, 499, DateTimeKind.Local).AddTicks(5598), 74, 93.348049970130240m, null, 13 },
                    { 19, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 6, 17, 33, 10, 110, DateTimeKind.Local).AddTicks(971), 36, 56.683392511052640m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 13 },
                    { 20, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 4, 20, 1, 7, 944, DateTimeKind.Local).AddTicks(3146), 95, 183.639055694828000m, null, 1 },
                    { 21, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 30, 1, 49, 19, 325, DateTimeKind.Local).AddTicks(3410), 88, 156.672706143126800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 14 },
                    { 22, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 2, 0, 40, 42, 831, DateTimeKind.Local).AddTicks(8271), 10, 163.315969451402880m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 23, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 7, 11, 50, 41, 397, DateTimeKind.Local).AddTicks(7584), 45, 23.532917639489920m, null, 23 },
                    { 24, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 8, 12, 41, 18, 678, DateTimeKind.Local).AddTicks(4172), 23, 128.173183517968800m, null, 2 },
                    { 25, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 5, 6, 5, 19, 355, DateTimeKind.Local).AddTicks(9495), 36, 84.071144010747520m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 26 },
                    { 26, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 10, 18, 46, 23, 106, DateTimeKind.Local).AddTicks(1822), 57, 65.373383134744960m, null, 25 },
                    { 27, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 15, 1, 30, 25, 635, DateTimeKind.Local).AddTicks(2766), 98, 48.765101433001440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 28, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 20, 8, 38, 43, 631, DateTimeKind.Local).AddTicks(4834), 65, 111.654791937776160m, null, 3 },
                    { 29, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 30, 15, 44, 36, 714, DateTimeKind.Local).AddTicks(2358), 14, 62.475029638386720m, null, 20 },
                    { 30, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 3, 2, 57, 53, 800, DateTimeKind.Local).AddTicks(2059), 30, 92.551411771091360m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 26 },
                    { 31, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 21, 8, 57, 23, 601, DateTimeKind.Local).AddTicks(7972), 54, 55.3997696947173760m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 14 },
                    { 32, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 26, 8, 29, 21, 939, DateTimeKind.Local).AddTicks(3434), 24, 195.334313035379840m, null, 15 },
                    { 33, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 21, 4, 30, 51, 404, DateTimeKind.Local).AddTicks(1157), 91, 84.335480715677360m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 34, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 10, 13, 10, 56, 453, DateTimeKind.Local).AddTicks(5956), 90, 30.736618398310960m, null, 1 },
                    { 35, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 10, 3, 26, 22, 268, DateTimeKind.Local).AddTicks(9853), 52, 56.382308903660880m, null, 2 },
                    { 36, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 3, 23, 38, 18, 763, DateTimeKind.Local).AddTicks(6786), 54, 32.185760142749720m, null, 10 },
                    { 37, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 26, 19, 5, 4, 199, DateTimeKind.Local).AddTicks(1285), 91, 140.502706927638200m, null, 11 },
                    { 38, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 9, 20, 27, 14, 428, DateTimeKind.Local).AddTicks(4087), 25, 35.622581115101280m, null, 23 },
                    { 39, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 10, 4, 51, 56, 280, DateTimeKind.Local).AddTicks(4518), 2, 25.6185563380930080m, null, 17 },
                    { 40, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 26, 19, 26, 49, 12, DateTimeKind.Local).AddTicks(7408), 3, 45.712088317790880m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 15 },
                    { 41, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 9, 16, 11, 4, 850, DateTimeKind.Local).AddTicks(586), 97, 113.069263590313800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 17 },
                    { 42, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 30, 6, 15, 59, 133, DateTimeKind.Local).AddTicks(2077), 41, 70.446528919988480m, null, 26 },
                    { 43, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 26, 4, 46, 40, 607, DateTimeKind.Local).AddTicks(3395), 58, 13.4405196864091280m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 44, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 4, 10, 37, 48, 556, DateTimeKind.Local).AddTicks(7274), 16, 84.265595623027680m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 12 },
                    { 45, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 18, 23, 55, 18, 8, DateTimeKind.Local).AddTicks(5363), 56, 78.136701411063040m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 3 },
                    { 46, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 3, 23, 14, 29, 70, DateTimeKind.Local).AddTicks(902), 61, 97.785051048961280m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 47, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 4, 16, 58, 1, 274, DateTimeKind.Local).AddTicks(6853), 96, 45.523585792177440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 18 },
                    { 48, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 10, 7, 58, 18, 899, DateTimeKind.Local).AddTicks(1825), 41, 230.072177416306600m, null, 17 },
                    { 49, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 4, 7, 56, 46, 344, DateTimeKind.Local).AddTicks(5975), 85, 43.708833705099840m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 10 },
                    { 50, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 24, 0, 42, 5, 594, DateTimeKind.Local).AddTicks(3595), 55, 44.422615046052960m, null, 1 },
                    { 51, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 6, 11, 35, 18, 286, DateTimeKind.Local).AddTicks(3803), 97, 129.222630651593040m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 25 },
                    { 52, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 7, 15, 1, 6, 2, DateTimeKind.Local).AddTicks(1923), 82, 61.993576769504720m, null, 8 },
                    { 53, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 15, 22, 8, 57, 156, DateTimeKind.Local).AddTicks(1723), 38, 60.169754475928920m, null, 17 },
                    { 54, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 6, 12, 10, 6, 213, DateTimeKind.Local).AddTicks(8091), 59, 192.954523335909800m, null, 17 },
                    { 55, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 20, 2, 52, 5, 822, DateTimeKind.Local).AddTicks(516), 43, 43.315927962287120m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 16 },
                    { 56, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 18, 1, 57, 8, 833, DateTimeKind.Local).AddTicks(5860), 69, 36.489566507870600m, null, 21 },
                    { 57, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 15, 3, 43, 35, 464, DateTimeKind.Local).AddTicks(5562), 59, 112.612250155646560m, null, 20 },
                    { 58, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 3, 5, 5, 32, 440, DateTimeKind.Local).AddTicks(3356), 58, 91.953874440367920m, null, 11 },
                    { 59, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 26, 14, 43, 44, 500, DateTimeKind.Local).AddTicks(2294), 9, 43.628519457993720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 8 },
                    { 60, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 16, 20, 46, 17, 272, DateTimeKind.Local).AddTicks(7302), 38, 18.496722530323440m, null, 14 },
                    { 61, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 15, 1, 3, 47, 588, DateTimeKind.Local).AddTicks(7372), 90, 10.5463267512336440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 62, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 23, 23, 37, 20, 173, DateTimeKind.Local).AddTicks(2380), 70, 10.740893022486520m, null, 6 },
                    { 63, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 28, 9, 16, 51, 260, DateTimeKind.Local).AddTicks(9683), 52, 37.664692012170960m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 14 },
                    { 64, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 15, 14, 7, 11, 567, DateTimeKind.Local).AddTicks(9423), 34, 47.186884750630920m, null, 2 },
                    { 65, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 15, 6, 27, 15, 647, DateTimeKind.Local).AddTicks(5636), 58, 41.001155274912360m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 66, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 13, 8, 44, 11, 122, DateTimeKind.Local).AddTicks(8039), 35, 33.237495757604560m, null, 3 },
                    { 67, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 26, 11, 35, 0, 816, DateTimeKind.Local).AddTicks(988), 96, 33.648945440398200m, null, 10 },
                    { 68, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 3, 17, 6, 51, 678, DateTimeKind.Local).AddTicks(2379), 20, 96.481232562222600m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 69, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 12, 13, 5, 37, 482, DateTimeKind.Local).AddTicks(3968), 85, 119.785439097204720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 21 },
                    { 70, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 25, 1, 34, 33, 551, DateTimeKind.Local).AddTicks(591), 22, 105.667279163142400m, null, 16 },
                    { 71, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 26, 15, 6, 36, 833, DateTimeKind.Local).AddTicks(7251), 81, 40.8037792655647080m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 72, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 7, 7, 16, 5, 838, DateTimeKind.Local).AddTicks(6366), 85, 29.299924789858720m, null, 14 },
                    { 73, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 9, 5, 33, 57, 337, DateTimeKind.Local).AddTicks(5975), 11, 32.286276927955880m, null, 14 },
                    { 74, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 15, 20, 37, 33, 408, DateTimeKind.Local).AddTicks(5299), 92, 52.587605979587440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 11 },
                    { 75, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 17, 3, 52, 55, 76, DateTimeKind.Local).AddTicks(7616), 81, 227.305368738870600m, null, 6 },
                    { 76, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 22, 7, 7, 24, 439, DateTimeKind.Local).AddTicks(2160), 31, 77.212419877680080m, null, 3 },
                    { 77, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 30, 0, 31, 25, 294, DateTimeKind.Local).AddTicks(3122), 77, 28.537691722862040m, null, 8 },
                    { 78, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 4, 15, 49, 12, 654, DateTimeKind.Local).AddTicks(2707), 61, 141.562129737830720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 79, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 13, 20, 25, 10, 916, DateTimeKind.Local).AddTicks(8506), 99, 85.629359268760080m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 15 },
                    { 80, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 22, 19, 37, 56, 527, DateTimeKind.Local).AddTicks(5540), 6, 64.421479618778640m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 25 },
                    { 81, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 16, 11, 30, 5, 28, DateTimeKind.Local).AddTicks(3608), 33, 91.381083324565760m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 3 },
                    { 82, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 4, 14, 17, 51, 487, DateTimeKind.Local).AddTicks(1012), 98, 115.705707424783520m, null, 19 },
                    { 83, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 11, 17, 39, 1, 660, DateTimeKind.Local).AddTicks(6059), 11, 192.565655335417200m, null, 26 },
                    { 84, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 14, 11, 32, 1, 859, DateTimeKind.Local).AddTicks(9469), 37, 93.493221272374720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 11 },
                    { 85, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 22, 12, 39, 11, 475, DateTimeKind.Local).AddTicks(4954), 95, 58.3172680895853600m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 6 },
                    { 86, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 24, 0, 30, 44, 128, DateTimeKind.Local).AddTicks(5166), 91, 96.201358080689680m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 87, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 2, 10, 58, 55, 910, DateTimeKind.Local).AddTicks(3522), 30, 16.730137409945760m, null, 11 },
                    { 88, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 9, 11, 33, 19, 540, DateTimeKind.Local).AddTicks(5482), 66, 82.022766301484520m, null, 2 },
                    { 89, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 4, 11, 56, 52, 196, DateTimeKind.Local).AddTicks(4863), 79, 49.425046756756040m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 8 },
                    { 90, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 3, 9, 2, 32, 889, DateTimeKind.Local).AddTicks(326), 94, 11.0619544537695360m, null, 22 },
                    { 91, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 7, 23, 44, 4, 922, DateTimeKind.Local).AddTicks(4871), 87, 60.208466382194720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 2 },
                    { 92, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 4, 21, 58, 32, 63, DateTimeKind.Local).AddTicks(4841), 61, 67.22018824771800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 18 },
                    { 93, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 6, 5, 37, 35, 711, DateTimeKind.Local).AddTicks(7295), 69, 102.113717814068600m, null, 1 },
                    { 94, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 8, 1, 30, 28, 330, DateTimeKind.Local).AddTicks(468), 81, 91.787139658186800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 20 },
                    { 95, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 6, 4, 49, 9, 29, DateTimeKind.Local).AddTicks(4741), 25, 82.750373490373800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 24 },
                    { 96, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 12, 17, 0, 32, 696, DateTimeKind.Local).AddTicks(3839), 11, 43.3834156408118720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 15 },
                    { 97, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 15, 11, 6, 15, 856, DateTimeKind.Local).AddTicks(6224), 57, 180.673548546493600m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 26 },
                    { 98, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 31, 19, 46, 29, 21, DateTimeKind.Local).AddTicks(8902), 59, 90.599384582029040m, null, 20 },
                    { 99, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 1, 16, 36, 40, 676, DateTimeKind.Local).AddTicks(7414), 69, 142.497779500176200m, null, 3 },
                    { 100, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 16, 3, 27, 34, 271, DateTimeKind.Local).AddTicks(6138), 19, 89.396114405250720m, null, 19 },
                    { 101, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 16, 0, 22, 29, 110, DateTimeKind.Local).AddTicks(4832), 42, 169.442294023417920m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 2 },
                    { 102, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 11, 21, 8, 22, 808, DateTimeKind.Local).AddTicks(75), 98, 35.488529974889920m, null, 23 },
                    { 103, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 11, 18, 23, 16, 823, DateTimeKind.Local).AddTicks(6325), 90, 51.456103600118480m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 8 },
                    { 104, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 12, 23, 30, 49, 285, DateTimeKind.Local).AddTicks(7570), 10, 11.9620350483033360m, null, 26 },
                    { 105, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 5, 3, 31, 31, 387, DateTimeKind.Local).AddTicks(7052), 91, 14.715707716111440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 11 },
                    { 106, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 25, 16, 40, 27, 654, DateTimeKind.Local).AddTicks(698), 66, 21.957750589231880m, null, 10 },
                    { 107, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 13, 12, 52, 29, 758, DateTimeKind.Local).AddTicks(2614), 99, 59.510785113407520m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 10 },
                    { 108, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 26, 22, 3, 5, 891, DateTimeKind.Local).AddTicks(8303), 75, 71.010073281622800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 109, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 21, 22, 40, 50, 536, DateTimeKind.Local).AddTicks(8770), 84, 17.949706054462200m, null, 10 },
                    { 110, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 20, 3, 53, 54, 473, DateTimeKind.Local).AddTicks(3306), 76, 49.405867048303360m, null, 15 },
                    { 111, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 9, 13, 22, 55, 757, DateTimeKind.Local).AddTicks(8205), 91, 117.497481111908800m, null, 12 },
                    { 112, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 25, 14, 37, 5, 725, DateTimeKind.Local).AddTicks(689), 97, 235.095153193343000m, null, 10 },
                    { 113, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 8, 3, 55, 47, 827, DateTimeKind.Local).AddTicks(6737), 56, 139.186300525999080m, null, 3 },
                    { 114, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 6, 10, 20, 24, 882, DateTimeKind.Local).AddTicks(2940), 55, 32.042257786861480m, null, 15 },
                    { 115, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 4, 19, 58, 10, 346, DateTimeKind.Local).AddTicks(5637), 38, 92.607115208596720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 116, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 22, 21, 10, 46, 961, DateTimeKind.Local).AddTicks(1686), 26, 72.202500186763040m, null, 20 },
                    { 117, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 9, 10, 37, 3, 998, DateTimeKind.Local).AddTicks(6555), 20, 33.23863328169000m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 118, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 19, 8, 47, 25, 270, DateTimeKind.Local).AddTicks(6485), 33, 82.085017537280800m, null, 12 },
                    { 119, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 30, 4, 51, 3, 925, DateTimeKind.Local).AddTicks(637), 17, 45.012293688493680m, null, 8 },
                    { 120, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 15, 19, 7, 30, 23, DateTimeKind.Local).AddTicks(8955), 97, 33.3325731255808560m, null, 18 },
                    { 121, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 11, 9, 57, 58, 227, DateTimeKind.Local).AddTicks(8156), 59, 74.65148736940080m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 22 },
                    { 122, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 30, 15, 0, 46, 71, DateTimeKind.Local).AddTicks(8424), 57, 26.053870397786640m, null, 17 },
                    { 123, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 30, 15, 1, 41, 936, DateTimeKind.Local).AddTicks(7746), 18, 77.690681988798720m, null, 3 },
                    { 124, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 22, 1, 52, 54, 869, DateTimeKind.Local).AddTicks(8990), 6, 55.338401470025920m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 18 },
                    { 125, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 20, 4, 9, 20, 407, DateTimeKind.Local).AddTicks(6924), 23, 37.695753096675800m, null, 13 },
                    { 126, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 26, 4, 36, 39, 416, DateTimeKind.Local).AddTicks(9429), 58, 116.135215138320400m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 127, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 21, 7, 10, 35, 607, DateTimeKind.Local).AddTicks(3993), 29, 56.587065632089760m, null, 2 },
                    { 128, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 30, 21, 36, 29, 591, DateTimeKind.Local).AddTicks(720), 30, 83.186413407229760m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 6 },
                    { 129, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 6, 1, 56, 47, 174, DateTimeKind.Local).AddTicks(4414), 87, 24.9882694172035040m, null, 18 },
                    { 130, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 21, 16, 56, 25, 479, DateTimeKind.Local).AddTicks(2458), 73, 62.85003685015600m, null, 1 },
                    { 131, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 26, 12, 30, 29, 139, DateTimeKind.Local).AddTicks(535), 60, 180.435722984446720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 132, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 22, 21, 6, 42, 286, DateTimeKind.Local).AddTicks(4139), 31, 163.715790753109800m, null, 23 },
                    { 133, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 12, 17, 33, 56, 173, DateTimeKind.Local).AddTicks(1007), 7, 83.857799248877440m, null, 16 },
                    { 134, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 10, 23, 45, 20, 82, DateTimeKind.Local).AddTicks(8881), 27, 89.903261469739120m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 24 },
                    { 135, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 24, 19, 34, 54, 530, DateTimeKind.Local).AddTicks(5046), 42, 169.205766920786800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 22 },
                    { 136, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 24, 17, 2, 7, 592, DateTimeKind.Local).AddTicks(2961), 97, 79.132199746355520m, null, 26 },
                    { 137, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 20, 13, 18, 47, 659, DateTimeKind.Local).AddTicks(9691), 17, 49.051982386527040m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 25 },
                    { 138, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 2, 17, 27, 14, 640, DateTimeKind.Local).AddTicks(3559), 29, 71.70047111592160m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 6 },
                    { 139, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 23, 19, 4, 50, 83, DateTimeKind.Local).AddTicks(6479), 96, 46.783201209535960m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 140, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 23, 23, 36, 10, 706, DateTimeKind.Local).AddTicks(7100), 43, 54.4199640098951200m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 141, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 12, 3, 20, 18, 751, DateTimeKind.Local).AddTicks(8963), 16, 103.707189268148880m, null, 9 },
                    { 142, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 8, 15, 57, 31, 992, DateTimeKind.Local).AddTicks(5723), 5, 21.304531496465840m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 20 },
                    { 143, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 19, 11, 2, 27, 231, DateTimeKind.Local).AddTicks(4469), 86, 56.858461695232680m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 10 },
                    { 144, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 27, 7, 39, 14, 260, DateTimeKind.Local).AddTicks(4662), 70, 46.742223342477200m, null, 17 },
                    { 145, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 30, 7, 58, 14, 124, DateTimeKind.Local).AddTicks(8786), 16, 157.630615095088640m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 12 },
                    { 146, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 7, 13, 34, 19, 538, DateTimeKind.Local).AddTicks(6686), 21, 248.33125382155600m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 12 },
                    { 147, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 12, 14, 49, 57, 224, DateTimeKind.Local).AddTicks(8758), 4, 121.167690927167520m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 5 },
                    { 148, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 25, 2, 41, 12, 842, DateTimeKind.Local).AddTicks(5514), 95, 40.697511045159240m, null, 22 },
                    { 149, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 31, 0, 58, 44, 736, DateTimeKind.Local).AddTicks(5172), 71, 37.71896618875920m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 26 },
                    { 150, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 7, 10, 6, 31, 992, DateTimeKind.Local).AddTicks(5355), 15, 48.326024377528080m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 151, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 20, 18, 19, 21, 726, DateTimeKind.Local).AddTicks(2448), 95, 123.830445872976720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 12 },
                    { 152, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 2, 15, 3, 46, 776, DateTimeKind.Local).AddTicks(1837), 33, 99.677519069432400m, null, 26 },
                    { 153, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 13, 17, 22, 58, 632, DateTimeKind.Local).AddTicks(8352), 4, 127.722872667005440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 154, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 22, 11, 48, 11, 232, DateTimeKind.Local).AddTicks(983), 23, 121.83022207448200m, null, 18 },
                    { 155, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 2, 0, 36, 2, 914, DateTimeKind.Local).AddTicks(4046), 33, 68.750008094751360m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 24 },
                    { 156, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 15, 14, 31, 41, 780, DateTimeKind.Local).AddTicks(9087), 11, 90.1011439047280m, null, 1 },
                    { 157, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 20, 19, 33, 54, 39, DateTimeKind.Local).AddTicks(5674), 94, 66.959631172853040m, null, 3 },
                    { 158, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 21, 4, 54, 42, 52, DateTimeKind.Local).AddTicks(2045), 80, 70.302327205080320m, null, 21 },
                    { 159, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 7, 20, 18, 26, 334, DateTimeKind.Local).AddTicks(2752), 7, 193.676741770433920m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 7 },
                    { 160, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 18, 2, 53, 13, 490, DateTimeKind.Local).AddTicks(2910), 52, 219.691468489313200m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 2 },
                    { 161, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 15, 21, 50, 33, 866, DateTimeKind.Local).AddTicks(633), 90, 40.359160990404880m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 19 },
                    { 162, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 21, 12, 49, 25, 936, DateTimeKind.Local).AddTicks(8622), 33, 239.710259402761800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 25 },
                    { 163, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 17, 20, 57, 4, 647, DateTimeKind.Local).AddTicks(2511), 30, 135.712518319720320m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 164, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 31, 10, 56, 6, 114, DateTimeKind.Local).AddTicks(17), 67, 89.892618375677040m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 20 },
                    { 165, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 3, 10, 15, 18, 301, DateTimeKind.Local).AddTicks(6436), 45, 53.9122377324600800m, null, 24 },
                    { 166, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 19, 22, 28, 47, 626, DateTimeKind.Local).AddTicks(7546), 89, 13.7194752102441560m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 167, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 8, 8, 21, 15, 636, DateTimeKind.Local).AddTicks(9298), 54, 39.936591704652480m, null, 3 },
                    { 168, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 5, 4, 27, 10, 783, DateTimeKind.Local).AddTicks(5517), 97, 19.272642133008520m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 169, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 15, 13, 15, 29, 486, DateTimeKind.Local).AddTicks(9263), 39, 30.903543830386560m, null, 9 },
                    { 170, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 27, 9, 50, 11, 585, DateTimeKind.Local).AddTicks(7699), 90, 31.114359983824320m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 171, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 11, 19, 2, 15, 735, DateTimeKind.Local).AddTicks(1379), 6, 16.711381457495120m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 172, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 3, 26, 12, 7, 8, 999, DateTimeKind.Local).AddTicks(2793), 24, 145.703059354482720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 10 },
                    { 173, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 19, 19, 55, 7, 730, DateTimeKind.Local).AddTicks(1521), 58, 93.476905684498720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 8 },
                    { 174, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 2, 0, 23, 6, 271, DateTimeKind.Local).AddTicks(1736), 14, 43.716134602977440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 175, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 11, 19, 6, 56, 523, DateTimeKind.Local).AddTicks(1147), 66, 173.969139470843200m, null, 1 },
                    { 176, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 19, 1, 1, 50, 432, DateTimeKind.Local).AddTicks(625), 97, 161.021636822184800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 177, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 2, 2, 16, 53, 825, DateTimeKind.Local).AddTicks(5930), 18, 62.8215986882776600m, null, 22 },
                    { 178, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 9, 7, 59, 35, 697, DateTimeKind.Local).AddTicks(9203), 72, 82.20940030889800m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 13 },
                    { 179, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 31, 21, 41, 59, 496, DateTimeKind.Local).AddTicks(5549), 99, 149.483682700003200m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 23 },
                    { 180, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 8, 16, 21, 6, 50, 336, DateTimeKind.Local).AddTicks(2041), 56, 59.690069873296560m, null, 1 },
                    { 181, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 22, 12, 56, 8, 824, DateTimeKind.Local).AddTicks(6030), 48, 184.089806184835360m, null, 21 },
                    { 182, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 12, 0, 31, 5, 20, DateTimeKind.Local).AddTicks(740), 34, 25.098185232275000m, null, 15 },
                    { 183, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 13, 7, 8, 33, 238, DateTimeKind.Local).AddTicks(4987), 68, 63.970566595556080m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 17 },
                    { 184, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 5, 18, 16, 44, 30, 390, DateTimeKind.Local).AddTicks(505), 37, 103.980262768845600m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 7 },
                    { 185, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 9, 27, 4, 14, 25, 840, DateTimeKind.Local).AddTicks(7208), 19, 120.976517694321240m, null, 10 },
                    { 186, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 4, 27, 2, 15, 25, 896, DateTimeKind.Local).AddTicks(1656), 10, 10.2251677569381360m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 9 },
                    { 187, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 7, 13, 11, 53, 8, 886, DateTimeKind.Local).AddTicks(149), 69, 162.470035181479400m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 1 },
                    { 188, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 21, 5, 41, 3, 111, DateTimeKind.Local).AddTicks(1568), 82, 14.500208523883640m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 12 },
                    { 189, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 2, 12, 22, 15, 543, DateTimeKind.Local).AddTicks(9967), 79, 124.078006381707720m, null, 8 },
                    { 190, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 12, 15, 18, 15, 12, 670, DateTimeKind.Local).AddTicks(731), 13, 182.637514410391680m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 25 },
                    { 191, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 6, 27, 5, 16, 44, 528, DateTimeKind.Local).AddTicks(9714), 23, 83.755013936264200m, null, 20 },
                    { 192, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 14, 9, 8, 12, 321, DateTimeKind.Local).AddTicks(7451), 77, 43.164857630190480m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 12 },
                    { 193, 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 2, 18, 17, 0, 25, 717, DateTimeKind.Local).AddTicks(1928), 89, 133.444634118952320m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 24 },
                    { 194, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 24, 13, 1, 30, 440, DateTimeKind.Local).AddTicks(5749), 76, 76.108830192619440m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 4 },
                    { 195, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 31, 22, 2, 32, 874, DateTimeKind.Local).AddTicks(1585), 87, 99.583221902270600m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 18 },
                    { 196, 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 17, 16, 7, 1, 618, DateTimeKind.Local).AddTicks(322), 39, 23.55112160982680m, null, 23 },
                    { 197, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 3, 21, 2, 21, 29, 83, DateTimeKind.Local).AddTicks(9701), 38, 85.194323763532320m, null, 14 },
                    { 198, 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 11, 15, 18, 28, 54, 363, DateTimeKind.Local).AddTicks(142), 24, 37.877528146359680m, null, 26 },
                    { 199, 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2025, 1, 2, 1, 26, 14, 949, DateTimeKind.Local).AddTicks(6426), 13, 98.377907467502720m, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), 8 },
                    { 200, 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", new DateTime(2024, 10, 21, 23, 3, 48, 451, DateTimeKind.Local).AddTicks(8453), 53, 117.76479585635800m, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "PagoId", "CreatedAt", "CreatedBy", "EntradaId", "Estado", "FechaPago", "MetodoPago", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 1, "Pagado", new DateTime(2024, 6, 6, 22, 52, 22, 870, DateTimeKind.Local).AddTicks(8546), "Efectivo", null },
                    { 2, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 2, "Pendiente", new DateTime(2024, 11, 22, 22, 52, 51, 874, DateTimeKind.Local).AddTicks(5164), "Efectivo", null },
                    { 3, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 3, "Fallido", new DateTime(2024, 6, 1, 22, 35, 20, 351, DateTimeKind.Local).AddTicks(8464), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 4, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 4, "Pagado", new DateTime(2024, 3, 31, 0, 36, 8, 823, DateTimeKind.Local).AddTicks(8777), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 5, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 5, "Pendiente", new DateTime(2024, 12, 7, 10, 13, 20, 427, DateTimeKind.Local).AddTicks(2738), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 6, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 6, "Pendiente", new DateTime(2024, 5, 11, 7, 20, 23, 372, DateTimeKind.Local).AddTicks(2187), "Efectivo", null },
                    { 7, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 7, "Fallido", new DateTime(2024, 12, 9, 6, 20, 31, 141, DateTimeKind.Local).AddTicks(5368), "Efectivo", null },
                    { 8, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 8, "Pendiente", new DateTime(2024, 12, 2, 7, 23, 48, 586, DateTimeKind.Local).AddTicks(5882), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 9, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 9, "Pendiente", new DateTime(2025, 1, 15, 19, 21, 21, 145, DateTimeKind.Local).AddTicks(8516), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 10, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 10, "Pendiente", new DateTime(2024, 8, 7, 17, 22, 15, 363, DateTimeKind.Local).AddTicks(7947), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 11, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 11, "Fallido", new DateTime(2024, 10, 19, 1, 36, 42, 779, DateTimeKind.Local).AddTicks(6801), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 12, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 12, "Pendiente", new DateTime(2024, 10, 29, 10, 47, 16, 344, DateTimeKind.Local).AddTicks(240), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 13, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 13, "Fallido", new DateTime(2024, 6, 1, 16, 32, 43, 178, DateTimeKind.Local).AddTicks(3337), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 14, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 14, "Pendiente", new DateTime(2024, 12, 17, 10, 50, 14, 213, DateTimeKind.Local).AddTicks(9852), "Nequi", null },
                    { 15, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 15, "Pagado", new DateTime(2024, 9, 24, 2, 7, 53, 106, DateTimeKind.Local).AddTicks(1898), "Efectivo", null },
                    { 16, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 16, "Pagado", new DateTime(2025, 2, 24, 12, 7, 15, 300, DateTimeKind.Local).AddTicks(6565), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 17, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 17, "Pagado", new DateTime(2024, 8, 14, 13, 35, 41, 55, DateTimeKind.Local).AddTicks(4018), "PSE", null },
                    { 18, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 18, "Pendiente", new DateTime(2025, 2, 19, 7, 43, 34, 415, DateTimeKind.Local).AddTicks(6492), "PSE", null },
                    { 19, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 19, "Pagado", new DateTime(2024, 6, 17, 8, 51, 37, 436, DateTimeKind.Local).AddTicks(476), "Efectivo", null },
                    { 20, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 20, "Pagado", new DateTime(2024, 5, 28, 21, 19, 23, 388, DateTimeKind.Local).AddTicks(1309), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 21, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 21, "Pendiente", new DateTime(2024, 8, 22, 7, 8, 39, 29, DateTimeKind.Local).AddTicks(5528), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 22, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 22, "Pendiente", new DateTime(2025, 2, 27, 3, 26, 13, 928, DateTimeKind.Local).AddTicks(8089), "Efectivo", null },
                    { 23, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 23, "Pendiente", new DateTime(2024, 4, 19, 7, 58, 9, 820, DateTimeKind.Local).AddTicks(3402), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 24, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 24, "Pendiente", new DateTime(2024, 12, 2, 12, 9, 41, 407, DateTimeKind.Local).AddTicks(4518), "PSE", null },
                    { 25, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 25, "Fallido", new DateTime(2025, 1, 10, 9, 49, 30, 289, DateTimeKind.Local).AddTicks(2547), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 26, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 26, "Fallido", new DateTime(2024, 11, 15, 23, 1, 0, 157, DateTimeKind.Local).AddTicks(4715), "PSE", null },
                    { 27, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 27, "Pendiente", new DateTime(2024, 4, 27, 10, 23, 39, 137, DateTimeKind.Local).AddTicks(4064), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 28, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 28, "Pendiente", new DateTime(2024, 8, 4, 3, 22, 2, 386, DateTimeKind.Local).AddTicks(6680), "Nequi", null },
                    { 29, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 29, "Fallido", new DateTime(2024, 5, 12, 18, 33, 15, 410, DateTimeKind.Local).AddTicks(9396), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 30, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 30, "Fallido", new DateTime(2024, 9, 6, 2, 17, 51, 475, DateTimeKind.Local).AddTicks(8977), "PSE", null },
                    { 31, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 31, "Pagado", new DateTime(2024, 8, 18, 0, 5, 34, 575, DateTimeKind.Local).AddTicks(2150), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 32, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 32, "Fallido", new DateTime(2024, 10, 18, 10, 58, 9, 2, DateTimeKind.Local).AddTicks(8523), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 33, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 33, "Pagado", new DateTime(2025, 2, 20, 0, 16, 59, 693, DateTimeKind.Local).AddTicks(9984), "Efectivo", null },
                    { 34, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 34, "Pendiente", new DateTime(2024, 9, 4, 14, 53, 35, 935, DateTimeKind.Local).AddTicks(50), "Tarjeta", null },
                    { 35, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 35, "Pendiente", new DateTime(2025, 2, 10, 11, 47, 42, 358, DateTimeKind.Local).AddTicks(6158), "Efectivo", null },
                    { 36, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 36, "Pendiente", new DateTime(2024, 12, 2, 22, 37, 11, 258, DateTimeKind.Local).AddTicks(9310), "Tarjeta", null },
                    { 37, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 37, "Pendiente", new DateTime(2024, 5, 16, 19, 57, 17, 191, DateTimeKind.Local).AddTicks(9571), "Efectivo", null },
                    { 38, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 38, "Fallido", new DateTime(2024, 10, 29, 5, 19, 23, 496, DateTimeKind.Local).AddTicks(9183), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 39, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 39, "Fallido", new DateTime(2024, 6, 19, 22, 19, 8, 101, DateTimeKind.Local).AddTicks(3516), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 40, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 40, "Fallido", new DateTime(2024, 5, 31, 11, 43, 30, 698, DateTimeKind.Local).AddTicks(2901), "Efectivo", null },
                    { 41, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 41, "Pendiente", new DateTime(2024, 6, 3, 1, 15, 20, 100, DateTimeKind.Local).AddTicks(4662), "PSE", null },
                    { 42, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 42, "Pagado", new DateTime(2024, 12, 21, 23, 48, 38, 295, DateTimeKind.Local).AddTicks(5507), "Efectivo", null },
                    { 43, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 43, "Fallido", new DateTime(2024, 12, 21, 2, 38, 44, 183, DateTimeKind.Local).AddTicks(375), "Nequi", null },
                    { 44, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 44, "Pagado", new DateTime(2024, 6, 9, 20, 7, 19, 844, DateTimeKind.Local).AddTicks(2709), "PSE", null },
                    { 45, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 45, "Pendiente", new DateTime(2024, 4, 11, 14, 40, 21, 479, DateTimeKind.Local).AddTicks(9997), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 46, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 46, "Pendiente", new DateTime(2025, 3, 17, 9, 59, 25, 782, DateTimeKind.Local).AddTicks(6064), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 47, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 47, "Pagado", new DateTime(2024, 10, 17, 15, 39, 58, 72, DateTimeKind.Local).AddTicks(3167), "Nequi", null },
                    { 48, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 48, "Pagado", new DateTime(2025, 2, 2, 8, 19, 13, 135, DateTimeKind.Local).AddTicks(4311), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 49, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 49, "Pendiente", new DateTime(2024, 10, 2, 16, 56, 57, 827, DateTimeKind.Local).AddTicks(4881), "PSE", null },
                    { 50, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 50, "Pendiente", new DateTime(2024, 7, 3, 3, 18, 47, 372, DateTimeKind.Local).AddTicks(9659), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 51, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 51, "Pagado", new DateTime(2024, 6, 27, 21, 46, 56, 610, DateTimeKind.Local).AddTicks(6676), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 52, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 52, "Pagado", new DateTime(2024, 6, 28, 16, 40, 41, 633, DateTimeKind.Local).AddTicks(455), "PSE", null },
                    { 53, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 53, "Pendiente", new DateTime(2024, 7, 28, 9, 27, 36, 10, DateTimeKind.Local).AddTicks(9704), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 54, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 54, "Fallido", new DateTime(2024, 10, 23, 8, 48, 37, 352, DateTimeKind.Local).AddTicks(2327), "PSE", null },
                    { 55, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 55, "Fallido", new DateTime(2024, 10, 26, 13, 16, 2, 326, DateTimeKind.Local).AddTicks(2090), "PSE", null },
                    { 56, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 56, "Pagado", new DateTime(2024, 4, 29, 20, 51, 37, 198, DateTimeKind.Local).AddTicks(2647), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 57, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 57, "Pendiente", new DateTime(2024, 3, 24, 3, 33, 56, 189, DateTimeKind.Local).AddTicks(9622), "Tarjeta", null },
                    { 58, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 58, "Pendiente", new DateTime(2024, 10, 14, 16, 12, 6, 87, DateTimeKind.Local).AddTicks(412), "Efectivo", null },
                    { 59, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 59, "Pendiente", new DateTime(2024, 8, 21, 1, 29, 38, 135, DateTimeKind.Local).AddTicks(3114), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 60, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 60, "Pendiente", new DateTime(2025, 3, 22, 5, 19, 43, 330, DateTimeKind.Local).AddTicks(2616), "Efectivo", null },
                    { 61, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 61, "Pendiente", new DateTime(2025, 1, 4, 10, 1, 53, 101, DateTimeKind.Local).AddTicks(9123), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 62, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 62, "Fallido", new DateTime(2025, 2, 17, 20, 26, 45, 838, DateTimeKind.Local).AddTicks(991), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 63, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 63, "Fallido", new DateTime(2024, 7, 15, 21, 20, 47, 111, DateTimeKind.Local).AddTicks(2178), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 64, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 64, "Pagado", new DateTime(2025, 1, 8, 12, 21, 48, 881, DateTimeKind.Local).AddTicks(4275), "Efectivo", null },
                    { 65, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 65, "Pendiente", new DateTime(2024, 4, 29, 11, 10, 13, 975, DateTimeKind.Local).AddTicks(6222), "Efectivo", null },
                    { 66, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 66, "Pagado", new DateTime(2024, 12, 15, 11, 46, 11, 455, DateTimeKind.Local).AddTicks(1785), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 67, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 67, "Pendiente", new DateTime(2025, 2, 11, 9, 49, 2, 75, DateTimeKind.Local).AddTicks(8616), "PSE", null },
                    { 68, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 68, "Pendiente", new DateTime(2024, 9, 12, 13, 12, 57, 329, DateTimeKind.Local).AddTicks(1707), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 69, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 69, "Pendiente", new DateTime(2024, 10, 26, 7, 42, 49, 506, DateTimeKind.Local).AddTicks(9542), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 70, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 70, "Fallido", new DateTime(2024, 5, 20, 6, 53, 57, 630, DateTimeKind.Local).AddTicks(1043), "Tarjeta", null },
                    { 71, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 71, "Pendiente", new DateTime(2024, 6, 6, 0, 43, 52, 51, DateTimeKind.Local).AddTicks(2125), "PSE", null },
                    { 72, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 72, "Fallido", new DateTime(2024, 7, 5, 0, 56, 5, 624, DateTimeKind.Local).AddTicks(3534), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 73, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 73, "Fallido", new DateTime(2024, 5, 1, 6, 11, 3, 114, DateTimeKind.Local).AddTicks(1752), "Nequi", null },
                    { 74, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 74, "Pendiente", new DateTime(2024, 8, 2, 11, 59, 38, 56, DateTimeKind.Local).AddTicks(8428), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 75, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 75, "Fallido", new DateTime(2025, 2, 27, 0, 0, 22, 655, DateTimeKind.Local).AddTicks(9360), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 76, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 76, "Fallido", new DateTime(2024, 11, 5, 21, 43, 45, 923, DateTimeKind.Local).AddTicks(3182), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 77, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 77, "Fallido", new DateTime(2024, 10, 10, 10, 19, 32, 415, DateTimeKind.Local).AddTicks(6258), "PSE", null },
                    { 78, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 78, "Pagado", new DateTime(2024, 5, 13, 13, 39, 3, 226, DateTimeKind.Local).AddTicks(2539), "PSE", null },
                    { 79, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 79, "Pagado", new DateTime(2024, 3, 25, 10, 58, 6, 356, DateTimeKind.Local).AddTicks(5904), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 80, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 80, "Pagado", new DateTime(2024, 11, 4, 18, 31, 29, 599, DateTimeKind.Local).AddTicks(6585), "PSE", null },
                    { 81, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 81, "Fallido", new DateTime(2025, 1, 10, 19, 14, 53, 531, DateTimeKind.Local).AddTicks(6431), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 82, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 82, "Pagado", new DateTime(2024, 5, 10, 7, 38, 50, 599, DateTimeKind.Local).AddTicks(5185), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 83, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 83, "Pagado", new DateTime(2024, 10, 20, 14, 21, 38, 444, DateTimeKind.Local).AddTicks(2483), "Tarjeta", null },
                    { 84, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 84, "Pendiente", new DateTime(2024, 6, 1, 22, 12, 39, 709, DateTimeKind.Local).AddTicks(9023), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 85, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 85, "Fallido", new DateTime(2024, 6, 2, 19, 43, 59, 94, DateTimeKind.Local).AddTicks(4483), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 86, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 86, "Pendiente", new DateTime(2024, 12, 24, 23, 11, 26, 698, DateTimeKind.Local).AddTicks(3), "Nequi", null },
                    { 87, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 87, "Pendiente", new DateTime(2024, 9, 1, 14, 50, 24, 217, DateTimeKind.Local).AddTicks(1732), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 88, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 88, "Pagado", new DateTime(2025, 3, 6, 11, 11, 26, 205, DateTimeKind.Local).AddTicks(8133), "Tarjeta", null },
                    { 89, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 89, "Pendiente", new DateTime(2025, 2, 23, 9, 51, 2, 152, DateTimeKind.Local).AddTicks(4991), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 90, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 90, "Pendiente", new DateTime(2024, 6, 2, 19, 5, 20, 732, DateTimeKind.Local).AddTicks(164), "Nequi", null },
                    { 91, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 91, "Pagado", new DateTime(2024, 9, 6, 5, 52, 8, 745, DateTimeKind.Local).AddTicks(9412), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 92, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 92, "Pagado", new DateTime(2025, 2, 20, 4, 44, 2, 727, DateTimeKind.Local).AddTicks(3659), "Nequi", null },
                    { 93, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 93, "Pagado", new DateTime(2025, 3, 13, 22, 24, 1, 668, DateTimeKind.Local).AddTicks(7289), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 94, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 94, "Pendiente", new DateTime(2024, 7, 18, 8, 16, 51, 610, DateTimeKind.Local).AddTicks(3541), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 95, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 95, "Pendiente", new DateTime(2025, 2, 7, 10, 3, 1, 612, DateTimeKind.Local).AddTicks(196), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 96, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 96, "Fallido", new DateTime(2024, 6, 19, 22, 19, 16, 339, DateTimeKind.Local).AddTicks(5577), "Efectivo", null },
                    { 97, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 97, "Pagado", new DateTime(2024, 8, 24, 23, 35, 56, 548, DateTimeKind.Local).AddTicks(7134), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 98, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 98, "Fallido", new DateTime(2024, 9, 29, 9, 45, 34, 283, DateTimeKind.Local).AddTicks(6717), "Nequi", null },
                    { 99, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 99, "Pagado", new DateTime(2025, 1, 25, 2, 36, 1, 49, DateTimeKind.Local).AddTicks(4638), "PSE", null },
                    { 100, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 100, "Fallido", new DateTime(2024, 6, 24, 7, 58, 28, 142, DateTimeKind.Local).AddTicks(5450), "Efectivo", null },
                    { 101, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 101, "Pagado", new DateTime(2025, 1, 15, 9, 31, 46, 537, DateTimeKind.Local).AddTicks(86), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 102, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 102, "Pagado", new DateTime(2024, 6, 7, 14, 53, 34, 485, DateTimeKind.Local).AddTicks(1944), "Nequi", null },
                    { 103, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 103, "Pagado", new DateTime(2024, 10, 28, 21, 53, 56, 892, DateTimeKind.Local).AddTicks(8273), "Nequi", null },
                    { 104, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 104, "Fallido", new DateTime(2024, 11, 30, 4, 21, 42, 721, DateTimeKind.Local).AddTicks(2237), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 105, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 105, "Pagado", new DateTime(2024, 7, 7, 15, 1, 19, 880, DateTimeKind.Local).AddTicks(1051), "PSE", null },
                    { 106, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 106, "Pendiente", new DateTime(2024, 4, 19, 13, 48, 29, 886, DateTimeKind.Local).AddTicks(4612), "Tarjeta", null },
                    { 107, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 107, "Fallido", new DateTime(2024, 4, 8, 15, 16, 51, 135, DateTimeKind.Local).AddTicks(8591), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 108, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 108, "Fallido", new DateTime(2024, 5, 13, 3, 38, 25, 311, DateTimeKind.Local).AddTicks(6333), "Nequi", null },
                    { 109, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 109, "Pagado", new DateTime(2024, 9, 2, 8, 37, 27, 42, DateTimeKind.Local).AddTicks(4116), "PSE", null },
                    { 110, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 110, "Fallido", new DateTime(2024, 10, 2, 13, 27, 51, 995, DateTimeKind.Local).AddTicks(460), "Tarjeta", null },
                    { 111, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 111, "Pendiente", new DateTime(2024, 3, 27, 16, 6, 44, 874, DateTimeKind.Local).AddTicks(3264), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 112, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 112, "Pagado", new DateTime(2024, 7, 11, 1, 3, 28, 442, DateTimeKind.Local).AddTicks(7737), "Nequi", null },
                    { 113, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 113, "Fallido", new DateTime(2024, 8, 18, 3, 48, 49, 522, DateTimeKind.Local).AddTicks(2542), "Tarjeta", null },
                    { 114, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 114, "Pagado", new DateTime(2024, 4, 28, 1, 56, 49, 881, DateTimeKind.Local).AddTicks(4232), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 115, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 115, "Fallido", new DateTime(2025, 1, 9, 0, 38, 21, 483, DateTimeKind.Local).AddTicks(1252), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 116, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 116, "Pagado", new DateTime(2024, 9, 30, 22, 58, 18, 375, DateTimeKind.Local).AddTicks(6155), "Tarjeta", null },
                    { 117, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 117, "Pagado", new DateTime(2024, 4, 23, 19, 47, 0, 493, DateTimeKind.Local).AddTicks(654), "Tarjeta", null },
                    { 118, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 118, "Pagado", new DateTime(2025, 3, 1, 2, 25, 46, 421, DateTimeKind.Local).AddTicks(1140), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 119, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 119, "Pendiente", new DateTime(2024, 5, 15, 15, 47, 54, 859, DateTimeKind.Local).AddTicks(4473), "Nequi", null },
                    { 120, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 120, "Pendiente", new DateTime(2024, 10, 16, 14, 52, 33, 814, DateTimeKind.Local).AddTicks(7182), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 121, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 121, "Pendiente", new DateTime(2024, 8, 1, 10, 8, 18, 812, DateTimeKind.Local).AddTicks(6434), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 122, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 122, "Pagado", new DateTime(2025, 2, 10, 7, 24, 49, 145, DateTimeKind.Local).AddTicks(5241), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 123, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 123, "Fallido", new DateTime(2024, 7, 16, 12, 45, 9, 681, DateTimeKind.Local).AddTicks(8912), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 124, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 124, "Pagado", new DateTime(2024, 4, 28, 18, 6, 8, 468, DateTimeKind.Local).AddTicks(9443), "Efectivo", null },
                    { 125, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 125, "Pendiente", new DateTime(2024, 8, 19, 7, 20, 42, 764, DateTimeKind.Local).AddTicks(4668), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 126, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 126, "Pagado", new DateTime(2025, 2, 9, 0, 33, 45, 272, DateTimeKind.Local).AddTicks(2615), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 127, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 127, "Pagado", new DateTime(2024, 7, 30, 9, 28, 7, 164, DateTimeKind.Local).AddTicks(7729), "Nequi", null },
                    { 128, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 128, "Pendiente", new DateTime(2024, 5, 23, 6, 58, 33, 469, DateTimeKind.Local).AddTicks(406), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 129, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 129, "Fallido", new DateTime(2024, 4, 16, 3, 41, 27, 611, DateTimeKind.Local).AddTicks(986), "Nequi", null },
                    { 130, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 130, "Pendiente", new DateTime(2024, 4, 25, 20, 55, 51, 561, DateTimeKind.Local).AddTicks(2399), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 131, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 131, "Pagado", new DateTime(2024, 4, 22, 22, 5, 25, 163, DateTimeKind.Local).AddTicks(4757), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 132, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 132, "Fallido", new DateTime(2024, 11, 18, 23, 42, 33, 364, DateTimeKind.Local).AddTicks(7221), "PSE", null },
                    { 133, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 133, "Pendiente", new DateTime(2024, 7, 1, 1, 23, 24, 819, DateTimeKind.Local).AddTicks(6060), "Nequi", null },
                    { 134, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 134, "Pagado", new DateTime(2024, 9, 25, 2, 30, 17, 788, DateTimeKind.Local).AddTicks(3242), "Tarjeta", null },
                    { 135, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 135, "Pagado", new DateTime(2025, 2, 1, 17, 8, 44, 742, DateTimeKind.Local).AddTicks(1391), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 136, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 136, "Fallido", new DateTime(2024, 9, 27, 1, 35, 21, 535, DateTimeKind.Local).AddTicks(5563), "Efectivo", null },
                    { 137, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 137, "Pendiente", new DateTime(2025, 1, 1, 5, 24, 59, 147, DateTimeKind.Local).AddTicks(7132), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 138, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 138, "Pagado", new DateTime(2024, 11, 16, 14, 40, 35, 908, DateTimeKind.Local).AddTicks(9800), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 139, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 139, "Fallido", new DateTime(2025, 2, 11, 21, 55, 20, 462, DateTimeKind.Local).AddTicks(5840), "Tarjeta", null },
                    { 140, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 140, "Fallido", new DateTime(2024, 6, 1, 13, 51, 50, 554, DateTimeKind.Local).AddTicks(3406), "PSE", null },
                    { 141, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 141, "Pendiente", new DateTime(2024, 4, 8, 13, 34, 49, 972, DateTimeKind.Local).AddTicks(2329), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 142, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 142, "Pendiente", new DateTime(2025, 1, 13, 22, 46, 8, 485, DateTimeKind.Local).AddTicks(954), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 143, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 143, "Pagado", new DateTime(2024, 7, 11, 22, 7, 46, 24, DateTimeKind.Local).AddTicks(6376), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 144, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 144, "Fallido", new DateTime(2024, 7, 6, 13, 8, 19, 81, DateTimeKind.Local).AddTicks(4949), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 145, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 145, "Pagado", new DateTime(2024, 5, 3, 14, 7, 41, 690, DateTimeKind.Local).AddTicks(6989), "Nequi", null },
                    { 146, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 146, "Pendiente", new DateTime(2024, 3, 26, 3, 36, 22, 211, DateTimeKind.Local).AddTicks(1812), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 147, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 147, "Pendiente", new DateTime(2024, 5, 14, 23, 36, 40, 726, DateTimeKind.Local).AddTicks(7139), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 148, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 148, "Pendiente", new DateTime(2024, 6, 20, 10, 46, 58, 977, DateTimeKind.Local).AddTicks(3085), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 149, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 149, "Pagado", new DateTime(2024, 5, 23, 9, 37, 43, 243, DateTimeKind.Local).AddTicks(9790), "Tarjeta", null },
                    { 150, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 150, "Fallido", new DateTime(2024, 5, 25, 2, 56, 6, 882, DateTimeKind.Local).AddTicks(2819), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 151, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 151, "Pagado", new DateTime(2024, 8, 28, 11, 49, 39, 635, DateTimeKind.Local).AddTicks(8519), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 152, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 152, "Fallido", new DateTime(2025, 1, 31, 9, 34, 42, 290, DateTimeKind.Local).AddTicks(1506), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 153, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 153, "Pendiente", new DateTime(2024, 7, 27, 17, 59, 25, 919, DateTimeKind.Local).AddTicks(1486), "Efectivo", null },
                    { 154, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 154, "Pagado", new DateTime(2024, 7, 15, 15, 27, 17, 279, DateTimeKind.Local).AddTicks(9773), "Efectivo", null },
                    { 155, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 155, "Fallido", new DateTime(2024, 10, 22, 21, 29, 12, 118, DateTimeKind.Local).AddTicks(4506), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 156, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 156, "Pagado", new DateTime(2024, 11, 9, 4, 16, 25, 914, DateTimeKind.Local).AddTicks(7412), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 157, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 157, "Pendiente", new DateTime(2024, 9, 24, 6, 13, 20, 672, DateTimeKind.Local).AddTicks(6136), "PSE", null },
                    { 158, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 158, "Pagado", new DateTime(2024, 4, 1, 14, 50, 23, 357, DateTimeKind.Local).AddTicks(1031), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 159, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 159, "Fallido", new DateTime(2024, 6, 9, 12, 19, 54, 834, DateTimeKind.Local).AddTicks(8092), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 160, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 160, "Pendiente", new DateTime(2024, 4, 11, 15, 33, 7, 704, DateTimeKind.Local).AddTicks(1656), "Nequi", null },
                    { 161, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 161, "Fallido", new DateTime(2024, 7, 25, 20, 42, 42, 175, DateTimeKind.Local).AddTicks(7172), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 162, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 162, "Pendiente", new DateTime(2024, 10, 11, 0, 12, 31, 821, DateTimeKind.Local).AddTicks(9695), "Tarjeta", null },
                    { 163, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 163, "Pagado", new DateTime(2024, 12, 14, 22, 59, 27, 412, DateTimeKind.Local).AddTicks(1780), "Nequi", null },
                    { 164, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 164, "Pagado", new DateTime(2024, 10, 24, 15, 18, 6, 716, DateTimeKind.Local).AddTicks(3909), "Tarjeta", null },
                    { 165, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 165, "Pagado", new DateTime(2024, 8, 16, 4, 16, 13, 983, DateTimeKind.Local).AddTicks(3602), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 166, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 166, "Pagado", new DateTime(2024, 6, 5, 5, 56, 26, 910, DateTimeKind.Local).AddTicks(1839), "Efectivo", null },
                    { 167, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 167, "Pagado", new DateTime(2024, 9, 1, 14, 11, 51, 3, DateTimeKind.Local).AddTicks(5720), "Nequi", null },
                    { 168, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 168, "Pendiente", new DateTime(2024, 10, 19, 6, 0, 36, 345, DateTimeKind.Local).AddTicks(8149), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 169, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 169, "Pendiente", new DateTime(2025, 2, 11, 11, 36, 51, 396, DateTimeKind.Local).AddTicks(7853), "Nequi", null },
                    { 170, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 170, "Fallido", new DateTime(2025, 2, 7, 7, 39, 54, 436, DateTimeKind.Local).AddTicks(9267), "Tarjeta", null },
                    { 171, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 171, "Pagado", new DateTime(2024, 5, 11, 4, 32, 39, 541, DateTimeKind.Local).AddTicks(6469), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 172, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 172, "Fallido", new DateTime(2024, 12, 14, 14, 12, 5, 203, DateTimeKind.Local).AddTicks(4917), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 173, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 173, "Pendiente", new DateTime(2025, 1, 4, 21, 0, 30, 923, DateTimeKind.Local).AddTicks(5951), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 174, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 174, "Pagado", new DateTime(2024, 11, 9, 18, 37, 55, 236, DateTimeKind.Local).AddTicks(2146), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 175, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 175, "Fallido", new DateTime(2024, 4, 5, 10, 25, 58, 648, DateTimeKind.Local).AddTicks(8591), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 176, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 176, "Fallido", new DateTime(2024, 3, 30, 19, 53, 16, 936, DateTimeKind.Local).AddTicks(5376), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 177, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 177, "Pendiente", new DateTime(2024, 10, 5, 11, 20, 37, 622, DateTimeKind.Local).AddTicks(7830), "Nequi", null },
                    { 178, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 178, "Pendiente", new DateTime(2024, 4, 13, 7, 51, 45, 896, DateTimeKind.Local).AddTicks(6152), "Efectivo", null },
                    { 179, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 179, "Fallido", new DateTime(2024, 9, 19, 10, 26, 7, 479, DateTimeKind.Local).AddTicks(9473), "Efectivo", null },
                    { 180, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 180, "Fallido", new DateTime(2024, 7, 23, 2, 41, 36, 545, DateTimeKind.Local).AddTicks(6309), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 181, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 181, "Pagado", new DateTime(2024, 5, 31, 18, 2, 23, 336, DateTimeKind.Local).AddTicks(7795), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 182, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 182, "Pagado", new DateTime(2024, 8, 30, 14, 47, 16, 570, DateTimeKind.Local).AddTicks(8501), "Efectivo", null },
                    { 183, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 183, "Pagado", new DateTime(2025, 1, 15, 13, 49, 27, 737, DateTimeKind.Local).AddTicks(1310), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 184, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 184, "Pendiente", new DateTime(2025, 2, 3, 14, 43, 50, 770, DateTimeKind.Local).AddTicks(4326), "PSE", null },
                    { 185, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 185, "Pendiente", new DateTime(2024, 6, 2, 13, 12, 36, 681, DateTimeKind.Local).AddTicks(1587), "Nequi", null },
                    { 186, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 186, "Pagado", new DateTime(2025, 1, 23, 3, 28, 24, 754, DateTimeKind.Local).AddTicks(7140), "Efectivo", null },
                    { 187, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 187, "Pendiente", new DateTime(2025, 2, 2, 19, 27, 45, 323, DateTimeKind.Local).AddTicks(9824), "Efectivo", null },
                    { 188, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 188, "Pendiente", new DateTime(2024, 4, 28, 15, 14, 35, 486, DateTimeKind.Local).AddTicks(6937), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 189, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 189, "Pendiente", new DateTime(2024, 5, 1, 7, 11, 32, 362, DateTimeKind.Local).AddTicks(1174), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 190, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 190, "Fallido", new DateTime(2024, 11, 6, 10, 2, 2, 992, DateTimeKind.Local).AddTicks(8744), "Tarjeta", null },
                    { 191, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 191, "Fallido", new DateTime(2024, 12, 1, 23, 11, 19, 976, DateTimeKind.Local).AddTicks(7043), "Nequi", null },
                    { 192, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 192, "Pendiente", new DateTime(2024, 9, 13, 7, 31, 27, 545, DateTimeKind.Local).AddTicks(5901), "Nequi", null },
                    { 193, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 193, "Fallido", new DateTime(2025, 3, 1, 22, 18, 55, 702, DateTimeKind.Local).AddTicks(4353), "Efectivo", null },
                    { 194, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 194, "Fallido", new DateTime(2024, 6, 28, 21, 40, 13, 858, DateTimeKind.Local).AddTicks(2395), "Efectivo", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 195, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 195, "Fallido", new DateTime(2024, 12, 1, 10, 9, 54, 695, DateTimeKind.Local).AddTicks(726), "PSE", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 196, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 196, "Pagado", new DateTime(2024, 5, 13, 13, 57, 38, 607, DateTimeKind.Local).AddTicks(6762), "PSE", null },
                    { 197, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 197, "Fallido", new DateTime(2024, 6, 7, 19, 39, 22, 732, DateTimeKind.Local).AddTicks(588), "Tarjeta", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 198, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 198, "Pagado", new DateTime(2024, 11, 30, 18, 1, 23, 880, DateTimeKind.Local).AddTicks(5375), "Tarjeta", null },
                    { 199, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 199, "Fallido", new DateTime(2024, 3, 29, 5, 33, 0, 428, DateTimeKind.Local).AddTicks(1535), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) },
                    { 200, new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238), "Api User", 200, "Pagado", new DateTime(2025, 1, 1, 18, 29, 36, 702, DateTimeKind.Local).AddTicks(8327), "Nequi", new DateTime(2025, 3, 22, 22, 16, 54, 679, DateTimeKind.Utc).AddTicks(4238) }
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
