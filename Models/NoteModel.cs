using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        
        [Required]
        public int note { get; set; }
        
        [Required]
        public BrancheModel Branche { get; set; }

        public int BrancheId { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de la création d'une nouvelle note
    /// </summary>
    public class createNoteDTO
    {
        /// <summary>
        /// ne pas entrer d'ID au moement de la création car celui-si est Auto increment
        /// </summary>
        public int Id { get; set; }
        
        [Required]
        public int note { get; set; }
        
        [Required]
        public int BrancheId { get; set; }
    }

    /// <summary>
    /// Cette classe est utilisée au moment de l'update d'une philial
    /// </summary>
    public class PatchNoteModel
    {
        public int note { get; set; }
        
        public int BrancheId { get; set; }
    }
}