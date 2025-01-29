using System.Collections.Generic;
using CityMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace CityMaster.Data
{
    public class CityMasterDbContext : DbContext
    {
        public CityMasterDbContext(DbContextOptions<CityMasterDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
    }
}
