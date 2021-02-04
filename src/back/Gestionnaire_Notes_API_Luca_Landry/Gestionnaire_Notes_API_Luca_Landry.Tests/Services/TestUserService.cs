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
    public class TestUserService
    {
        private readonly IUserService _userService = new UserService(null);

        [TestMethod]
        public async Task AddUserNullTest()
        {
            CreateUserDTO response = null;

            Assert.ThrowsException<ArgumentNullException>(() => _userService.AddUser(response));
        }

        [TestMethod]
        public async Task DeleteUserNegTest()
        {
            int idNeg = -7;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _userService.Delete(idNeg));
        }
        
        [TestMethod]
        public async Task ExistByIdUserNegTest()
        {
            int idNeg = -7;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _userService.ExistsById(idNeg));
        }
        
        [TestMethod]
        public async Task GetSingleBrancheNegTest()
        {
            int idNeg = -7;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _userService.GetSingle(idNeg));
        }
        
        [TestMethod]
        public async Task UpdateBrancheNullTest()
        {
            int id = 1;
            PatchUserModel updateNeg = null;

            Assert.ThrowsExceptionAsync<DataNotFoundException>(() => _userService.UpdateAsync(id, updateNeg));
        }
        
        [TestMethod]
        public async Task UpdateBrancheNegTest()
        {
            int idNeg = -7;
            PatchUserModel updateNeg = new PatchUserModel();

            updateNeg.userName = "test";

            Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _userService.UpdateAsync(idNeg, updateNeg));
        }
    }
}