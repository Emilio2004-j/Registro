using System.Security.Cryptography.Xml;

namespace Sistema_Registro.Models
{
    public class Aula
    {
        public int ID { get; set; }
        public int Seccion { get; set; }
        public int Cantidad { get; set; }
        public ICollection<Asignatura>? Asignaturas { get; set; }
    }
}
