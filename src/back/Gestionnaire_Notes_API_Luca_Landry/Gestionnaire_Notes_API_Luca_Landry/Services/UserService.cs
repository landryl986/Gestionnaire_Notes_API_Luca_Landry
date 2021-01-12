using System;
using System.Collections.Generic;
using System.Linq;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class UserService : IUser
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        
        public UserModel AddUser(UserModel newUser)
        {
            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Users.Remove(_context.Users.FirstOrDefault(u => u.Id == id));
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return _context.Users.Any(u => u.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool ExistsByName(string name)
        {
            try
            {
                return _context.Users.Any(u => u.userName.Contains(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<UserModel> GetAll()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public UserModel GetSingle(int id)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public PatchUserModel Update(int id, PatchUserModel model)
        {
            try
            {

                var user = _context.Users.FirstOrDefault(u => u.Id == id);
            
                user.userName = model.userName;
                user.userLastName = model.userLastName;
                user.userEmail = model.userEmail;
                user.userPassword = model.userPassword;
                user.admin = model.admin;

                _context.SaveChanges();

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetAvatar(int Id, byte[] image)
        {
            try
            {
                var user = _context.Users.Single(u=>u.Id == Id);
                user.Avatar = image;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public byte[] GetAvatar(int id)
        {
            try
            {
                return _context.Users.Find(id).Avatar;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}