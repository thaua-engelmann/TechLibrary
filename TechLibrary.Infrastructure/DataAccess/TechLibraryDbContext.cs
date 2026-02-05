using Microsoft.EntityFrameworkCore;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Infrastructure.DataAccess;
public class TechLibraryDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
