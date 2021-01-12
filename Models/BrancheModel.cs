using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gestionnaire_Notes_API_Luca_Landry.Enums;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class BrancheModel
    {
        public int Id { get; set; }

        [Required] 
        public string brancheName { get; set; }

        [Required] 
        public Barems barem { get; set; }

        [Required] 
        public PhilialModel Philial { get; set; }

        public int philialId { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de la création d'une nouvelle branche
    /// </summary>
    public class createBrancheDTO
    {
        /// <summary>
        /// ne pas entrer d'ID au moement de la création car celui-si est Auto increment
        /// </summary>
        public int Id { get; set; }
        
        [Required]
        public string brancheName { get; set; }
        
        public Barems barem { get; set; }
        
        [Required]
        public int philialId { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de l'update d'une branche
    /// </summary>
    public class PatchBrancheModel
    {
        public string brancheName { get; set; }
        
        public Barems barem { get; set; }
        
        public int philialId { get; set; }
    }
}