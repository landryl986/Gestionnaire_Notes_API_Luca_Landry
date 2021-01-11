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
}