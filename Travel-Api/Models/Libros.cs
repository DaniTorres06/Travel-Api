using System.ComponentModel.DataAnnotations;

namespace Travel_Api.Models
{

    public class Libros
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public int Editoriales_id { get; set; }

        [Required]
        [StringLength(45)]
        public string Titulo { set; get; }
        public string Sinopsis { set; get; }

        [Required]
        [StringLength(45)]
        public string N_paginas { set; get; }


    }
}
