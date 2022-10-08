using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel_Api.Models.Repository
{
    public interface IAutoresHasLibrosRepository
    {
        Task<List<Autores_has_libros>> GetListAutoresHasLibros();
        Task<Autores_has_libros> GetAutoresHasLibrosXId(int id);
        Task<Autores_has_libros> AddAutoresHasLibros(Autores_has_libros autores_has_libro);
        Task UpdateAutoresHasLibros(Autores_has_libros autores_has_libro);
        Task DeleteAutoresHasLibros(Autores_has_libros autores_has_libro);
    }
}
