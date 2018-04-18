using Microsoft.EntityFrameworkCore;

namespace Onus
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet <User> users { get;set; }
        public DbSet <Budget> budgetEntries { get;set; }
        public DbSet <Diet> dietEntries { get;set; }
        public DbSet <Exercise> exerciseEntries { get;set; }
        public DbSet <Meditation> meditationEntries { get;set; }
        public DbSet <Positivity> positivityEntries { get;set; }
        public DbSet <Sleep> sleepEntries { get;set; }
        public DbSet <Steps> stepsEntries { get;set; }
        public DbSet <Todo> todoEntries { get;set; }
        public DbSet <Water> waterEntries { get;set; }

    }
    
}