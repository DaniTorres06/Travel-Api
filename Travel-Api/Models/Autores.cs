using System.ComponentModel.DataAnnotations;

namespace Travel_Api.Models
{
    public class Autores
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string apellidos { get; set; }

    }
}
