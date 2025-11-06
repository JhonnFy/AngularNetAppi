namespace CapaAPI.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Estudiante()
        {
            Id = 0;
            Nombre = string.Empty;
        }
    }
}
