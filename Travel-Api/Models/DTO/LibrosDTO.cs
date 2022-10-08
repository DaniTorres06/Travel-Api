namespace Travel_Api.Models.DTO
{
    public class LibrosDTO
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public int Editoriales_id { get; set; }        
        public string Titulo { set; get; }
        public string Sinopsis { set; get; }
        public string N_paginas { set; get; }
    }
}
