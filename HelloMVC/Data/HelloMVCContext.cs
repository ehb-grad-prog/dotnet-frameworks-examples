using HelloMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Data;

public class HelloMVCContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=(local);Initial Catalog=HelloMVC;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .ToTable("People", "Information")
            .Property(person => person.Name)
            .HasMaxLength(100);
    }
}
