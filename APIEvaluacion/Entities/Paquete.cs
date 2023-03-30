using System.ComponentModel.DataAnnotations;

namespace APIEvaluacion.Entities
{
    public class Paquete
    {
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Peso { get; set; }
    }
}
