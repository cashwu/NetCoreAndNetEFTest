using System.Data.Entity;
using LIb.Model.BaseModel;

namespace LIb.Model.EF
{
    public class TestDbContextForEf : DbContext
    {
        public TestDbContextForEf(string connectionString)
            : base(connectionString)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .ToTable("User")
                        .HasKey(a => a.Id)
                        .Property(a => a.Name)
                        .HasColumnName("Name");
        }
    }
}