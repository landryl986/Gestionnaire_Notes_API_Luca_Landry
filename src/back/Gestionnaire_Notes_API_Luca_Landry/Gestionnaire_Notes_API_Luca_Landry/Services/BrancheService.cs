using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Gestionnaire_Notes_API_Luca_Landry.Exceptions;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Gestionnaire_Notes_API_Luca_Landry.Repos;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class BrancheService : IBrancheService
    {
        private readonly IBranche _repo;

        public BrancheService(IBranche repo)
        {
            _repo = repo;
        }
        public createBrancheDTO AddBranche(createBrancheDTO newBranche)
        {
            if (newBranche == null)
                throw new ArgumentNullException(nameof(newBranche));
            
            //Nous ne contrôlons pas si une branche du même nom existe déjà car exemple : user 1 a math et user 2 aussi.
            
            return _repo.AddBranche(newBranche);
        }

        public void Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Branche Id:{id} doesn't exists.");
            
            _repo.Delete(id);
        }

        public bool ExistsById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            return _repo.ExistsById(id);
        }

        public bool ExistsByName(string name)
        {
            return ExistsByName(name);
        }

        public async Task<IList<BrancheModel>> GetAll()
        {
            return _repo.GetAll();
        }

        public BrancheModel GetSingle(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Branche Id:{id} doesn't exists.");

            return _repo.GetSingle(id);
        }

        public async Task<PatchBrancheModel> Update(int id, PatchBrancheModel model)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Branche Id:{id} doesn't exists.");

            return _repo.Update(id, model);
        }
    }
}