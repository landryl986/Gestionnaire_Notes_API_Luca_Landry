using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class UserModel
    {
        
        public int Id { get; set; }
        
        [Required]
        public string userName { get; set; }
        
        [Required]
        public string userLastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string userEmail { get; set; }

        [Required]
        public string userPassword { get; set; }
        
        public byte[] Avatar { get; set; }
        
        public bool admin { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de l'update d'un user
    /// </summary>
    public class PatchUserModel
    {

        public string userName { get; set; }
        
        public string userLastName { get; set; }
        
        [EmailAddress]
        public string userEmail { get; set; }
        
        public string userPassword { get; set; }
        
        public bool admin { get; set; }
    }

    public class CreateUserDTO
    {
        public string UserName { get; set; }
        
        public string userLastName { get; set; }
        
        [EmailAddress]
        public string userEmail { get; set; }
        
        public string userPassword { get; set; }
        
        public bool admin { get; set; }
    }
}