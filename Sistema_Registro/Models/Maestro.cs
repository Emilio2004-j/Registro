using System.Security.Cryptography.Xml;

namespace Sistema_Registro.Models
{
    public class Maestro
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public int Edad { get; set; }
        public ICollection<Asignatura>? Asignaturas { get; set; }
    }
}
