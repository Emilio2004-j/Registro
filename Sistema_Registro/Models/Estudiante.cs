namespace Sistema_Registro.Models
{
    public class Estudiante
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? Correo { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public int Telefono { get; set; }
        public string? Grado { get; set; }
        public ICollection<Registro_Nota>? Registro_Notas { get; set; }
    }
}
