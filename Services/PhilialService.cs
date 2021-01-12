using System;
using System.Collections.Generic;
using System.Linq;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class PhilialService : IPhilial
    {
        private readonly DataContext _context;

        public PhilialService(DataContext context)
        {
            _context = context;
        }
        
        public createPhilialDTO AddPhilial(createPhilialDTO newPhilial)
        {
            try
            {
                var philial = new PhilialModel();

                philial.philialName = newPhilial.philialName;
                philial.userId = newPhilial.userID;

                _context.Philials.Add(philial);
                _context.SaveChanges();
                return newPhilial;
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
                _context.Philials.Remove(_context.Philials.FirstOrDefault(p => p.Id == id));
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
                return _context.Philials.Any(p => p.Id == id);
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
                return _context.Philials.Any(p => p.philialName.Contains(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<PhilialModel> GetAll()
        {
            try
            {
                return _context.Philials.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public PhilialModel GetSingle(int id)
        {
            try
            {
                return _context.Philials.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public PhilialModel Update(int id, PhilialModel model)
        {
            try
            {
                var philial = _context.Philials.FirstOrDefault(p => p.Id == id);

                philial.philialName = model.philialName;
                philial.User = model.User;

                _context.SaveChanges();

                return philial;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}