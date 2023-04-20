using Microsoft.EntityFrameworkCore;

namespace TOTVS_Challenge.Models
{
    public class TOTVSDbContext: DbContext
    {
        public TOTVSDbContext(DbContextOptions<TOTVSDbContext> options) : base(options)
        {}  

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
