using Microsoft.EntityFrameworkCore;
using TestTaskDinamika.Wpf.Models;

namespace TestTaskDinamika.Wpf.Data;
public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Company> Companies { get; set; }
    public AppDbContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Dinamika;Integrated Security=true");
    }
}
