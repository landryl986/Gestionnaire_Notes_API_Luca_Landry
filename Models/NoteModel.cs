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

    public class createNoteDTO
    {
        public int Id { get; set; }
        
        public int note { get; set; }
        
        public int BrancheId { get; set; }
    }
}