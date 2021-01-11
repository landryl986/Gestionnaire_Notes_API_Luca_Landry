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

    public class createPhilialDTO
    {
        public int Id { get; set; }
        public string philialName { get; set; }
        
        public int userID { get; set; }
    }
}