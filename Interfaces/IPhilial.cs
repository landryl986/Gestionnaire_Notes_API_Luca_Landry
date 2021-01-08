using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface IPhilial
    {
        PhilialModel AddUser(UserModel newUser);
        void Delete(int id);
        IList<PhilialModel> GetAll();
        PhilialModel GetSingle(int id);
        PhilialModel Update(int id, PhilialModel model);
    }
}