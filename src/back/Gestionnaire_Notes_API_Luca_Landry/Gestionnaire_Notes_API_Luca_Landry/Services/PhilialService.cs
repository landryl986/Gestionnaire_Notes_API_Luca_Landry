using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Exceptions;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class PhilialService : IPhilialService
    {
        private readonly IPhilial _repo;

        public PhilialService(IPhilial repo)
        {
            _repo = repo;
        }
        public createPhilialDTO AddPhilial(createPhilialDTO newPhilial)
        {
            if (newPhilial == null)
                throw new ArgumentNullException(nameof(newPhilial));
            
            if (_repo.ExistsByName(newPhilial.philialName))
                throw new ArgumentException(nameof(newPhilial.philialName), $"Philial {newPhilial.philialName} already exists.");
            
            return _repo.AddPhilial(newPhilial);
        }

        public void Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Philial Id:{id} doesn't exists.");
            
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

        public async Task<IList<PhilialModel>> GetAll()
        {
            return _repo.GetAll();
        }

        public PhilialModel GetSingle(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Philial Id:{id} doesn't exists.");

            return _repo.GetSingle(id);
        }

        public async Task<PatchPhilialModel> Update(int id, PatchPhilialModel model)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"Philial Id:{id} doesn't exists.");

            return _repo.Update(id, model);
        }
    }
}