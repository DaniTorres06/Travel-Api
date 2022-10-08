using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel_Api.Context;

namespace Travel_Api.Models.Repository
{
    public class AutoresHasLibrosRepository: IAutoresHasLibrosRepository
    {
        private readonly AplicationDbContext _context;

        public AutoresHasLibrosRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Autores_has_libros>> GetListAutoresHasLibros()
        {
            return await _context.Autores_has_libros.ToListAsync();
        }

        public async Task<Autores_has_libros> GetAutoresHasLibrosXId(int id)
        {
            return await _context.Autores_has_libros.FindAsync(id);
        }


        public async Task<Autores_has_libros> AddAutoresHasLibros(Autores_has_libros autores_has_libro)
        {
            _context.Add(autores_has_libro);
            await _context.SaveChangesAsync();
            return autores_has_libro;
        }

        public async Task UpdateAutoresHasLibros(Autores_has_libros autores_has_libro)
        {
            var autores_has_libroItem = await _context.Autores_has_libros.FirstOrDefaultAsync(x => x.Id == autores_has_libro.Id);

            if (autores_has_libroItem != null)
            {
                autores_has_libroItem.autores_id = autores_has_libro.autores_id;
                autores_has_libroItem.libros_ISBN = autores_has_libro.libros_ISBN;


                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAutoresHasLibros(Autores_has_libros autores_has_libro)
        {
            _context.Autores_has_libros.Remove(autores_has_libro);
            await _context.SaveChangesAsync();
        }
    }
}
