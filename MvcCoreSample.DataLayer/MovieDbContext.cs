using Microsoft.EntityFrameworkCore;
using MvcCoreSample.DomainClasses;

namespace MvcCoreSample.DataLayer
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Movie> Movies { get; set; }
    }
}