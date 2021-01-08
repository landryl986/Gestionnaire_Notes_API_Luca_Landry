using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gestionnaire_Notes_API_Luca_Landry.Enums;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class BrancheModel
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        public string brancheName { get; set; }

        [Required] 
        public Barems barem { get; set; }

        [Required] 
        public PhilialModel Philial { get; set; }
    }
}