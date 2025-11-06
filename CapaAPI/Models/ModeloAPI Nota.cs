namespace CapaAPI.Models
{
    public class Nota
    { 
        public int Id { get; set; }            
        public string Nombre { get; set; }     
        public int IdProfesor { get; set; }    
        public int IdEstudiante { get; set; }
        public decimal Valor { get; set; }
    }
}
