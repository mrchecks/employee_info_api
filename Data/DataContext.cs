using EmployeeInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}
