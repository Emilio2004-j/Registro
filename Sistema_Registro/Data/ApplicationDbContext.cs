using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_Registro.Models;

namespace Sistema_Registro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Registro_Nota> Registro_Notas { get; set; }
        public DbSet<Aula> Aulas { get; set; }
    }
}