using Microsoft.EntityFrameworkCore;

namespace cp2___.net.Models.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    

    }
}
