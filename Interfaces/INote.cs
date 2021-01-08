using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface INote
    {
        NoteModel AddNote(NoteModel newNote);
        void Delete(int id);
        bool ExistsById(int id);
        IList<NoteModel> GetAll();
        NoteModel GetSingle(int id);
        NoteModel Update(int id, NoteModel model);
    }
}