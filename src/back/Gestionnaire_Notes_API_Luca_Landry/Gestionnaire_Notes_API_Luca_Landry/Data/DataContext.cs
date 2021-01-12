using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestionnaire_Notes_API_Luca_Landry.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PhilialModel> Philials { get; set; }
        public DbSet<BrancheModel> Branches { get; set; }
        public DbSet<NoteModel> Notes { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
        {
    
        }
    }
}