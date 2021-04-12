  
using SCLFCrew.Domain;
using Microsoft.EntityFrameworkCore;

namespace SCLFCrew.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<AppUser> AppUsers { get; set; }
    }
}