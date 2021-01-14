using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Exceptions;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class NoteService : INoteService
    {
        private readonly INote _repo;

        public NoteService(INote repo)
        {
            _repo = repo;
        }
        public createNoteDTO AddNote(createNoteDTO newNote)
        {
            if (newNote == null)
                throw new ArgumentNullException(nameof(newNote));
            
            return _repo.AddNote(newNote);
        }

        public void Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Note Id:{id} doesn't exists.");
            
            _repo.Delete(id);
        }

        public bool ExistsById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            return _repo.ExistsById(id);
        }

        public async Task<IList<NoteModel>> GetAll()
        {
            return _repo.GetAll();
        }

        public NoteModel GetSingle(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Note Id:{id} doesn't exists.");

            return _repo.GetSingle(id);
        }

        public async Task<PatchNoteModel> Update(int id, PatchNoteModel model)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Note Id:{id} doesn't exists.");

            return _repo.Update(id, model);
        }
    }
}