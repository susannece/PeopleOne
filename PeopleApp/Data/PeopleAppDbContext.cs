using Microsoft.EntityFrameworkCore;
using PeopleApp.Models;

namespace PeopleApp.Data
{
    public class PeopleAppDbContext : DbContext
    {
        public PeopleAppDbContext(DbContextOptions<PeopleAppDbContext> options) : base(options)
        { }

        public DbSet<Person> Person  { get; set; }

        public DbSet<City> City { get; set; }
    }
}
