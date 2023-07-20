namespace Sistema_Registro.Models
{
    public class Registro_Nota
    {
        public int ID { get; set; }
        public int Estudiante_ID { get; set; }
        public int Asignatura_ID { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int NotaFinal { get; set; }
        public bool Aprobada { get; set; }
        public Estudiante? Estudiante { get; set; }
        public Asignatura? Asignatura { get; set; }
    }
}
