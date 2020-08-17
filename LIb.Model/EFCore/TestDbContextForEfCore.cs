using LIb.Model.BaseModel;
using Microsoft.EntityFrameworkCore;

namespace LIb.Model.EFCore
{
    public class TestDbContextForEfCore : DbContext
    {
        public TestDbContextForEfCore(DbContextOptions<TestDbContextForEfCore> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("User");
                
                b.HasKey(a => a.Id);
                
                b.Property(a => a.Name).HasColumnName("Name");
            });
        }
    }
}