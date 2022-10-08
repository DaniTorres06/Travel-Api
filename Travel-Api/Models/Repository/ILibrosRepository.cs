using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel_Api.Models.Repository
{
    public interface ILibrosRepository
    {
        Task<List<Libros>> GetListLibros();
        Task<Libros> GetLibrosXId(int id);
        Task<Libros> AddLibros(Libros libros);
        Task UpdateLibros(Libros libros);
        Task DeleteLibros(Libros libros);
    }
}
