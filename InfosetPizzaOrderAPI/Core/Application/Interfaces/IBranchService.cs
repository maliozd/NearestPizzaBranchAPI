using Application.Dtos.Branch;
using Application.Dtos.Location;

namespace Application.Interfaces
{
    public interface IBranchService
    {
        ICollection<BranchDTO> GetAllBranches();
        Task<ICollection<NearBranchDTO>> GetNearBranches(Location userLocation, double kilometersAway, int takeSize);
    }
}
