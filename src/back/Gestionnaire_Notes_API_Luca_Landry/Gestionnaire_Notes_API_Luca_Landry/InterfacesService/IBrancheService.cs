using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.InterfacesService
{
    public interface IBrancheService
    {
        createBrancheDTO AddBranche(createBrancheDTO newBranche);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        Task<IList<BrancheModel>> GetAll();
        BrancheModel GetSingle(int id);
        Task<PatchBrancheModel> Update(int id, PatchBrancheModel model);
    }
}