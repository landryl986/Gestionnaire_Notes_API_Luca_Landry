using System.ComponentModel.DataAnnotations;
using Gestionnaire_Notes_API_Luca_Landry.Enums;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class BrancheModel
    {
        [Required]
        public int brancheId { get; set; }

        [Required] 
        public string brancheName { get; set; }

        [Required] 
        public Barems barem { get; set; }

        [Required] 
        public int philialId { get; set; }
    }
}