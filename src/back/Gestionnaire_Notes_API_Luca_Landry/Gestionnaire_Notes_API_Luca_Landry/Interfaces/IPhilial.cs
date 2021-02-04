using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface IPhilial
    {
        createPhilialDTO AddPhilial(createPhilialDTO newPhilial);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        IList<PhilialModel> GetAll();
        IList<PhilialModel> GetAllByUser(int id);
        PhilialModel GetSingle(int id);
        PatchPhilialModel Update(int id, PatchPhilialModel model);
    }
}