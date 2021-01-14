using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.InterfacesService
{
    public interface INoteService
    {
        createNoteDTO AddNote(createNoteDTO newNote);
        void Delete(int id);
        bool ExistsById(int id);
        Task<IList<NoteModel>> GetAll();
        NoteModel GetSingle(int id);
        Task<PatchNoteModel> Update(int id, PatchNoteModel model);
    }
}