using EntityDemo.Types;
using Microsoft.EntityFrameworkCore;

namespace EntityDemo.Data
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source=localhost\SQLExpress;Initial Catalog=EntityDemo;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
