using System.Collections.Generic;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Interfaces
{
    public interface IUser
    {
        UserModel AddUser(CreateUserDTO newUser);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string name);
        IList<UserModel> GetAll();
        UserModel GetSingle(int id);
        UserModel GetByMail(string mail);
        bool Login(string email, string pwd);
        PatchUserModel Update(int id, PatchUserModel model);
        void SetAvatar(int Id, byte[] image);
        byte[] GetAvatar(int id);
    }
}