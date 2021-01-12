using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class PhilialModel
    {
        public int Id { get; set; }

        [Required] 
        public string philialName { get; set; }

        [Required]
        public UserModel User { get; set; }

        public int userId { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de la création d'une nouvelle Philial
    /// </summary>
    public class createPhilialDTO
    {
        /// <summary>
        /// ne pas entrer d'ID au moement de la création car celui-si est Auto increment
        /// </summary>
        public int Id { get; set; }
        public string philialName { get; set; }
        public int userID { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de l'update d'une philial
    /// </summary>
    public class PatchPhilialModel
    {
        public string philialName { get; set; }
        
        public int userID { get; set; }
    }
}