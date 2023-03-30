using System.ComponentModel.DataAnnotations;

namespace APIEvaluacion.Entities
{
    public class Destinatario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set;}
        [Required]
        public string Correo { get; set; }
        public List<Paquete> Paquetes { get; set; }
    }
}
