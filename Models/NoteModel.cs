using System.ComponentModel.DataAnnotations;

namespace Gestionnaire_Notes_API_Luca_Landry.Models
{
    public class NoteModel
    {
        [Required]
        public int noteId { get; set; }

        [Required]
        public int brancheId { get; set; }
    }
}