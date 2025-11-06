namespace CapaAPI.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Profesor()
        {
            Id = 0;
            Nombre = string.Empty;
        }
    }
}
