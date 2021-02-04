using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.InterfacesService
{
    public interface IPhilialService
    {
        createPhilialDTO AddPhilial(createPhilialDTO newPhilial);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        Task<IList<PhilialModel>> GetAll();
        IList<PhilialModel> GetAllByUser(int id);
        PhilialModel GetSingle(int id);
        Task<PatchPhilialModel> Update(int id, PatchPhilialModel model);
    }
}