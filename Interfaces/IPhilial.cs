using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface IPhilial
    {
        PhilialModel AddPhilial(PhilialModel newPhilial);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        IList<PhilialModel> GetAll();
        PhilialModel GetSingle(int id);
        PhilialModel Update(int id, PhilialModel model);
    }
}