using Mc2.CrudTest.Storage.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Storage.Database.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<CustomerEntity> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerEntity>(mb =>
            {
                mb.HasKey(dr => dr.Id);
                mb.HasIndex(dr => dr.Email).IsUnique();
                mb.HasIndex(dr => new { dr.FirstName, dr.LastName, dr.DateOfBirth }).IsUnique();
                mb.Property(dr => dr.PhoneNumber).HasMaxLength(32).HasColumnType("varchar(32)");
            });
        }
    }
}
