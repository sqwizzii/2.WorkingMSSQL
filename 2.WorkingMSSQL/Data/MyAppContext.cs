using _2.WorkingMSSQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2.WorkingMSSQL.Data
{
    public class MyAppContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=slonyk;Integrated Security=True; TrustServerCertificate=True; ");
        }
    }
}