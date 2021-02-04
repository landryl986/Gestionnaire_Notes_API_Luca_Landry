using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Exceptions;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _repo;

        public UserService(IUser repo)
        {
            _repo = repo;
        }
        public UserModel AddUser(CreateUserDTO newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));
            
            if (_repo.ExistsByName(newUser.UserName))
                throw new ArgumentException(nameof(newUser.UserName), $"User {newUser.UserName} already exists.");
            
            var user = _repo.AddUser(newUser);

            return user;
        }

        public void Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"User Id:{id} doesn't exists.");
            
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
            return _repo.ExistsByName(name);
        }

        public async Task<IList<UserModel>> GetAll()
        {
            return _repo.GetAll();
        }

        public UserModel GetSingle(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"User Id:{id} doesn't exists.");
            
            return _repo.GetSingle(id);
        }

        public bool Login(string email, string pwd)
        {
            return _repo.Login(email, pwd);
        }

        public UserModel GetByMail(string mail)
        {
            return _repo.GetByMail(mail);
        }

        public async Task<PatchUserModel> UpdateAsync(int id, PatchUserModel model)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"User Id:{id} doesn't exists.");
            
            return _repo.Update(id, model);
        }

        public void SetAvatar(int Id, byte[] image)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id), Id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(Id))
                throw new DataNotFoundException($"User Id:{Id} doesn't exists.");
            
            _repo.SetAvatar(Id, image);
        }

        public async Task<byte[]> GetAvatar(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");
            
            if (!_repo.ExistsById(id))
                throw new DataNotFoundException($"User Id:{id} doesn't exists.");
            
            return _repo.GetAvatar(id);
        }
    }
}