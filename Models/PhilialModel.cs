using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class PhilialModel
    {
        public int Id { get; set; }

        [Required] 
        public string philialName { get; set; }

        [Required]
        public UserModel User { get; set; }
    }
}