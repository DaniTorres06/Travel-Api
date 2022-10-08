using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel_Api.Models.Repository
{
    public interface IEditorialesRepository
    {
        Task<List<Editoriales>> GetListEditoriales();
        
        Task<Editoriales> GetEditorialesXId(int id);
        Task<Editoriales> AddEditoriales(Editoriales editoriales);
        Task UpdateEditoriales(Editoriales editoriales);
        Task DeleteEditoriales(Editoriales editoriales);
        
    }
}
