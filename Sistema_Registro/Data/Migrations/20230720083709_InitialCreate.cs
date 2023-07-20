using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Registro.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seccion = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fechanacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaestroID = table.Column<int>(type: "int", nullable: false),
                    AulaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Aulas_AulaID",
                        column: x => x.AulaID,
                        principalTable: "Aulas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Maestros_MaestroID",
                        column: x => x.MaestroID,
                        principalTable: "Maestros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registro_Notas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estudiante_ID = table.Column<int>(type: "int", nullable: false),
                    Asignatura_ID = table.Column<int>(type: "int", nullable: false),
                    Nota1 = table.Column<int>(type: "int", nullable: false),
                    Nota2 = table.Column<int>(type: "int", nullable: false),
                    NotaFinal = table.Column<int>(type: "int", nullable: false),
                    Aprobada = table.Column<bool>(type: "bit", nullable: false),
                    EstudianteID = table.Column<int>(type: "int", nullable: true),
                    AsignaturaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_Notas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registro_Notas_Asignaturas_AsignaturaID",
                        column: x => x.AsignaturaID,
                        principalTable: "Asignaturas",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Registro_Notas_Estudiantes_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiantes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_AulaID",
                table: "Asignaturas",
                column: "AulaID");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_MaestroID",
                table: "Asignaturas",
                column: "MaestroID");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Notas_AsignaturaID",
                table: "Registro_Notas",
                column: "AsignaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Notas_EstudianteID",
                table: "Registro_Notas",
                column: "EstudianteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro_Notas");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Maestros");
        }
    }
}
