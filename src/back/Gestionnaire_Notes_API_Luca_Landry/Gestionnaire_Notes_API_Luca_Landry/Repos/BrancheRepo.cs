using System;
using System.Collections.Generic;
using System.Linq;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Repos
{
    public class BrancheRepo : IBranche
    {
        private readonly DataContext _context;

        public BrancheRepo(DataContext context)
        {
            _context = context;
        }
        public createBrancheDTO AddBranche(createBrancheDTO newBranche)
        {
            try
            {
                var branche = new BrancheModel();

                branche.brancheName = newBranche.brancheName;
                branche.philialId = newBranche.philialId;
                branche.barem = newBranche.barem;
                
                _context.Branches.Add(branche);
                _context.SaveChanges();
                return newBranche;
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
                _context.Branches.Remove(_context.Branches.FirstOrDefault(b => b.Id == id));
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
                return _context.Branches.Any(b => b.Id == id);
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
                return _context.Branches.Any(b => b.brancheName.Contains(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<BrancheModel> GetAll()
        {
            try
            {
                return _context.Branches.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public BrancheModel GetSingle(int id)
        {
            try
            {
                return _context.Branches.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public PatchBrancheModel Update(int id, PatchBrancheModel model)
        {
            try
            {
                var branche = _context.Branches.FirstOrDefault(b => b.Id == id);

                branche.brancheName = model.brancheName;
                branche.barem = model.barem;
                branche.philialId = model.philialId;

                _context.SaveChanges();

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}