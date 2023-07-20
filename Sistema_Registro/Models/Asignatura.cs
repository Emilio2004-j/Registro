namespace Sistema_Registro.Models
{
    public class Asignatura
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFinal { get; set; }
        public int MaestroID { get; set; }
        public int AulaID { get; set; }
        public Aula? Aula { get; set; }
        public Maestro? Maestro { get; set; }
        public ICollection<Registro_Nota>? Registro_Notas { get; set; }
    }
}
