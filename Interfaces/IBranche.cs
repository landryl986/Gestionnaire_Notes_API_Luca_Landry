using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface IBranche
    {
        BrancheModel AddUser(BrancheModel newUser);
        void Delete(int id);
        IList<BrancheModel> GetAll();
        BrancheModel GetSingle(int id);
        BrancheModel Update(int id, BrancheModel model);
    }
}