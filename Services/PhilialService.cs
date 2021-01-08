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
        
        public PhilialModel AddPhilial(PhilialModel newPhilial)
        {
            try
            {
                _context.Philials.Add(newPhilial);
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
            throw new System.NotImplementedException();
        }

        public IList<PhilialModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PhilialModel GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public PhilialModel Update(int id, PhilialModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}