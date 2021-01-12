using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface IBranche
    {
        createBrancheDTO AddBranche(createBrancheDTO newBranche);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        IList<BrancheModel> GetAll();
        BrancheModel GetSingle(int id);
        PatchBrancheModel Update(int id, PatchBrancheModel model);
    }
}