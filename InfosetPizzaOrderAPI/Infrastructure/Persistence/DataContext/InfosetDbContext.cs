using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence.DataContext
{
    public class InfosetDbContext : DbContext
    {
        public InfosetDbContext()
        {

        }
        public InfosetDbContext(DbContextOptions<InfosetDbContext> opt) : base(opt)
        {

        }
        public virtual DbSet<Branch> RestaurantBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
