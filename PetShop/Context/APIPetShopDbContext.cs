using Microsoft.EntityFrameworkCore;
using PetShop.Model;

namespace PetShop.Context
{

    public class APIPetShopDbContext : DbContext
    {
        public APIPetShopDbContext(DbContextOptions<APIPetShopDbContext>options) : base(options)
        { 
        }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}

