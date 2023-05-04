using Application.Interfaces.Repository;
using Domain;
using Persistence.DataContext;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(InfosetDbContext dbContext) : base(dbContext)
        {
        }
    }
}
