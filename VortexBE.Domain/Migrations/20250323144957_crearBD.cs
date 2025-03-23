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
                    Activo = table.Column<bool>(type: "bit", nullable: false),
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
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
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
                    { 1, "Ibagué", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Centro Comercial Multicentro", "CineColombia", null },
                    { 2, "Medellín", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Av. Siempre Viva 742", "Cinemark", null },
                    { 3, "Cali", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Mall Plaza", "Royal Films", null },
                    { 4, "Barranquilla", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Centro Comercial Unicentro", "Royal Films", null },
                    { 5, "Cartagena", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Plaza Central", "Cinemark", null },
                    { 6, "Bogotá D.C.", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Centro Comercial Andino", "Multiplex Andino", null },
                    { 7, "Bucaramanga", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Cra. 50 #20-30", "CineColombia", null },
                    { 8, "Pereira", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Carrera 15 #45-67", "Cinemark", null },
                    { 9, "Manizales", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Av. 68 #22-15", "CineColombia", null },
                    { 10, "Cúcuta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Centro Comercial Ventura", "Cinemark", null }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "PeliculaId", "Activo", "Clasificacion", "CreatedAt", "CreatedBy", "Descripcion", "Director", "Duracion", "FechaEstreno", "Genero", "PosterUrl", "Titulo", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, "NC-17", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Omnis aliquam doloremque libero quo. Nihil quis dicta ab consequatur corporis. Saepe laudantium voluptas hic beatae deleniti expedita fugit.", "Christopher Nolan", 169, new DateTime(2020, 11, 16, 23, 13, 27, 377, DateTimeKind.Utc).AddTicks(9292), "Comedia", "image-1", "Flow", null },
                    { 2, true, "NC-17", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Suscipit voluptatibus inventore expedita molestiae qui. Fuga quo animi ut nostrum. Nisi et exercitationem quo id qui ipsum consequatur.", "Steven Spielberg", 107, new DateTime(2025, 4, 30, 4, 0, 30, 256, DateTimeKind.Utc).AddTicks(3906), "Drama", "image-2", "Superman", null },
                    { 3, true, "G", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Deserunt laudantium distinctio et ullam repellat. Porro labore ea ipsa repudiandae soluta laborum et. Temporibus rerum eos. Eum vero velit aut non voluptatem voluptatem dicta similique quisquam.", "Steven Spielberg", 140, new DateTime(2022, 9, 11, 23, 29, 53, 958, DateTimeKind.Utc).AddTicks(4429), "Ciencia Ficción", "image-3", "Star Wars III", null },
                    { 4, true, "PG", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Quia aut doloribus quos veniam minus. Tempore eos neque. Nihil assumenda rerum.", "Ridley Scott", 119, new DateTime(2024, 7, 30, 18, 32, 23, 33, DateTimeKind.Utc).AddTicks(5438), "Drama", "image-4", "Up", null },
                    { 5, true, "PG-13", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Repellat sunt velit facere dignissimos dolore voluptatum. Quia sunt eum autem aspernatur voluptatem. At eveniet ut sunt consequatur.", "Quentin Tarantino", 171, new DateTime(2021, 8, 6, 8, 2, 15, 336, DateTimeKind.Utc).AddTicks(682), "Animación", "image-5", "Sin Limites", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Activo", "Apellido", "CreatedAt", "CreatedBy", "Email", "Nombre", "PasswordHash", "Telefono", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, true, "Ratke", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Jorge_Schimmel@gmail.com", "Celia", "D93591BDF7860E1E33F2024487C3D0D5", "1-279-368-2983 x09015", null, "Celia23" },
                    { 2, true, "Pacocha", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Dillan76@gmail.com", "Yoshiko", "D93591BDF7860E1E33F2024487C3D0D5", "262-917-8278 x949", null, "Yoshiko.Pacocha79" },
                    { 3, true, "Hartmann", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Helena.Thiel57@gmail.com", "Clarabelle", "D93591BDF7860E1E33F2024487C3D0D5", "369.600.3532 x4239", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Clarabelle_Hartmann33" },
                    { 4, false, "Bradtke", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Kristy_Mohr70@hotmail.com", "Kristofer", "D93591BDF7860E1E33F2024487C3D0D5", "(677) 204-7486 x088", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Kristofer_Bradtke" },
                    { 5, true, "Konopelski", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Karolann_Haley@yahoo.com", "Max", "D93591BDF7860E1E33F2024487C3D0D5", "688.815.6944 x7731", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Max_Konopelski69" },
                    { 6, true, "Grady", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Tad_Haag@gmail.com", "Kaleigh", "D93591BDF7860E1E33F2024487C3D0D5", "1-399-653-3283 x25368", null, "Kaleigh_Grady28" },
                    { 7, true, "Hudson", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Jeff.Cormier@hotmail.com", "Dale", "D93591BDF7860E1E33F2024487C3D0D5", "1-601-348-8144 x953", null, "Dale71" },
                    { 8, false, "Hackett", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Merritt56@yahoo.com", "King", "D93591BDF7860E1E33F2024487C3D0D5", "369.286.7325", null, "King_Hackett" },
                    { 9, true, "Beahan", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Alexzander70@yahoo.com", "Tianna", "D93591BDF7860E1E33F2024487C3D0D5", "(485) 740-0926 x301", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Tianna19" },
                    { 10, true, "Schultz", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Susanna84@gmail.com", "Chaz", "D93591BDF7860E1E33F2024487C3D0D5", "883.992.5378 x2062", null, "Chaz_Schultz7" },
                    { 11, false, "Schuppe", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Edythe83@gmail.com", "Doug", "D93591BDF7860E1E33F2024487C3D0D5", "1-701-886-9547", null, "Doug.Schuppe" },
                    { 12, false, "Schaden", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Gilberto.Beier33@hotmail.com", "Amaya", "D93591BDF7860E1E33F2024487C3D0D5", "(727) 725-6108 x407", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Amaya.Schaden20" },
                    { 13, false, "Beahan", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Edgardo_Abernathy35@yahoo.com", "Micaela", "D93591BDF7860E1E33F2024487C3D0D5", "1-647-290-4155 x6361", null, "Micaela63" },
                    { 14, true, "Hoeger", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Mireya40@gmail.com", "Jazlyn", "D93591BDF7860E1E33F2024487C3D0D5", "1-357-459-4231 x420", null, "Jazlyn_Hoeger25" },
                    { 15, true, "Bins", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Immanuel67@gmail.com", "Mauricio", "D93591BDF7860E1E33F2024487C3D0D5", "328-906-3173 x507", null, "Mauricio7" },
                    { 16, true, "Bartoletti", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Jessica.Beier72@gmail.com", "Neil", "D93591BDF7860E1E33F2024487C3D0D5", "(457) 579-7938 x3520", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Neil.Bartoletti" },
                    { 17, true, "Zieme", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Wilfred.Barton@hotmail.com", "Jacinto", "D93591BDF7860E1E33F2024487C3D0D5", "458.908.7251 x40030", null, "Jacinto67" },
                    { 18, false, "Barrows", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Colby.Jaskolski@gmail.com", "Glen", "D93591BDF7860E1E33F2024487C3D0D5", "(779) 349-4077 x5379", null, "Glen_Barrows" },
                    { 19, true, "Renner", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Maci_Fadel5@yahoo.com", "Mafalda", "D93591BDF7860E1E33F2024487C3D0D5", "744.963.9620", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Mafalda.Renner" },
                    { 20, false, "Armstrong", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Kenneth_Bernhard@hotmail.com", "Nat", "D93591BDF7860E1E33F2024487C3D0D5", "(541) 526-7133", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Nat_Armstrong48" },
                    { 21, true, "Champlin", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Vena_Kerluke@yahoo.com", "Llewellyn", "D93591BDF7860E1E33F2024487C3D0D5", "973-563-4253", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Llewellyn.Champlin85" },
                    { 22, true, "Schimmel", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Lisa33@hotmail.com", "Kaley", "D93591BDF7860E1E33F2024487C3D0D5", "525-644-1265 x407", null, "Kaley79" },
                    { 23, true, "Wolff", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Alayna.Anderson29@gmail.com", "Kendra", "D93591BDF7860E1E33F2024487C3D0D5", "396-839-2297", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Kendra_Wolff62" },
                    { 24, true, "Connelly", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Eve_Hansen8@yahoo.com", "Ubaldo", "D93591BDF7860E1E33F2024487C3D0D5", "(460) 252-3476", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Ubaldo.Connelly" },
                    { 25, true, "Purdy", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "Lawrence28@gmail.com", "Yadira", "D93591BDF7860E1E33F2024487C3D0D5", "1-519-995-7050", null, "Yadira_Purdy" },
                    { 26, true, "Leon Barrera", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", "leonjuandavid@hotmail.com", "Juan David", "81DC9BDB52D04DC223B621240E3DD8B7", "304 340 5607", null, "vortex" }
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "SalaId", "Capacidad", "CineId", "CreatedAt", "CreatedBy", "Numero", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 80, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 2, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 3, 80, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 4, 150, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 5, 100, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 6, 150, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 7, 100, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 8, 250, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 9, 80, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 10, 80, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 11, 150, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 12, 150, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 13, 80, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 14, 200, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 15, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 16, 150, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 17, 150, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 18, 150, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 19, 100, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 20, 250, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 21, 150, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 22, 200, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 23, 150, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 24, 150, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 25, 200, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 26, 80, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 27, 100, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 28, 100, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 29, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 30, 200, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 31, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 32, 250, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 33, 200, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 34, 100, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 35, 250, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 36, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 37, 80, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 38, 250, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 39, 150, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 40, 150, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 41, 150, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 42, 80, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 43, 100, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 44, 250, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 45, 150, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 46, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 47, 200, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 48, 80, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 49, 80, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 50, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 51, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 52, 100, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 53, 150, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 54, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 55, 100, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 56, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 57, 150, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 58, 100, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 59, 80, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 60, 250, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 61, 250, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 62, 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 63, 80, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 64, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 65, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 66, 150, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 67, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 68, 250, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 69, 150, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 70, 80, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 71, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 72, 150, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 73, 250, 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 74, 150, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 75, 100, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 76, 100, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 77, 250, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 78, 250, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 79, 80, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 80, 150, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 81, 150, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 82, 250, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 83, 250, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 84, 200, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 85, 250, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 86, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 87, 150, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 88, 100, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 89, 250, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 90, 150, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 91, 100, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 92, 80, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 93, 100, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null },
                    { 94, 80, 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 95, 80, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 96, 200, 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 97, 200, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 98, 80, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, null },
                    { 99, 100, 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, null },
                    { 100, 80, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Funcion",
                columns: new[] { "FuncionId", "CreatedAt", "CreatedBy", "FechaHora", "PeliculaId", "Precio", "SalaId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 6, 0, 23, 27, 767, DateTimeKind.Utc).AddTicks(6504), 3, 27898m, 90, null },
                    { 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 20, 14, 33, 9, 141, DateTimeKind.Utc).AddTicks(3145), 2, 23160m, 18, null },
                    { 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 7, 15, 55, 40, 766, DateTimeKind.Utc).AddTicks(6498), 2, 10319m, 83, null },
                    { 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 12, 9, 46, 36, 628, DateTimeKind.Utc).AddTicks(6866), 1, 47009m, 47, null },
                    { 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 27, 1, 23, 42, 814, DateTimeKind.Utc).AddTicks(6544), 2, 49297m, 88, null },
                    { 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 19, 23, 16, 49, 596, DateTimeKind.Utc).AddTicks(1500), 3, 15787m, 51, null },
                    { 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 23, 8, 4, 2, 196, DateTimeKind.Utc).AddTicks(1268), 2, 43759m, 34, null },
                    { 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 12, 20, 26, 482, DateTimeKind.Utc).AddTicks(71), 3, 44408m, 34, null },
                    { 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 2, 15, 5, 40, 817, DateTimeKind.Utc).AddTicks(3056), 1, 11236m, 75, null },
                    { 10, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 18, 16, 20, 13, 506, DateTimeKind.Utc).AddTicks(2061), 2, 34480m, 15, null },
                    { 11, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 6, 23, 4, 20, 349, DateTimeKind.Utc).AddTicks(3785), 3, 19168m, 22, null },
                    { 12, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 9, 9, 10, 29, 82, DateTimeKind.Utc).AddTicks(3915), 3, 20680m, 62, null },
                    { 13, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 20, 33, 22, 807, DateTimeKind.Utc).AddTicks(4296), 3, 27919m, 34, null },
                    { 14, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 1, 20, 56, 6, 790, DateTimeKind.Utc).AddTicks(3656), 1, 11865m, 48, null },
                    { 15, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 17, 7, 5, 15, 334, DateTimeKind.Utc).AddTicks(3389), 1, 45452m, 84, null },
                    { 16, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 10, 3, 38, 23, 897, DateTimeKind.Utc).AddTicks(3983), 3, 40562m, 53, null },
                    { 17, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 21, 25, 40, 962, DateTimeKind.Utc).AddTicks(3362), 2, 10356m, 2, null },
                    { 18, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 12, 22, 36, 28, 6, DateTimeKind.Utc).AddTicks(8967), 2, 30569m, 32, null },
                    { 19, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 4, 42, 56, 290, DateTimeKind.Utc).AddTicks(787), 3, 29481m, 50, null },
                    { 20, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 26, 12, 55, 4, 552, DateTimeKind.Utc).AddTicks(4447), 2, 37361m, 64, null },
                    { 21, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 10, 23, 16, 19, 169, DateTimeKind.Utc).AddTicks(5852), 2, 27636m, 16, null },
                    { 22, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 25, 10, 43, 36, 553, DateTimeKind.Utc).AddTicks(9972), 2, 35344m, 87, null },
                    { 23, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 2, 19, 3, 15, 214, DateTimeKind.Utc).AddTicks(8732), 3, 34688m, 89, null },
                    { 24, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 17, 19, 0, 245, DateTimeKind.Utc).AddTicks(9509), 3, 30382m, 85, null },
                    { 25, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 9, 20, 1, 26, 380, DateTimeKind.Utc).AddTicks(1624), 1, 48785m, 68, null },
                    { 26, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 8, 9, 58, 58, 718, DateTimeKind.Utc).AddTicks(1761), 1, 18453m, 17, null },
                    { 27, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 7, 20, 16, 6, 983, DateTimeKind.Utc).AddTicks(7411), 3, 20041m, 84, null },
                    { 28, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 2, 20, 52, 41, 228, DateTimeKind.Utc).AddTicks(1198), 3, 46497m, 32, null },
                    { 29, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 5, 7, 13, 17, 618, DateTimeKind.Utc).AddTicks(8592), 2, 24852m, 73, null },
                    { 30, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 5, 1, 15, 7, 576, DateTimeKind.Utc).AddTicks(1222), 2, 46357m, 49, null },
                    { 31, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 28, 13, 22, 50, 371, DateTimeKind.Utc).AddTicks(9835), 2, 19106m, 8, null },
                    { 32, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 1, 11, 27, 54, 808, DateTimeKind.Utc).AddTicks(2275), 3, 21793m, 66, null },
                    { 33, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 31, 9, 21, 14, 568, DateTimeKind.Utc).AddTicks(8360), 3, 10317m, 52, null },
                    { 34, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 21, 14, 52, 45, 801, DateTimeKind.Utc).AddTicks(7727), 3, 37674m, 36, null },
                    { 35, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 1, 29, 43, 813, DateTimeKind.Utc).AddTicks(5076), 3, 44798m, 62, null },
                    { 36, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 19, 0, 29, 32, 716, DateTimeKind.Utc).AddTicks(4999), 3, 33341m, 67, null },
                    { 37, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 12, 13, 25, 43, 729, DateTimeKind.Utc).AddTicks(3731), 3, 24993m, 34, null },
                    { 38, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 18, 10, 14, 21, 216, DateTimeKind.Utc).AddTicks(2371), 1, 23943m, 1, null },
                    { 39, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 31, 21, 36, 18, 690, DateTimeKind.Utc).AddTicks(8606), 1, 26783m, 62, null },
                    { 40, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 12, 14, 55, 6, 463, DateTimeKind.Utc).AddTicks(4803), 3, 14530m, 78, null },
                    { 41, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 6, 21, 41, 4, 360, DateTimeKind.Utc).AddTicks(4149), 1, 32255m, 61, null },
                    { 42, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 16, 4, 45, 37, 785, DateTimeKind.Utc).AddTicks(6300), 2, 23765m, 6, null },
                    { 43, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 25, 1, 0, 13, 31, DateTimeKind.Utc).AddTicks(9976), 3, 17469m, 92, null },
                    { 44, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 31, 8, 27, 2, 143, DateTimeKind.Utc).AddTicks(4678), 1, 19026m, 65, null },
                    { 45, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 15, 19, 47, 14, 475, DateTimeKind.Utc).AddTicks(1680), 1, 33589m, 97, null },
                    { 46, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 14, 22, 16, 517, DateTimeKind.Utc).AddTicks(553), 1, 44176m, 14, null },
                    { 47, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 15, 3, 27, 17, 669, DateTimeKind.Utc).AddTicks(4642), 3, 32541m, 39, null },
                    { 48, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 15, 48, 54, 856, DateTimeKind.Utc).AddTicks(5420), 1, 23381m, 89, null },
                    { 49, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 20, 5, 5, 21, 330, DateTimeKind.Utc).AddTicks(4666), 1, 43472m, 27, null },
                    { 50, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 12, 15, 5, 4, 152, DateTimeKind.Utc).AddTicks(1179), 1, 12469m, 98, null },
                    { 51, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 0, 41, 8, 144, DateTimeKind.Utc).AddTicks(7355), 1, 24226m, 39, null },
                    { 52, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 28, 9, 23, 24, 892, DateTimeKind.Utc).AddTicks(7580), 3, 30457m, 64, null },
                    { 53, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 18, 19, 42, 11, 738, DateTimeKind.Utc).AddTicks(1241), 3, 13795m, 99, null },
                    { 54, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 7, 39, 16, 583, DateTimeKind.Utc).AddTicks(9046), 3, 37069m, 41, null },
                    { 55, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 2, 57, 2, 237, DateTimeKind.Utc).AddTicks(2870), 3, 48563m, 60, null },
                    { 56, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 23, 6, 16, 0, 289, DateTimeKind.Utc).AddTicks(6953), 3, 15157m, 19, null },
                    { 57, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 12, 18, 50, 2, 430, DateTimeKind.Utc).AddTicks(1081), 2, 32046m, 91, null },
                    { 58, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 5, 16, 18, 34, 534, DateTimeKind.Utc).AddTicks(6169), 2, 44674m, 62, null },
                    { 59, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 7, 2, 33, 52, 420, DateTimeKind.Utc).AddTicks(1118), 3, 39144m, 72, null },
                    { 60, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 27, 15, 40, 40, 903, DateTimeKind.Utc).AddTicks(6630), 2, 13432m, 72, null },
                    { 61, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 2, 17, 57, 388, DateTimeKind.Utc).AddTicks(8752), 2, 25557m, 29, null },
                    { 62, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 30, 20, 10, 37, 694, DateTimeKind.Utc).AddTicks(1622), 2, 16530m, 1, null },
                    { 63, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 25, 12, 44, 51, 832, DateTimeKind.Utc).AddTicks(5378), 1, 34813m, 73, null },
                    { 64, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 8, 12, 16, 55, 695, DateTimeKind.Utc).AddTicks(1295), 2, 34430m, 11, null },
                    { 65, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 10, 15, 57, 362, DateTimeKind.Utc).AddTicks(9648), 1, 34589m, 56, null },
                    { 66, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 19, 50, 14, 163, DateTimeKind.Utc).AddTicks(5557), 2, 20999m, 87, null },
                    { 67, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 27, 20, 4, 31, 301, DateTimeKind.Utc).AddTicks(978), 2, 33734m, 55, null },
                    { 68, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 29, 8, 30, 56, 171, DateTimeKind.Utc).AddTicks(4322), 1, 24637m, 46, null },
                    { 69, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 17, 39, 36, 180, DateTimeKind.Utc).AddTicks(6774), 1, 35169m, 20, null },
                    { 70, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 20, 5, 19, 56, 914, DateTimeKind.Utc).AddTicks(1817), 2, 45129m, 5, null },
                    { 71, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 8, 18, 0, 15, 768, DateTimeKind.Utc).AddTicks(2207), 1, 23462m, 41, null },
                    { 72, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 21, 6, 10, 51, 391, DateTimeKind.Utc).AddTicks(305), 3, 15068m, 23, null },
                    { 73, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 10, 2, 30, 52, 450, DateTimeKind.Utc).AddTicks(5317), 1, 25551m, 46, null },
                    { 74, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 6, 8, 7, 25, 752, DateTimeKind.Utc).AddTicks(1964), 1, 21260m, 48, null },
                    { 75, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 13, 12, 25, 10, 581, DateTimeKind.Utc).AddTicks(4571), 1, 26755m, 99, null },
                    { 76, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 15, 4, 18, 0, 209, DateTimeKind.Utc).AddTicks(85), 2, 24839m, 77, null },
                    { 77, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 16, 5, 43, 855, DateTimeKind.Utc).AddTicks(2513), 3, 24620m, 31, null },
                    { 78, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 22, 20, 7, 757, DateTimeKind.Utc).AddTicks(6369), 2, 13093m, 3, null },
                    { 79, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 4, 3, 20, 55, 769, DateTimeKind.Utc).AddTicks(109), 1, 25988m, 65, null },
                    { 80, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 11, 13, 28, 16, 824, DateTimeKind.Utc).AddTicks(8822), 1, 15664m, 57, null },
                    { 81, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 7, 26, 26, 41, DateTimeKind.Utc).AddTicks(3341), 3, 45494m, 52, null },
                    { 82, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 7, 9, 55, 19, 470, DateTimeKind.Utc).AddTicks(9198), 3, 11468m, 35, null },
                    { 83, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 21, 19, 18, 41, 704, DateTimeKind.Utc).AddTicks(2468), 1, 21122m, 43, null },
                    { 84, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 28, 21, 4, 4, 951, DateTimeKind.Utc).AddTicks(5193), 1, 20686m, 82, null },
                    { 85, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 5, 9, 14, 12, 134, DateTimeKind.Utc).AddTicks(2831), 2, 25189m, 83, null },
                    { 86, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 22, 14, 36, 21, 227, DateTimeKind.Utc).AddTicks(1146), 2, 29827m, 20, null },
                    { 87, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 6, 9, 7, 42, 131, DateTimeKind.Utc).AddTicks(8598), 2, 21481m, 70, null },
                    { 88, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 7, 10, 36, 22, 359, DateTimeKind.Utc).AddTicks(7399), 3, 16349m, 49, null },
                    { 89, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 15, 11, 4, 1, 570, DateTimeKind.Utc).AddTicks(8629), 2, 16508m, 98, null },
                    { 90, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 6, 14, 21, 38, 158, DateTimeKind.Utc).AddTicks(5303), 2, 10269m, 13, null },
                    { 91, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 8, 20, 0, 44, 133, DateTimeKind.Utc).AddTicks(4323), 3, 24117m, 62, null },
                    { 92, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 16, 12, 3, 13, 658, DateTimeKind.Utc).AddTicks(7542), 1, 39054m, 64, null },
                    { 93, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 27, 18, 20, 34, 178, DateTimeKind.Utc).AddTicks(8583), 3, 49141m, 49, null },
                    { 94, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 3, 20, 45, 52, 359, DateTimeKind.Utc).AddTicks(1614), 3, 32141m, 98, null },
                    { 95, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 24, 4, 41, 13, 265, DateTimeKind.Utc).AddTicks(6320), 1, 47461m, 86, null },
                    { 96, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 16, 23, 35, 24, 561, DateTimeKind.Utc).AddTicks(4337), 2, 26457m, 16, null },
                    { 97, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 24, 3, 57, 7, 5, DateTimeKind.Utc).AddTicks(220), 1, 43415m, 92, null },
                    { 98, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 20, 14, 44, 8, 155, DateTimeKind.Utc).AddTicks(5622), 1, 34787m, 41, null },
                    { 99, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 4, 23, 9, 10, 29, 163, DateTimeKind.Utc).AddTicks(2511), 2, 30104m, 96, null },
                    { 100, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 31, 16, 32, 47, 655, DateTimeKind.Utc).AddTicks(5315), 2, 45323m, 28, null }
                });

            migrationBuilder.InsertData(
                table: "Entrada",
                columns: new[] { "EntradaId", "Cantidad", "CreatedAt", "CreatedBy", "FechaCompra", "FuncionId", "Total", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 22, 8, 52, 12, 114, DateTimeKind.Local).AddTicks(2355), 66, 55.823542676677440m, null, 4 },
                    { 2, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 21, 9, 20, 41, 148, DateTimeKind.Local).AddTicks(8725), 27, 49.319812823232840m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 21 },
                    { 3, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 7, 9, 30, 58, 773, DateTimeKind.Local).AddTicks(7635), 27, 17.89745470864160m, null, 25 },
                    { 4, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 8, 16, 51, 59, 453, DateTimeKind.Local).AddTicks(7734), 24, 69.0213743279351800m, null, 1 },
                    { 5, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 16, 8, 28, 17, 153, DateTimeKind.Local).AddTicks(3173), 75, 85.643446042433440m, null, 12 },
                    { 6, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 26, 11, 54, 29, 236, DateTimeKind.Local).AddTicks(7383), 79, 86.750383221472920m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 7 },
                    { 7, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 27, 0, 14, 51, 682, DateTimeKind.Local).AddTicks(373), 31, 242.952634029456400m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 19 },
                    { 8, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 21, 17, 0, 56, 255, DateTimeKind.Local).AddTicks(8003), 57, 143.482739960051600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 14 },
                    { 9, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 25, 12, 22, 7, 46, DateTimeKind.Local).AddTicks(8686), 68, 222.780789714611800m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 12 },
                    { 10, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 5, 12, 57, 10, 418, DateTimeKind.Local).AddTicks(2434), 98, 72.066447546477920m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 17 },
                    { 11, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 16, 8, 15, 8, 119, DateTimeKind.Local).AddTicks(2067), 27, 84.439726076356160m, null, 23 },
                    { 12, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 22, 4, 38, 34, 191, DateTimeKind.Local).AddTicks(5353), 81, 14.228014612432120m, null, 2 },
                    { 13, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 1, 3, 28, 8, 35, DateTimeKind.Local).AddTicks(7084), 90, 38.845266336273680m, null, 2 },
                    { 14, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 1, 18, 2, 46, 153, DateTimeKind.Local).AddTicks(9920), 25, 44.424262460049320m, null, 1 },
                    { 15, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 1, 13, 19, 42, 543, DateTimeKind.Local).AddTicks(4351), 21, 58.349572500552480m, null, 22 },
                    { 16, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 8, 1, 23, 42, 997, DateTimeKind.Local).AddTicks(4024), 59, 104.44318959349440m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 20 },
                    { 17, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 4, 22, 23, 28, 180, DateTimeKind.Local).AddTicks(9125), 58, 39.939576902691120m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 2 },
                    { 18, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 6, 3, 8, 46, 639, DateTimeKind.Local).AddTicks(7278), 96, 81.804070486960640m, null, 4 },
                    { 19, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 6, 16, 53, 48, 139, DateTimeKind.Local).AddTicks(3445), 98, 176.439564733073760m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 20, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 28, 6, 3, 59, 954, DateTimeKind.Local).AddTicks(3994), 70, 12.2652950474088880m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 6 },
                    { 21, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 23, 21, 29, 25, 311, DateTimeKind.Local).AddTicks(9105), 56, 126.022323904175600m, null, 12 },
                    { 22, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 25, 8, 43, 17, 470, DateTimeKind.Local).AddTicks(8388), 27, 35.652596435167920m, null, 7 },
                    { 23, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 26, 1, 0, 12, 638, DateTimeKind.Local).AddTicks(1394), 65, 127.42820756770680m, null, 23 },
                    { 24, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 26, 6, 39, 21, 132, DateTimeKind.Local).AddTicks(3636), 71, 181.496633763512200m, null, 4 },
                    { 25, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 3, 15, 46, 6, 64, DateTimeKind.Local).AddTicks(7764), 9, 140.787902607740160m, null, 19 },
                    { 26, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 31, 0, 5, 36, 741, DateTimeKind.Local).AddTicks(6922), 34, 15.062424004785960m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 7 },
                    { 27, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 23, 4, 24, 41, 751, DateTimeKind.Local).AddTicks(6727), 89, 147.788437295681160m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 21 },
                    { 28, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 12, 11, 53, 27, 950, DateTimeKind.Local).AddTicks(4952), 36, 158.022350174624320m, null, 11 },
                    { 29, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 15, 16, 43, 12, 879, DateTimeKind.Local).AddTicks(3779), 28, 88.63238539719680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 13 },
                    { 30, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 8, 5, 36, 56, 433, DateTimeKind.Local).AddTicks(1814), 82, 96.012550278665120m, null, 10 },
                    { 31, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 29, 18, 37, 56, 956, DateTimeKind.Local).AddTicks(3702), 1, 77.091062056678080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 15 },
                    { 32, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 5, 12, 23, 37, 959, DateTimeKind.Local).AddTicks(2407), 30, 116.099522452730640m, null, 2 },
                    { 33, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 1, 7, 55, 0, 883, DateTimeKind.Local).AddTicks(556), 52, 28.889699499343640m, null, 23 },
                    { 34, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 6, 13, 19, 49, 45, DateTimeKind.Local).AddTicks(4404), 45, 34.311042204509840m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 11 },
                    { 35, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 22, 7, 48, 25, 995, DateTimeKind.Local).AddTicks(4472), 3, 99.967779499266560m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 14 },
                    { 36, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 28, 23, 52, 4, 547, DateTimeKind.Local).AddTicks(9535), 74, 43.0947086136319360m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 9 },
                    { 37, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 4, 2, 56, 37, 89, DateTimeKind.Local).AddTicks(8054), 74, 155.469266462847680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 25 },
                    { 38, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 25, 17, 14, 6, 65, DateTimeKind.Local).AddTicks(3640), 24, 113.866993949648520m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 10 },
                    { 39, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 11, 15, 52, 48, 480, DateTimeKind.Local).AddTicks(8694), 94, 27.275268509336080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 20 },
                    { 40, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 4, 19, 26, 0, 824, DateTimeKind.Local).AddTicks(857), 93, 167.042549405319200m, null, 12 },
                    { 41, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 6, 6, 51, 6, 238, DateTimeKind.Local).AddTicks(3097), 98, 28.821495891001760m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 26 },
                    { 42, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 2, 4, 42, 55, 10, DateTimeKind.Local).AddTicks(2639), 38, 148.445192483909760m, null, 23 },
                    { 43, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 16, 21, 15, 8, 963, DateTimeKind.Local).AddTicks(6959), 26, 132.246822049168560m, null, 18 },
                    { 44, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 2, 15, 41, 58, 196, DateTimeKind.Local).AddTicks(461), 65, 29.276078174217800m, null, 19 },
                    { 45, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 26, 10, 23, 27, 287, DateTimeKind.Local).AddTicks(93), 2, 161.689890528381440m, null, 13 },
                    { 46, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 9, 20, 35, 10, 336, DateTimeKind.Local).AddTicks(1197), 37, 41.39637295736160m, null, 24 },
                    { 47, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 18, 15, 31, 16, 695, DateTimeKind.Local).AddTicks(1772), 41, 44.213896459207640m, null, 9 },
                    { 48, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 2, 21, 14, 9, 342, DateTimeKind.Local).AddTicks(2419), 32, 43.567537773493520m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 2 },
                    { 49, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 10, 3, 16, 56, 736, DateTimeKind.Local).AddTicks(2611), 95, 113.409353752680160m, null, 24 },
                    { 50, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 6, 10, 15, 53, 563, DateTimeKind.Local).AddTicks(6585), 41, 30.965894276194240m, null, 1 },
                    { 51, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 12, 2, 59, 18, 476, DateTimeKind.Local).AddTicks(3889), 37, 19.879198766087080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 13 },
                    { 52, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 1, 17, 13, 19, 11, DateTimeKind.Local).AddTicks(5737), 11, 164.342427312615200m, null, 26 },
                    { 53, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 21, 15, 3, 31, 242, DateTimeKind.Local).AddTicks(914), 59, 142.113781996277040m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 9 },
                    { 54, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 31, 19, 59, 40, 588, DateTimeKind.Local).AddTicks(1691), 82, 61.013374269657440m, null, 20 },
                    { 55, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 6, 14, 46, 58, 560, DateTimeKind.Local).AddTicks(2660), 15, 111.387314139118560m, null, 22 },
                    { 56, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 31, 23, 31, 44, 96, DateTimeKind.Local).AddTicks(3001), 25, 180.135204446316960m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 57, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 15, 21, 11, 29, 682, DateTimeKind.Local).AddTicks(5808), 94, 55.126376755041120m, null, 21 },
                    { 58, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 6, 21, 36, 53, 967, DateTimeKind.Local).AddTicks(3722), 28, 71.422299506843040m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 12 },
                    { 59, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 21, 14, 4, 51, 114, DateTimeKind.Local).AddTicks(242), 39, 78.055160212739400m, null, 1 },
                    { 60, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 1, 16, 44, 8, 858, DateTimeKind.Local).AddTicks(2146), 12, 93.862153101460480m, null, 25 },
                    { 61, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 2, 17, 43, 13, 98, DateTimeKind.Local).AddTicks(5517), 13, 26.728264198177160m, null, 23 },
                    { 62, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 17, 10, 50, 9, 490, DateTimeKind.Local).AddTicks(1511), 93, 44.564309954368040m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 5 },
                    { 63, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 5, 11, 13, 20, 269, DateTimeKind.Local).AddTicks(2334), 29, 14.459151438596080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 19 },
                    { 64, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 9, 17, 42, 30, 864, DateTimeKind.Local).AddTicks(257), 40, 54.5400443331544480m, null, 6 },
                    { 65, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 29, 16, 48, 6, 50, DateTimeKind.Local).AddTicks(1788), 44, 44.306513101101040m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 18 },
                    { 66, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 29, 2, 36, 49, 14, DateTimeKind.Local).AddTicks(8309), 83, 84.241385418520080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 23 },
                    { 67, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 11, 20, 40, 46, 596, DateTimeKind.Local).AddTicks(1842), 4, 69.605640339623920m, null, 23 },
                    { 68, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 12, 0, 36, 24, 824, DateTimeKind.Local).AddTicks(516), 22, 56.00461091301000m, null, 3 },
                    { 69, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 17, 8, 9, 46, 485, DateTimeKind.Local).AddTicks(602), 75, 88.686538300348800m, null, 7 },
                    { 70, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 1, 3, 14, 35, 525, DateTimeKind.Local).AddTicks(6139), 46, 99.768117225250920m, null, 23 },
                    { 71, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 23, 12, 47, 1, 585, DateTimeKind.Local).AddTicks(6334), 31, 145.699058618800080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 16 },
                    { 72, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 22, 11, 13, 41, 750, DateTimeKind.Local).AddTicks(3153), 88, 204.47006472575000m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 21 },
                    { 73, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 29, 0, 0, 4, 874, DateTimeKind.Local).AddTicks(5875), 18, 98.816134399599360m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 26 },
                    { 74, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 2, 0, 42, 33, 979, DateTimeKind.Local).AddTicks(8969), 36, 65.395852043689800m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 9 },
                    { 75, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 4, 9, 3, 34, 417, DateTimeKind.Local).AddTicks(2772), 25, 67.4176816355336800m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 76, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 25, 3, 46, 4, 161, DateTimeKind.Local).AddTicks(4666), 11, 74.358249598445280m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 18 },
                    { 77, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 13, 17, 26, 10, 290, DateTimeKind.Local).AddTicks(6576), 91, 24.234772867636040m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 8 },
                    { 78, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 20, 8, 16, 5, 243, DateTimeKind.Local).AddTicks(3941), 32, 169.897975921567680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 79, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 14, 5, 37, 42, 462, DateTimeKind.Local).AddTicks(2888), 66, 46.997566910770920m, null, 20 },
                    { 80, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 12, 11, 39, 17, 433, DateTimeKind.Local).AddTicks(5180), 31, 236.023488271245800m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 24 },
                    { 81, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 21, 10, 45, 28, 394, DateTimeKind.Local).AddTicks(6577), 34, 125.242304118389040m, null, 26 },
                    { 82, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 2, 5, 14, 49, 922, DateTimeKind.Local).AddTicks(6198), 90, 58.099538600243280m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 24 },
                    { 83, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 14, 21, 9, 17, 901, DateTimeKind.Local).AddTicks(2645), 35, 98.775544957081760m, null, 26 },
                    { 84, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 2, 13, 34, 56, 80, DateTimeKind.Local).AddTicks(3724), 99, 36.061519477291120m, null, 7 },
                    { 85, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 25, 12, 4, 9, 912, DateTimeKind.Local).AddTicks(3073), 6, 123.614873461910040m, null, 25 },
                    { 86, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 21, 18, 15, 4, 491, DateTimeKind.Local).AddTicks(4017), 47, 62.045652422863800m, null, 16 },
                    { 87, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 13, 16, 45, 20, 699, DateTimeKind.Local).AddTicks(8312), 78, 99.446174939582560m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 10 },
                    { 88, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 15, 13, 53, 42, 746, DateTimeKind.Local).AddTicks(1364), 50, 34.755616016991600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 8 },
                    { 89, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 29, 10, 23, 11, 228, DateTimeKind.Local).AddTicks(1823), 28, 107.272825890959800m, null, 16 },
                    { 90, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 4, 18, 51, 9, 145, DateTimeKind.Local).AddTicks(2409), 67, 79.637595393698640m, null, 4 },
                    { 91, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 31, 21, 0, 20, 155, DateTimeKind.Local).AddTicks(6758), 8, 76.301002246882160m, null, 19 },
                    { 92, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 8, 4, 27, 15, 411, DateTimeKind.Local).AddTicks(5949), 54, 14.84573305320920m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 6 },
                    { 93, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 13, 10, 40, 33, 347, DateTimeKind.Local).AddTicks(3295), 4, 92.716967764374320m, null, 15 },
                    { 94, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 31, 16, 5, 3, 459, DateTimeKind.Local).AddTicks(393), 47, 99.102818852634880m, null, 20 },
                    { 95, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 22, 9, 26, 11, 295, DateTimeKind.Local).AddTicks(4011), 73, 142.073735445561120m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 7 },
                    { 96, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 24, 18, 21, 9, 714, DateTimeKind.Local).AddTicks(4896), 9, 113.066089520931200m, null, 24 },
                    { 97, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 25, 19, 50, 20, 831, DateTimeKind.Local).AddTicks(1868), 100, 101.769751784455440m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 25 },
                    { 98, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 28, 22, 51, 44, 13, DateTimeKind.Local).AddTicks(8979), 2, 18.944260649284320m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 1 },
                    { 99, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 24, 16, 58, 19, 547, DateTimeKind.Local).AddTicks(5120), 9, 150.547941088011520m, null, 25 },
                    { 100, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 4, 21, 13, 32, 248, DateTimeKind.Local).AddTicks(3989), 3, 37.496807733566560m, null, 14 },
                    { 101, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 16, 22, 19, 46, 29, DateTimeKind.Local).AddTicks(9314), 86, 24.841741866906040m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 21 },
                    { 102, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 23, 15, 0, 5, 922, DateTimeKind.Local).AddTicks(7455), 73, 55.6161442592143600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 8 },
                    { 103, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 23, 2, 8, 27, 343, DateTimeKind.Local).AddTicks(4919), 100, 90.548146461744960m, null, 1 },
                    { 104, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 2, 19, 25, 46, 396, DateTimeKind.Local).AddTicks(249), 30, 159.006765302462600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 9 },
                    { 105, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 29, 10, 52, 47, 197, DateTimeKind.Local).AddTicks(5409), 80, 83.975419031809120m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 6 },
                    { 106, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 20, 12, 6, 51, 422, DateTimeKind.Local).AddTicks(4662), 71, 45.488811031264080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 10 },
                    { 107, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 25, 8, 33, 0, 948, DateTimeKind.Local).AddTicks(5112), 16, 53.92036404677400m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 12 },
                    { 108, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 1, 16, 35, 23, 860, DateTimeKind.Local).AddTicks(365), 43, 41.373525585976480m, null, 17 },
                    { 109, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 16, 3, 41, 15, 312, DateTimeKind.Local).AddTicks(1531), 12, 62.728006165827600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 26 },
                    { 110, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 12, 12, 55, 23, 261, DateTimeKind.Local).AddTicks(1112), 59, 52.403033188511880m, null, 2 },
                    { 111, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 9, 4, 14, 29, 379, DateTimeKind.Local).AddTicks(5179), 5, 75.454164044400m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 26 },
                    { 112, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 9, 2, 49, 46, 859, DateTimeKind.Local).AddTicks(947), 43, 94.749394105926480m, null, 18 },
                    { 113, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 6, 6, 15, 55, 274, DateTimeKind.Local).AddTicks(7324), 68, 74.338707828901600m, null, 3 },
                    { 114, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 31, 18, 33, 8, 594, DateTimeKind.Local).AddTicks(2149), 32, 181.2144533661400m, null, 20 },
                    { 115, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 19, 21, 23, 32, 351, DateTimeKind.Local).AddTicks(4687), 62, 107.324566035836520m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 19 },
                    { 116, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 16, 4, 6, 5, 608, DateTimeKind.Local).AddTicks(7288), 77, 102.761822229277440m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 14 },
                    { 117, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 10, 3, 29, 18, 632, DateTimeKind.Local).AddTicks(6677), 70, 233.570277052269600m, null, 10 },
                    { 118, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 3, 20, 34, 57, 566, DateTimeKind.Local).AddTicks(1205), 89, 199.821460473156480m, null, 11 },
                    { 119, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 15, 18, 0, 1, 264, DateTimeKind.Local).AddTicks(1040), 74, 83.021887078777440m, null, 8 },
                    { 120, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 17, 7, 49, 26, 321, DateTimeKind.Local).AddTicks(5292), 33, 21.530464713840840m, null, 12 },
                    { 121, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 9, 18, 42, 33, 885, DateTimeKind.Local).AddTicks(4532), 12, 124.985385150145280m, null, 21 },
                    { 122, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 15, 18, 50, 47, 113, DateTimeKind.Local).AddTicks(646), 34, 165.265603433767680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 15 },
                    { 123, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 17, 4, 26, 21, 205, DateTimeKind.Local).AddTicks(3171), 72, 136.348222698748080m, null, 25 },
                    { 124, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 7, 8, 18, 33, 636, DateTimeKind.Local).AddTicks(3005), 31, 51.9228290336152960m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 17 },
                    { 125, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 16, 0, 38, 23, 277, DateTimeKind.Local).AddTicks(4729), 84, 57.716005822126200m, null, 5 },
                    { 126, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 15, 17, 20, 37, 749, DateTimeKind.Local).AddTicks(8065), 5, 118.582544026382760m, null, 10 },
                    { 127, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 25, 2, 15, 56, 288, DateTimeKind.Local).AddTicks(3433), 98, 85.649055822679440m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 128, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 20, 0, 10, 3, 646, DateTimeKind.Local).AddTicks(9303), 55, 71.218443898234160m, null, 5 },
                    { 129, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 29, 14, 10, 29, 223, DateTimeKind.Local).AddTicks(2548), 94, 183.156548612353920m, null, 11 },
                    { 130, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 22, 5, 35, 58, 129, DateTimeKind.Local).AddTicks(2109), 50, 24.831621452624480m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 13 },
                    { 131, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 14, 6, 28, 23, 885, DateTimeKind.Local).AddTicks(1964), 17, 158.61239265247840m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 14 },
                    { 132, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 29, 5, 52, 58, 730, DateTimeKind.Local).AddTicks(2022), 33, 33.360626878432440m, null, 18 },
                    { 133, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 31, 12, 17, 10, 564, DateTimeKind.Local).AddTicks(8575), 88, 22.60446612946960m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 3 },
                    { 134, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 9, 19, 29, 56, 727, DateTimeKind.Local).AddTicks(3279), 8, 33.923910855138560m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 11 },
                    { 135, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 9, 1, 36, 15, 890, DateTimeKind.Local).AddTicks(1878), 79, 102.930102232426800m, null, 19 },
                    { 136, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 14, 12, 52, 2, 227, DateTimeKind.Local).AddTicks(4349), 54, 15.982119952248320m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 25 },
                    { 137, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 14, 7, 16, 39, 289, DateTimeKind.Local).AddTicks(4048), 14, 209.776693140652400m, null, 23 },
                    { 138, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 3, 26, 5, 48, 1, 702, DateTimeKind.Local).AddTicks(1005), 63, 124.01682148203000m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 18 },
                    { 139, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 21, 0, 38, 45, 594, DateTimeKind.Local).AddTicks(3389), 54, 27.5528550141779520m, null, 16 },
                    { 140, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 27, 21, 19, 0, 735, DateTimeKind.Local).AddTicks(4736), 31, 51.215384542023120m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 7 },
                    { 141, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 12, 15, 13, 51, 487, DateTimeKind.Local).AddTicks(8025), 40, 72.834058553500200m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 17 },
                    { 142, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 26, 1, 47, 57, 390, DateTimeKind.Local).AddTicks(9588), 99, 55.225202130467680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 18 },
                    { 143, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 22, 15, 42, 21, 400, DateTimeKind.Local).AddTicks(3819), 10, 42.250618388268960m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 144, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 15, 5, 4, 19, 64, DateTimeKind.Local).AddTicks(4527), 38, 106.372338831113760m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 21 },
                    { 145, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 8, 11, 59, 9, 33, DateTimeKind.Local).AddTicks(5278), 23, 78.974289302324400m, null, 18 },
                    { 146, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 10, 11, 2, 42, 594, DateTimeKind.Local).AddTicks(4911), 97, 15.882199097133080m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 13 },
                    { 147, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 15, 22, 44, 33, 286, DateTimeKind.Local).AddTicks(5064), 33, 249.006544064115800m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 24 },
                    { 148, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 9, 8, 4, 1, 868, DateTimeKind.Local).AddTicks(2874), 16, 98.936290718673760m, null, 26 },
                    { 149, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 10, 13, 22, 26, 793, DateTimeKind.Local).AddTicks(1561), 26, 137.894133201332880m, null, 1 },
                    { 150, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 6, 15, 49, 29, 867, DateTimeKind.Local).AddTicks(6010), 84, 70.034713159338400m, null, 23 },
                    { 151, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 9, 10, 31, 15, 888, DateTimeKind.Local).AddTicks(162), 89, 212.933974787540400m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 2 },
                    { 152, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 17, 2, 48, 20, 764, DateTimeKind.Local).AddTicks(445), 78, 49.584200793502080m, null, 7 },
                    { 153, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 1, 6, 28, 58, 935, DateTimeKind.Local).AddTicks(359), 80, 182.263447743634560m, null, 3 },
                    { 154, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 3, 20, 22, 16, 248, DateTimeKind.Local).AddTicks(462), 81, 222.622347520446400m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 6 },
                    { 155, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 3, 3, 58, 50, 916, DateTimeKind.Local).AddTicks(1124), 98, 12.806883481059880m, null, 1 },
                    { 156, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 7, 23, 12, 37, 472, DateTimeKind.Local).AddTicks(3112), 89, 66.232264473845520m, null, 23 },
                    { 157, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 1, 19, 3, 29, 940, DateTimeKind.Local).AddTicks(3011), 43, 11.1452852623281680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 20 },
                    { 158, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 12, 21, 27, 16, 591, DateTimeKind.Local).AddTicks(7361), 86, 190.716885266733120m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 1 },
                    { 159, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 28, 9, 45, 33, 342, DateTimeKind.Local).AddTicks(3467), 11, 44.938404975961840m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 5 },
                    { 160, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 13, 5, 5, 44, 656, DateTimeKind.Local).AddTicks(4555), 98, 91.814353987624080m, null, 16 },
                    { 161, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 9, 22, 58, 26, 373, DateTimeKind.Local).AddTicks(4512), 76, 33.485796832511640m, null, 22 },
                    { 162, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 27, 2, 28, 37, 916, DateTimeKind.Local).AddTicks(5054), 66, 133.475768037194200m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 3 },
                    { 163, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 12, 12, 9, 9, 6, 482, DateTimeKind.Local).AddTicks(178), 97, 168.101252099202560m, null, 25 },
                    { 164, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 4, 8, 8, 50, 28, DateTimeKind.Local).AddTicks(8045), 14, 158.28423137355600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 23 },
                    { 165, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 17, 10, 8, 56, 567, DateTimeKind.Local).AddTicks(561), 35, 188.026905259082880m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 21 },
                    { 166, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 16, 7, 35, 15, 911, DateTimeKind.Local).AddTicks(8923), 24, 173.722030711632200m, null, 24 },
                    { 167, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 23, 0, 21, 35, 66, DateTimeKind.Local).AddTicks(4501), 68, 50.812416743415600m, null, 12 },
                    { 168, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 5, 7, 30, 27, 360, DateTimeKind.Local).AddTicks(8104), 79, 197.507420814674880m, null, 13 },
                    { 169, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 16, 20, 44, 24, 981, DateTimeKind.Local).AddTicks(5075), 25, 146.225671531395480m, null, 15 },
                    { 170, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 29, 3, 59, 46, 956, DateTimeKind.Local).AddTicks(7885), 46, 44.998642052596880m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 1 },
                    { 171, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 4, 1, 56, 49, 703, DateTimeKind.Local).AddTicks(7427), 93, 124.844558154123240m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 6 },
                    { 172, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 10, 14, 6, 24, 396, DateTimeKind.Local).AddTicks(3010), 85, 34.660348226708680m, null, 9 },
                    { 173, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 21, 0, 54, 5, 26, DateTimeKind.Local).AddTicks(2709), 95, 31.851777909421840m, null, 14 },
                    { 174, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 3, 20, 19, 21, 8, 771, DateTimeKind.Local).AddTicks(9159), 5, 20.657890355181840m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 7 },
                    { 175, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 20, 6, 54, 34, 961, DateTimeKind.Local).AddTicks(5598), 63, 74.470211270973680m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 10 },
                    { 176, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 3, 11, 0, 37, 703, DateTimeKind.Local).AddTicks(4423), 38, 53.0858229734984320m, null, 8 },
                    { 177, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 4, 12, 24, 46, 83, DateTimeKind.Local).AddTicks(210), 67, 23.830882337494080m, null, 6 },
                    { 178, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 1, 7, 15, 2, 970, DateTimeKind.Local).AddTicks(7586), 49, 176.620690851850080m, null, 6 },
                    { 179, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 30, 10, 8, 31, 790, DateTimeKind.Local).AddTicks(3616), 98, 117.694027802430880m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 18 },
                    { 180, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 31, 7, 43, 6, 536, DateTimeKind.Local).AddTicks(1186), 42, 188.416020823766800m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 12 },
                    { 181, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 27, 15, 0, 21, 375, DateTimeKind.Local).AddTicks(8194), 38, 65.280935446800160m, null, 13 },
                    { 182, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 24, 19, 26, 52, 386, DateTimeKind.Local).AddTicks(9980), 27, 17.30195464136560m, null, 15 },
                    { 183, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 17, 13, 26, 28, 14, DateTimeKind.Local).AddTicks(6608), 24, 17.188052790524440m, null, 9 },
                    { 184, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 2, 16, 30, 58, 230, DateTimeKind.Local).AddTicks(2821), 20, 50.622530468507840m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 4 },
                    { 185, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 23, 15, 52, 27, 747, DateTimeKind.Local).AddTicks(3363), 40, 168.488567880935200m, null, 21 },
                    { 186, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 18, 16, 34, 43, 983, DateTimeKind.Local).AddTicks(2570), 58, 10.14391327570736560m, null, 7 },
                    { 187, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 29, 16, 56, 45, 808, DateTimeKind.Local).AddTicks(2918), 100, 16.865023596943480m, null, 21 },
                    { 188, 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 9, 22, 13, 36, 19, 45, DateTimeKind.Local).AddTicks(4532), 68, 196.950607095462240m, null, 13 },
                    { 189, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 8, 16, 12, 17, 40, 191, DateTimeKind.Local).AddTicks(1303), 18, 134.16756706545240m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 10 },
                    { 190, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 18, 21, 44, 39, 859, DateTimeKind.Local).AddTicks(8712), 89, 52.479173242649880m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 7 },
                    { 191, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 5, 4, 18, 10, 21, 64, DateTimeKind.Local).AddTicks(6883), 40, 52.801040410482640m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 2 },
                    { 192, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 10, 30, 5, 40, 14, 338, DateTimeKind.Local).AddTicks(3004), 51, 38.696657075390560m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 23 },
                    { 193, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 2, 1, 5, 28, 649, DateTimeKind.Local).AddTicks(9769), 30, 90.609017843374720m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 1 },
                    { 194, 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 5, 7, 59, 25, 625, DateTimeKind.Local).AddTicks(2217), 14, 243.656547049197600m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 23 },
                    { 195, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 1, 28, 12, 0, 0, 527, DateTimeKind.Local).AddTicks(7755), 32, 15.922111183058560m, null, 14 },
                    { 196, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2025, 2, 9, 0, 31, 9, 468, DateTimeKind.Local).AddTicks(1146), 65, 48.225995197102560m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 2 },
                    { 197, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 7, 27, 2, 19, 8, 65, DateTimeKind.Local).AddTicks(614), 2, 144.639328191679920m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 1 },
                    { 198, 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 11, 20, 9, 9, 1, 570, DateTimeKind.Local).AddTicks(2566), 29, 147.806054422372200m, null, 18 },
                    { 199, 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 4, 22, 1, 37, 24, 18, DateTimeKind.Local).AddTicks(6650), 97, 99.121013008960m, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), 26 },
                    { 200, 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", new DateTime(2024, 6, 15, 11, 22, 57, 824, DateTimeKind.Local).AddTicks(496), 78, 30.566097378995120m, null, 14 }
                });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "PagoId", "CreatedAt", "CreatedBy", "EntradaId", "Estado", "FechaPago", "MetodoPago", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 1, "Pendiente", new DateTime(2025, 2, 24, 12, 19, 13, 696, DateTimeKind.Local).AddTicks(449), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 2, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 2, "Fallido", new DateTime(2025, 2, 20, 10, 42, 12, 380, DateTimeKind.Local).AddTicks(5169), "PSE", null },
                    { 3, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 3, "Pendiente", new DateTime(2024, 12, 14, 6, 44, 59, 338, DateTimeKind.Local).AddTicks(3024), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 4, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 4, "Pendiente", new DateTime(2024, 8, 31, 14, 21, 40, 753, DateTimeKind.Local).AddTicks(6204), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 5, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 5, "Pagado", new DateTime(2024, 4, 17, 20, 12, 10, 151, DateTimeKind.Local).AddTicks(6783), "Efectivo", null },
                    { 6, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 6, "Fallido", new DateTime(2025, 3, 16, 10, 37, 8, 57, DateTimeKind.Local).AddTicks(5135), "PSE", null },
                    { 7, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 7, "Fallido", new DateTime(2024, 8, 10, 9, 42, 5, 78, DateTimeKind.Local).AddTicks(8243), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 8, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 8, "Fallido", new DateTime(2024, 7, 17, 13, 49, 46, 343, DateTimeKind.Local).AddTicks(3026), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 9, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 9, "Pendiente", new DateTime(2024, 12, 13, 21, 15, 32, 151, DateTimeKind.Local).AddTicks(70), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 10, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 10, "Pendiente", new DateTime(2024, 7, 8, 17, 55, 7, 817, DateTimeKind.Local).AddTicks(650), "PSE", null },
                    { 11, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 11, "Pendiente", new DateTime(2024, 6, 6, 14, 54, 59, 547, DateTimeKind.Local).AddTicks(4511), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 12, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 12, "Pagado", new DateTime(2025, 1, 9, 15, 7, 22, 203, DateTimeKind.Local).AddTicks(3527), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 13, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 13, "Fallido", new DateTime(2025, 2, 2, 19, 5, 59, 650, DateTimeKind.Local).AddTicks(7115), "Tarjeta", null },
                    { 14, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 14, "Pagado", new DateTime(2024, 4, 12, 21, 19, 37, 682, DateTimeKind.Local).AddTicks(8004), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 15, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 15, "Fallido", new DateTime(2024, 12, 5, 23, 23, 59, 132, DateTimeKind.Local).AddTicks(9573), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 16, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 16, "Pendiente", new DateTime(2025, 3, 21, 7, 36, 42, 477, DateTimeKind.Local).AddTicks(8723), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 17, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 17, "Pendiente", new DateTime(2024, 11, 26, 15, 4, 2, 434, DateTimeKind.Local).AddTicks(7679), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 18, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 18, "Pagado", new DateTime(2025, 2, 21, 15, 30, 39, 22, DateTimeKind.Local).AddTicks(8626), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 19, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 19, "Pendiente", new DateTime(2024, 10, 4, 3, 33, 6, 136, DateTimeKind.Local).AddTicks(5385), "Nequi", null },
                    { 20, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 20, "Pendiente", new DateTime(2024, 7, 10, 0, 45, 21, 907, DateTimeKind.Local).AddTicks(5709), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 21, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 21, "Pagado", new DateTime(2025, 1, 29, 18, 36, 0, 629, DateTimeKind.Local).AddTicks(7036), "Nequi", null },
                    { 22, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 22, "Fallido", new DateTime(2025, 1, 12, 11, 41, 18, 429, DateTimeKind.Local).AddTicks(1797), "Efectivo", null },
                    { 23, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 23, "Pagado", new DateTime(2024, 5, 6, 18, 20, 37, 928, DateTimeKind.Local).AddTicks(7026), "PSE", null },
                    { 24, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 24, "Pendiente", new DateTime(2024, 4, 24, 7, 11, 19, 212, DateTimeKind.Local).AddTicks(6179), "Efectivo", null },
                    { 25, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 25, "Pagado", new DateTime(2025, 3, 4, 10, 20, 52, 556, DateTimeKind.Local).AddTicks(3203), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 26, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 26, "Pendiente", new DateTime(2024, 9, 19, 14, 9, 4, 444, DateTimeKind.Local).AddTicks(8060), "PSE", null },
                    { 27, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 27, "Pagado", new DateTime(2025, 2, 3, 21, 41, 51, 60, DateTimeKind.Local).AddTicks(8638), "Tarjeta", null },
                    { 28, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 28, "Pagado", new DateTime(2025, 1, 18, 17, 34, 20, 123, DateTimeKind.Local).AddTicks(6020), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 29, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 29, "Pendiente", new DateTime(2024, 10, 15, 11, 47, 26, 908, DateTimeKind.Local).AddTicks(1787), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 30, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 30, "Fallido", new DateTime(2024, 10, 1, 12, 22, 37, 960, DateTimeKind.Local).AddTicks(5374), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 31, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 31, "Pendiente", new DateTime(2025, 2, 23, 19, 11, 29, 858, DateTimeKind.Local).AddTicks(2583), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 32, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 32, "Pagado", new DateTime(2024, 4, 25, 11, 25, 39, 925, DateTimeKind.Local).AddTicks(4028), "Nequi", null },
                    { 33, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 33, "Pendiente", new DateTime(2024, 10, 27, 11, 13, 7, 414, DateTimeKind.Local).AddTicks(8718), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 34, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 34, "Pagado", new DateTime(2024, 4, 21, 10, 33, 43, 906, DateTimeKind.Local).AddTicks(7876), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 35, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 35, "Pendiente", new DateTime(2024, 8, 26, 13, 38, 46, 653, DateTimeKind.Local).AddTicks(5337), "Tarjeta", null },
                    { 36, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 36, "Pagado", new DateTime(2024, 9, 19, 22, 27, 15, 294, DateTimeKind.Local).AddTicks(5886), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 37, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 37, "Pagado", new DateTime(2025, 1, 17, 18, 56, 21, 638, DateTimeKind.Local).AddTicks(8235), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 38, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 38, "Pagado", new DateTime(2025, 3, 1, 17, 12, 15, 499, DateTimeKind.Local).AddTicks(6361), "Efectivo", null },
                    { 39, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 39, "Pendiente", new DateTime(2024, 10, 14, 7, 50, 52, 444, DateTimeKind.Local).AddTicks(5913), "Tarjeta", null },
                    { 40, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 40, "Fallido", new DateTime(2024, 6, 18, 9, 29, 51, 202, DateTimeKind.Local).AddTicks(3615), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 41, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 41, "Pagado", new DateTime(2024, 12, 7, 7, 50, 56, 405, DateTimeKind.Local).AddTicks(805), "PSE", null },
                    { 42, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 42, "Pendiente", new DateTime(2025, 1, 28, 10, 30, 37, 632, DateTimeKind.Local).AddTicks(9156), "PSE", null },
                    { 43, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 43, "Fallido", new DateTime(2024, 3, 23, 18, 29, 44, 582, DateTimeKind.Local).AddTicks(9623), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 44, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 44, "Fallido", new DateTime(2024, 10, 14, 6, 55, 16, 207, DateTimeKind.Local).AddTicks(8784), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 45, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 45, "Fallido", new DateTime(2024, 12, 14, 22, 58, 13, 27, DateTimeKind.Local).AddTicks(2776), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 46, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 46, "Fallido", new DateTime(2024, 12, 14, 0, 55, 44, 806, DateTimeKind.Local).AddTicks(9107), "Efectivo", null },
                    { 47, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 47, "Pagado", new DateTime(2024, 7, 17, 5, 57, 28, 450, DateTimeKind.Local).AddTicks(161), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 48, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 48, "Pagado", new DateTime(2024, 7, 28, 21, 45, 56, 785, DateTimeKind.Local).AddTicks(9104), "Efectivo", null },
                    { 49, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 49, "Fallido", new DateTime(2024, 5, 2, 10, 40, 22, 464, DateTimeKind.Local).AddTicks(5975), "Tarjeta", null },
                    { 50, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 50, "Pagado", new DateTime(2025, 1, 12, 9, 33, 49, 227, DateTimeKind.Local).AddTicks(2189), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 51, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 51, "Pagado", new DateTime(2024, 11, 19, 7, 54, 15, 447, DateTimeKind.Local).AddTicks(1487), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 52, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 52, "Pagado", new DateTime(2024, 5, 10, 16, 41, 48, 510, DateTimeKind.Local).AddTicks(4683), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 53, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 53, "Pendiente", new DateTime(2024, 9, 4, 22, 5, 19, 273, DateTimeKind.Local).AddTicks(7135), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 54, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 54, "Pendiente", new DateTime(2024, 7, 14, 18, 2, 36, 176, DateTimeKind.Local).AddTicks(6189), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 55, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 55, "Pendiente", new DateTime(2025, 2, 15, 11, 55, 51, 878, DateTimeKind.Local).AddTicks(6758), "Nequi", null },
                    { 56, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 56, "Fallido", new DateTime(2024, 10, 29, 21, 18, 53, 918, DateTimeKind.Local).AddTicks(4891), "Tarjeta", null },
                    { 57, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 57, "Pendiente", new DateTime(2024, 11, 13, 18, 41, 19, 830, DateTimeKind.Local).AddTicks(5756), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 58, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 58, "Fallido", new DateTime(2025, 3, 5, 3, 15, 25, 555, DateTimeKind.Local).AddTicks(7384), "Tarjeta", null },
                    { 59, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 59, "Pagado", new DateTime(2024, 11, 13, 14, 0, 14, 152, DateTimeKind.Local).AddTicks(4043), "PSE", null },
                    { 60, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 60, "Pendiente", new DateTime(2025, 3, 19, 2, 43, 24, 601, DateTimeKind.Local).AddTicks(9500), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 61, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 61, "Fallido", new DateTime(2024, 11, 11, 2, 46, 32, 764, DateTimeKind.Local).AddTicks(8169), "Tarjeta", null },
                    { 62, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 62, "Fallido", new DateTime(2025, 2, 10, 8, 21, 33, 955, DateTimeKind.Local).AddTicks(9318), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 63, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 63, "Pagado", new DateTime(2024, 7, 3, 3, 56, 4, 559, DateTimeKind.Local).AddTicks(8755), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 64, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 64, "Pendiente", new DateTime(2024, 6, 27, 9, 7, 48, 459, DateTimeKind.Local).AddTicks(8406), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 65, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 65, "Pagado", new DateTime(2024, 4, 11, 11, 19, 54, 510, DateTimeKind.Local).AddTicks(7216), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 66, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 66, "Pagado", new DateTime(2025, 1, 13, 10, 52, 37, 149, DateTimeKind.Local).AddTicks(5094), "Efectivo", null },
                    { 67, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 67, "Fallido", new DateTime(2025, 1, 13, 1, 41, 21, 17, DateTimeKind.Local).AddTicks(7114), "PSE", null },
                    { 68, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 68, "Fallido", new DateTime(2025, 1, 30, 22, 10, 51, 555, DateTimeKind.Local).AddTicks(4792), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 69, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 69, "Pagado", new DateTime(2024, 9, 2, 22, 47, 19, 490, DateTimeKind.Local).AddTicks(2840), "Tarjeta", null },
                    { 70, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 70, "Pagado", new DateTime(2024, 9, 30, 15, 31, 13, 575, DateTimeKind.Local).AddTicks(2058), "PSE", null },
                    { 71, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 71, "Fallido", new DateTime(2024, 9, 23, 0, 47, 41, 579, DateTimeKind.Local).AddTicks(4046), "PSE", null },
                    { 72, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 72, "Pagado", new DateTime(2024, 3, 24, 17, 19, 42, 323, DateTimeKind.Local).AddTicks(3333), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 73, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 73, "Pagado", new DateTime(2024, 5, 25, 0, 23, 21, 495, DateTimeKind.Local).AddTicks(769), "Nequi", null },
                    { 74, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 74, "Pagado", new DateTime(2024, 12, 14, 18, 56, 10, 772, DateTimeKind.Local).AddTicks(7598), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 75, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 75, "Pagado", new DateTime(2024, 8, 11, 9, 12, 45, 363, DateTimeKind.Local).AddTicks(3064), "Efectivo", null },
                    { 76, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 76, "Pendiente", new DateTime(2025, 1, 18, 17, 30, 14, 444, DateTimeKind.Local).AddTicks(7074), "Nequi", null },
                    { 77, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 77, "Fallido", new DateTime(2025, 2, 26, 15, 55, 40, 728, DateTimeKind.Local).AddTicks(7320), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 78, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 78, "Fallido", new DateTime(2024, 10, 24, 18, 29, 42, 701, DateTimeKind.Local).AddTicks(730), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 79, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 79, "Pendiente", new DateTime(2025, 3, 1, 13, 29, 10, 339, DateTimeKind.Local).AddTicks(6021), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 80, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 80, "Pendiente", new DateTime(2024, 7, 20, 2, 22, 18, 379, DateTimeKind.Local).AddTicks(6298), "Efectivo", null },
                    { 81, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 81, "Fallido", new DateTime(2025, 3, 19, 3, 1, 42, 899, DateTimeKind.Local).AddTicks(6575), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 82, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 82, "Fallido", new DateTime(2024, 4, 24, 6, 35, 51, 439, DateTimeKind.Local).AddTicks(2947), "PSE", null },
                    { 83, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 83, "Fallido", new DateTime(2024, 6, 30, 14, 29, 31, 985, DateTimeKind.Local).AddTicks(9072), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 84, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 84, "Fallido", new DateTime(2024, 5, 24, 5, 51, 42, 970, DateTimeKind.Local).AddTicks(8098), "Nequi", null },
                    { 85, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 85, "Pagado", new DateTime(2025, 1, 5, 14, 13, 9, 873, DateTimeKind.Local).AddTicks(1678), "Efectivo", null },
                    { 86, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 86, "Fallido", new DateTime(2024, 9, 4, 4, 59, 28, 50, DateTimeKind.Local).AddTicks(2479), "Nequi", null },
                    { 87, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 87, "Fallido", new DateTime(2024, 8, 19, 0, 45, 22, 717, DateTimeKind.Local).AddTicks(4645), "Tarjeta", null },
                    { 88, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 88, "Pendiente", new DateTime(2024, 4, 6, 2, 31, 10, 462, DateTimeKind.Local).AddTicks(1693), "Efectivo", null },
                    { 89, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 89, "Pendiente", new DateTime(2025, 2, 7, 2, 50, 26, 377, DateTimeKind.Local).AddTicks(4799), "Efectivo", null },
                    { 90, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 90, "Pendiente", new DateTime(2024, 7, 14, 6, 42, 21, 354, DateTimeKind.Local).AddTicks(9444), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 91, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 91, "Fallido", new DateTime(2025, 1, 8, 20, 36, 0, 263, DateTimeKind.Local).AddTicks(2403), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 92, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 92, "Pendiente", new DateTime(2025, 2, 4, 14, 1, 12, 640, DateTimeKind.Local).AddTicks(2709), "Tarjeta", null },
                    { 93, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 93, "Pagado", new DateTime(2025, 2, 4, 21, 49, 23, 24, DateTimeKind.Local).AddTicks(3682), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 94, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 94, "Pendiente", new DateTime(2025, 3, 21, 18, 20, 40, 363, DateTimeKind.Local).AddTicks(6367), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 95, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 95, "Pagado", new DateTime(2024, 3, 29, 9, 53, 58, 601, DateTimeKind.Local).AddTicks(3385), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 96, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 96, "Fallido", new DateTime(2025, 1, 4, 3, 4, 12, 283, DateTimeKind.Local).AddTicks(8373), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 97, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 97, "Pendiente", new DateTime(2025, 1, 14, 14, 26, 53, 223, DateTimeKind.Local).AddTicks(2744), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 98, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 98, "Pagado", new DateTime(2025, 3, 17, 11, 20, 27, 14, DateTimeKind.Local).AddTicks(1135), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 99, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 99, "Pendiente", new DateTime(2025, 1, 29, 7, 10, 52, 782, DateTimeKind.Local).AddTicks(9644), "Tarjeta", null },
                    { 100, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 100, "Fallido", new DateTime(2025, 1, 20, 17, 30, 29, 923, DateTimeKind.Local).AddTicks(717), "Tarjeta", null },
                    { 101, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 101, "Fallido", new DateTime(2024, 12, 21, 11, 7, 4, 307, DateTimeKind.Local).AddTicks(387), "Tarjeta", null },
                    { 102, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 102, "Fallido", new DateTime(2024, 11, 29, 19, 0, 54, 42, DateTimeKind.Local).AddTicks(8725), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 103, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 103, "Fallido", new DateTime(2024, 3, 27, 10, 19, 21, 235, DateTimeKind.Local).AddTicks(494), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 104, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 104, "Pagado", new DateTime(2025, 3, 16, 13, 48, 45, 367, DateTimeKind.Local).AddTicks(2551), "Tarjeta", null },
                    { 105, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 105, "Pagado", new DateTime(2025, 2, 7, 6, 49, 7, 432, DateTimeKind.Local).AddTicks(3828), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 106, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 106, "Pendiente", new DateTime(2025, 1, 28, 0, 29, 1, 12, DateTimeKind.Local).AddTicks(4481), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 107, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 107, "Pagado", new DateTime(2024, 7, 15, 2, 55, 45, 953, DateTimeKind.Local).AddTicks(449), "PSE", null },
                    { 108, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 108, "Fallido", new DateTime(2024, 4, 1, 9, 1, 12, 699, DateTimeKind.Local).AddTicks(6320), "Efectivo", null },
                    { 109, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 109, "Fallido", new DateTime(2024, 4, 1, 14, 4, 38, 740, DateTimeKind.Local).AddTicks(766), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 110, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 110, "Pagado", new DateTime(2025, 3, 15, 10, 0, 20, 703, DateTimeKind.Local).AddTicks(4785), "Nequi", null },
                    { 111, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 111, "Pagado", new DateTime(2024, 6, 3, 18, 48, 30, 697, DateTimeKind.Local).AddTicks(5923), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 112, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 112, "Fallido", new DateTime(2025, 3, 8, 4, 25, 24, 406, DateTimeKind.Local).AddTicks(5762), "Tarjeta", null },
                    { 113, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 113, "Fallido", new DateTime(2024, 7, 19, 4, 24, 10, 204, DateTimeKind.Local).AddTicks(2707), "Efectivo", null },
                    { 114, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 114, "Pagado", new DateTime(2024, 10, 3, 20, 6, 34, 52, DateTimeKind.Local).AddTicks(5880), "Efectivo", null },
                    { 115, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 115, "Pagado", new DateTime(2024, 12, 15, 19, 38, 29, 624, DateTimeKind.Local).AddTicks(8534), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 116, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 116, "Pagado", new DateTime(2024, 11, 4, 17, 25, 6, 314, DateTimeKind.Local).AddTicks(5579), "Tarjeta", null },
                    { 117, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 117, "Pendiente", new DateTime(2025, 1, 11, 14, 44, 28, 208, DateTimeKind.Local).AddTicks(5158), "PSE", null },
                    { 118, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 118, "Pagado", new DateTime(2024, 4, 10, 2, 50, 5, 394, DateTimeKind.Local).AddTicks(4504), "Efectivo", null },
                    { 119, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 119, "Fallido", new DateTime(2025, 1, 30, 5, 34, 38, 423, DateTimeKind.Local).AddTicks(2913), "Tarjeta", null },
                    { 120, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 120, "Fallido", new DateTime(2024, 5, 27, 9, 42, 11, 861, DateTimeKind.Local).AddTicks(8242), "Nequi", null },
                    { 121, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 121, "Fallido", new DateTime(2025, 1, 5, 3, 8, 41, 627, DateTimeKind.Local).AddTicks(9670), "PSE", null },
                    { 122, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 122, "Pagado", new DateTime(2024, 3, 31, 17, 50, 55, 782, DateTimeKind.Local).AddTicks(2811), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 123, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 123, "Pagado", new DateTime(2024, 5, 16, 12, 30, 50, 709, DateTimeKind.Local).AddTicks(1165), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 124, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 124, "Fallido", new DateTime(2024, 5, 12, 21, 54, 10, 648, DateTimeKind.Local).AddTicks(9063), "Nequi", null },
                    { 125, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 125, "Pagado", new DateTime(2024, 6, 11, 12, 23, 44, 424, DateTimeKind.Local).AddTicks(2135), "PSE", null },
                    { 126, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 126, "Pagado", new DateTime(2024, 8, 29, 18, 41, 55, 436, DateTimeKind.Local).AddTicks(3707), "PSE", null },
                    { 127, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 127, "Fallido", new DateTime(2024, 9, 11, 5, 30, 51, 735, DateTimeKind.Local).AddTicks(8259), "PSE", null },
                    { 128, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 128, "Pagado", new DateTime(2025, 1, 24, 7, 51, 59, 750, DateTimeKind.Local).AddTicks(7334), "Nequi", null },
                    { 129, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 129, "Pendiente", new DateTime(2024, 4, 11, 9, 55, 3, 50, DateTimeKind.Local).AddTicks(7868), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 130, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 130, "Pagado", new DateTime(2024, 11, 20, 15, 34, 35, 365, DateTimeKind.Local).AddTicks(9982), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 131, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 131, "Fallido", new DateTime(2024, 10, 18, 5, 43, 11, 244, DateTimeKind.Local).AddTicks(1654), "PSE", null },
                    { 132, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 132, "Fallido", new DateTime(2025, 3, 13, 19, 51, 50, 300, DateTimeKind.Local).AddTicks(8400), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 133, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 133, "Pendiente", new DateTime(2024, 7, 29, 18, 21, 32, 656, DateTimeKind.Local).AddTicks(4272), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 134, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 134, "Pagado", new DateTime(2024, 12, 3, 0, 8, 21, 223, DateTimeKind.Local).AddTicks(8353), "PSE", null },
                    { 135, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 135, "Pagado", new DateTime(2025, 1, 18, 11, 15, 14, 356, DateTimeKind.Local).AddTicks(2883), "PSE", null },
                    { 136, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 136, "Fallido", new DateTime(2025, 1, 25, 11, 59, 41, 214, DateTimeKind.Local).AddTicks(1824), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 137, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 137, "Pagado", new DateTime(2024, 8, 3, 22, 50, 28, 340, DateTimeKind.Local).AddTicks(4229), "Tarjeta", null },
                    { 138, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 138, "Pendiente", new DateTime(2024, 9, 3, 0, 29, 20, 335, DateTimeKind.Local).AddTicks(6474), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 139, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 139, "Pagado", new DateTime(2024, 12, 7, 11, 58, 24, 193, DateTimeKind.Local).AddTicks(6022), "Nequi", null },
                    { 140, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 140, "Fallido", new DateTime(2024, 3, 31, 3, 44, 1, 260, DateTimeKind.Local).AddTicks(4094), "Tarjeta", null },
                    { 141, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 141, "Fallido", new DateTime(2024, 6, 14, 11, 8, 14, 36, DateTimeKind.Local).AddTicks(567), "Efectivo", null },
                    { 142, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 142, "Pagado", new DateTime(2024, 6, 15, 8, 43, 30, 399, DateTimeKind.Local).AddTicks(52), "Efectivo", null },
                    { 143, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 143, "Pagado", new DateTime(2024, 9, 9, 14, 26, 35, 757, DateTimeKind.Local).AddTicks(4644), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 144, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 144, "Pendiente", new DateTime(2024, 4, 19, 15, 13, 46, 977, DateTimeKind.Local).AddTicks(262), "Nequi", null },
                    { 145, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 145, "Pagado", new DateTime(2024, 3, 27, 16, 47, 25, 735, DateTimeKind.Local).AddTicks(8011), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 146, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 146, "Fallido", new DateTime(2025, 1, 6, 21, 35, 2, 801, DateTimeKind.Local).AddTicks(4849), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 147, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 147, "Pendiente", new DateTime(2024, 10, 13, 4, 49, 55, 218, DateTimeKind.Local).AddTicks(3323), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 148, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 148, "Pendiente", new DateTime(2024, 12, 21, 14, 49, 8, 312, DateTimeKind.Local).AddTicks(2696), "Tarjeta", null },
                    { 149, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 149, "Pagado", new DateTime(2024, 6, 4, 8, 25, 17, 310, DateTimeKind.Local).AddTicks(518), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 150, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 150, "Pagado", new DateTime(2025, 3, 2, 11, 1, 18, 261, DateTimeKind.Local).AddTicks(2310), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 151, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 151, "Pagado", new DateTime(2024, 11, 28, 19, 4, 14, 946, DateTimeKind.Local).AddTicks(6765), "Nequi", null },
                    { 152, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 152, "Pendiente", new DateTime(2025, 3, 19, 21, 27, 24, 485, DateTimeKind.Local).AddTicks(32), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 153, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 153, "Pendiente", new DateTime(2024, 6, 9, 0, 39, 29, 797, DateTimeKind.Local).AddTicks(6980), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 154, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 154, "Fallido", new DateTime(2024, 11, 10, 23, 25, 42, 753, DateTimeKind.Local).AddTicks(9839), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 155, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 155, "Pendiente", new DateTime(2024, 10, 28, 8, 34, 24, 283, DateTimeKind.Local).AddTicks(4920), "Tarjeta", null },
                    { 156, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 156, "Fallido", new DateTime(2024, 10, 22, 9, 37, 0, 16, DateTimeKind.Local).AddTicks(6464), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 157, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 157, "Pagado", new DateTime(2024, 12, 18, 3, 38, 34, 526, DateTimeKind.Local).AddTicks(6583), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 158, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 158, "Fallido", new DateTime(2024, 7, 24, 9, 50, 59, 250, DateTimeKind.Local).AddTicks(300), "PSE", null },
                    { 159, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 159, "Pendiente", new DateTime(2024, 8, 9, 7, 25, 57, 268, DateTimeKind.Local).AddTicks(9286), "PSE", null },
                    { 160, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 160, "Fallido", new DateTime(2024, 11, 12, 23, 42, 24, 627, DateTimeKind.Local).AddTicks(2179), "Nequi", null },
                    { 161, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 161, "Pagado", new DateTime(2025, 2, 1, 20, 52, 38, 903, DateTimeKind.Local).AddTicks(1989), "Efectivo", null },
                    { 162, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 162, "Pendiente", new DateTime(2024, 5, 5, 23, 9, 44, 543, DateTimeKind.Local).AddTicks(8585), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 163, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 163, "Fallido", new DateTime(2025, 2, 6, 8, 55, 34, 8, DateTimeKind.Local).AddTicks(2186), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 164, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 164, "Pagado", new DateTime(2024, 11, 13, 20, 57, 5, 408, DateTimeKind.Local).AddTicks(2076), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 165, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 165, "Pagado", new DateTime(2024, 11, 17, 12, 51, 34, 351, DateTimeKind.Local).AddTicks(2119), "PSE", null },
                    { 166, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 166, "Pendiente", new DateTime(2025, 1, 7, 17, 32, 17, 162, DateTimeKind.Local).AddTicks(2911), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 167, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 167, "Fallido", new DateTime(2024, 7, 23, 13, 12, 45, 128, DateTimeKind.Local).AddTicks(3890), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 168, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 168, "Pendiente", new DateTime(2024, 9, 4, 19, 41, 19, 278, DateTimeKind.Local).AddTicks(1812), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 169, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 169, "Fallido", new DateTime(2024, 12, 14, 3, 23, 25, 4, DateTimeKind.Local).AddTicks(5191), "Nequi", null },
                    { 170, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 170, "Fallido", new DateTime(2024, 12, 4, 15, 33, 46, 245, DateTimeKind.Local).AddTicks(3989), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 171, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 171, "Pagado", new DateTime(2024, 10, 6, 16, 5, 30, 125, DateTimeKind.Local).AddTicks(5811), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 172, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 172, "Pagado", new DateTime(2025, 2, 20, 2, 12, 42, 445, DateTimeKind.Local).AddTicks(6262), "Tarjeta", null },
                    { 173, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 173, "Pagado", new DateTime(2024, 12, 12, 4, 24, 59, 268, DateTimeKind.Local).AddTicks(5755), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 174, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 174, "Fallido", new DateTime(2025, 3, 6, 2, 1, 3, 559, DateTimeKind.Local).AddTicks(6006), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 175, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 175, "Pagado", new DateTime(2025, 1, 2, 20, 5, 14, 836, DateTimeKind.Local).AddTicks(4830), "Tarjeta", null },
                    { 176, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 176, "Pagado", new DateTime(2025, 2, 2, 6, 7, 44, 170, DateTimeKind.Local).AddTicks(342), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 177, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 177, "Pagado", new DateTime(2024, 5, 31, 6, 23, 15, 557, DateTimeKind.Local).AddTicks(4281), "PSE", null },
                    { 178, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 178, "Pendiente", new DateTime(2024, 10, 9, 12, 41, 23, 272, DateTimeKind.Local).AddTicks(6995), "Efectivo", null },
                    { 179, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 179, "Fallido", new DateTime(2024, 5, 4, 5, 9, 10, 44, DateTimeKind.Local).AddTicks(6396), "Nequi", null },
                    { 180, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 180, "Pagado", new DateTime(2024, 5, 18, 0, 16, 1, 165, DateTimeKind.Local).AddTicks(7585), "Efectivo", null },
                    { 181, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 181, "Pagado", new DateTime(2024, 6, 12, 16, 54, 13, 969, DateTimeKind.Local).AddTicks(7564), "Nequi", null },
                    { 182, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 182, "Pagado", new DateTime(2024, 10, 30, 19, 19, 43, 318, DateTimeKind.Local).AddTicks(8462), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 183, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 183, "Pagado", new DateTime(2025, 3, 5, 10, 35, 38, 276, DateTimeKind.Local).AddTicks(4341), "PSE", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 184, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 184, "Fallido", new DateTime(2024, 4, 30, 19, 18, 42, 920, DateTimeKind.Local).AddTicks(8145), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 185, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 185, "Fallido", new DateTime(2024, 7, 30, 16, 54, 23, 216, DateTimeKind.Local).AddTicks(6398), "PSE", null },
                    { 186, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 186, "Pendiente", new DateTime(2025, 1, 3, 11, 55, 41, 825, DateTimeKind.Local).AddTicks(1797), "PSE", null },
                    { 187, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 187, "Fallido", new DateTime(2025, 1, 4, 23, 33, 3, 870, DateTimeKind.Local).AddTicks(6581), "PSE", null },
                    { 188, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 188, "Pagado", new DateTime(2024, 4, 8, 5, 20, 46, 331, DateTimeKind.Local).AddTicks(9144), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 189, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 189, "Pendiente", new DateTime(2024, 10, 23, 11, 48, 34, 850, DateTimeKind.Local).AddTicks(6607), "PSE", null },
                    { 190, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 190, "Pendiente", new DateTime(2024, 12, 18, 23, 3, 25, 547, DateTimeKind.Local).AddTicks(4465), "Efectivo", null },
                    { 191, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 191, "Pendiente", new DateTime(2024, 11, 8, 7, 49, 15, 396, DateTimeKind.Local).AddTicks(5087), "Tarjeta", null },
                    { 192, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 192, "Pagado", new DateTime(2024, 4, 2, 4, 16, 19, 511, DateTimeKind.Local).AddTicks(8227), "Efectivo", null },
                    { 193, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 193, "Pagado", new DateTime(2024, 5, 6, 3, 27, 16, 471, DateTimeKind.Local).AddTicks(714), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 194, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 194, "Pagado", new DateTime(2025, 3, 1, 0, 44, 59, 802, DateTimeKind.Local).AddTicks(772), "PSE", null },
                    { 195, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 195, "Pendiente", new DateTime(2024, 10, 24, 17, 50, 20, 788, DateTimeKind.Local).AddTicks(1491), "PSE", null },
                    { 196, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 196, "Pagado", new DateTime(2024, 8, 9, 1, 47, 14, 502, DateTimeKind.Local).AddTicks(6839), "PSE", null },
                    { 197, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 197, "Pagado", new DateTime(2024, 6, 22, 18, 35, 31, 337, DateTimeKind.Local).AddTicks(9666), "Tarjeta", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 198, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 198, "Pagado", new DateTime(2024, 12, 26, 14, 39, 51, 179, DateTimeKind.Local).AddTicks(1524), "Efectivo", null },
                    { 199, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 199, "Pagado", new DateTime(2024, 7, 21, 16, 4, 42, 809, DateTimeKind.Local).AddTicks(798), "Efectivo", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) },
                    { 200, new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648), "Api User", 200, "Fallido", new DateTime(2024, 9, 24, 17, 43, 26, 404, DateTimeKind.Local).AddTicks(9564), "Nequi", new DateTime(2025, 3, 23, 14, 49, 56, 439, DateTimeKind.Utc).AddTicks(7648) }
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
