using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel_Api.Context;

namespace Travel_Api.Models.Repository
{
    public class EditorialesRepository : IEditorialesRepository
    {
        private readonly AplicationDbContext _context;

        public EditorialesRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Editoriales>> GetListEditoriales()
        {
            return await _context.Editoriales.ToListAsync();
        }

        
        public async Task<Editoriales> GetEditorialesXId(int id)
        {
            return await _context.Editoriales.FindAsync(id);
        }

        public async Task<Editoriales> AddEditoriales(Editoriales editoriales)
        {
            _context.Add(editoriales);
            await _context.SaveChangesAsync();
            return editoriales;
        }

        public async Task UpdateEditoriales(Editoriales editoriales)
        {
            var editorialesItem = await _context.Editoriales.FirstOrDefaultAsync(x => x.Id == editoriales.Id);

            if (editorialesItem != null)
            {
                editorialesItem.Nombre = editoriales.Nombre;
                editorialesItem.Sede = editoriales.Sede;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteEditoriales(Editoriales editoriales)
        {
            _context.Editoriales.Remove(editoriales);
            await _context.SaveChangesAsync();
        }
        
    }
}
