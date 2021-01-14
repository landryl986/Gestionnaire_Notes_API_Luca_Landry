using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.InterfacesService
{
    public interface IUserService
    {
        UserModel AddUser(UserModel newUser);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        Task<IList<UserModel>> GetAll();
        UserModel GetSingle(int id);
        Task<PatchUserModel> UpdateAsync(int id, PatchUserModel model);
        void SetAvatar(int Id, byte[] image);
        Task<byte[]> GetAvatar(int id);
        
    }
}