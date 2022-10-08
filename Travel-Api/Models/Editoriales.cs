using System.ComponentModel.DataAnnotations;

namespace Travel_Api.Models
{
    public class Editoriales
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string Sede { get; set; }

    }
}
