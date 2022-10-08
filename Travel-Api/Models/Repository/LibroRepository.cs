using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel_Api.Context;

namespace Travel_Api.Models.Repository
{
    public class LibroRepository: ILibrosRepository
    {
        private readonly AplicationDbContext _context;

        public LibroRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Libros>> GetListLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task<Libros> GetLibrosXId(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<Libros> AddLibros(Libros libros)
        {
            _context.Add(libros);
            await _context.SaveChangesAsync();
            return libros;
        }              

        public async Task UpdateLibros(Libros libros)
        {
            var librosItem = await _context.Libros.FirstOrDefaultAsync(x => x.Id == libros.Id);

            if (librosItem != null)
            {
                librosItem.ISBN = libros.ISBN;
                librosItem.Editoriales_id = libros.Editoriales_id;
                librosItem.Titulo = libros.Titulo;
                librosItem.Sinopsis = libros.Sinopsis;
                librosItem.N_paginas = libros.N_paginas;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLibros(Libros libros)
        {
            _context.Libros.Remove(libros);
            await _context.SaveChangesAsync();
        }
    }
}
