using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel_Api.Models.Repository
{
    public interface IAutoresRepository
    {
        Task<List<Autores>> GetListAutores();
        Task<Autores> GetAutoresXId(int id);
        Task<Autores> AddAutores(Autores autores);
        Task UpdateAutores(Autores autores);
        Task DeleteAutores(Autores autores);
    }
}
