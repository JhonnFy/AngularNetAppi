namespace CapaAPI.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }
        public decimal Valor { get; set; }

        public Nota()
        {
            Id = 0;
            Nombre = string.Empty;
            IdProfesor = 0;
            IdEstudiante = 0;
            Valor = 0;
        }
    }
}
