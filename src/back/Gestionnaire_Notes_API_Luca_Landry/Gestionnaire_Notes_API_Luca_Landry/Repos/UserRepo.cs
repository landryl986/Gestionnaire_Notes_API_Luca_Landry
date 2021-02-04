using System;
using System.Collections.Generic;
using System.Linq;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Repos
{
    public class UserRepo : IUser
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }
        
        public UserModel AddUser(CreateUserDTO newUser)
        {
            try
            {
                var user = new UserModel();

                user.userName = newUser.UserName;
                user.admin = newUser.admin;
                user.userEmail = newUser.userEmail;
                user.userPassword = newUser.userPassword;
                user.userLastName = newUser.userLastName;

                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
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

        public UserModel GetByMail(string mail)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.userEmail == mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Login(string email, string pwd)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.userEmail == email);

                if (user != null)
                {
                    if (user.userPassword == pwd)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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