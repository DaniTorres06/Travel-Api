using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel_Api.Context;

namespace Travel_Api.Models.Repository
{
    public class AutoresRepository: IAutoresRepository
    {
        private readonly AplicationDbContext _context;

        public AutoresRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Autores>> GetListAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autores> GetAutoresXId(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task<Autores> AddAutores(Autores autores)
        {
            _context.Add(autores);
            await _context.SaveChangesAsync();
            return autores;
        }

        public async Task UpdateAutores(Autores autores)
        {
            var autoresItem = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autores.Id);

            if (autoresItem != null)
            {
                autoresItem.nombre = autores.nombre;
                autoresItem.apellidos = autores.apellidos;


                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAutores(Autores autores)
        {
            _context.Autores.Remove(autores);
            await _context.SaveChangesAsync();
        }

    }
}
