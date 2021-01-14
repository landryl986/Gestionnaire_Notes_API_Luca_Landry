using System;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.Exceptions;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Gestionnaire_Notes_API_Luca_Landry.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gestionnaire_Notes_API_Luca_Landry.Tests
{
    [TestClass]
    public class TestBrancheService
    {
        private readonly IBrancheService _brancheService = new BrancheService(null);

        [TestMethod]
        public async Task AddBrancheTest()
        {
            createBrancheDTO response = null;

            Assert.ThrowsException<ArgumentNullException>(() => _brancheService.AddBranche(response));
        }

        [TestMethod]
        public async Task DeleteBrancheNegTest()
        {
            int idNeg = -7;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _brancheService.Delete(idNeg));
        }
        
        [TestMethod]
        public async Task ExistByIdBrancheNegTest()
        {
            int idNeg = -7;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _brancheService.ExistsById(idNeg));
        }
        
        [TestMethod]
        public async Task GetSingleBrancheNegTest()
        {
            int idNeg = -7;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _brancheService.GetSingle(idNeg));
        }
        
        [TestMethod]
        public async Task UpdateBrancheNullTest()
        {
            int id = 1;
            PatchBrancheModel updateNeg = null;

            Assert.ThrowsExceptionAsync<DataNotFoundException>(() => _brancheService.Update(id, updateNeg));
        }
        
        [TestMethod]
        public async Task UpdateBrancheNegTest()
        {
            int idNeg = -7;
            PatchBrancheModel updateNeg = new PatchBrancheModel();

            updateNeg.brancheName = "test";

            Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _brancheService.Update(idNeg, updateNeg));
        }
    }
}