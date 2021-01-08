using System.ComponentModel.DataAnnotations;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class PhilialModel
    {
        [Required] 
        public int philialId { get; set; }

        [Required] 
        public string philialName { get; set; }

        [Required]
        public string userId { get; set; }
    }
}