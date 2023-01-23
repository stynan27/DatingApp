using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  // : DbContext -> to make DataContext "derived" from DbContext implementation
  // Describes a class inheritted from another class.
  public class DataContext : DbContext
  {
    // constructor, options to specify a connection string.
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    // Creates a DB Table named Users
    public DbSet<AppUser> Users { get; set; }
  }
}