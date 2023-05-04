using Application.Dtos.Branch;

namespace Application.Features.Queries
{
    public class GetNearestBranchesQueryResponse
    {
        public ICollection<NearBranchDTO> Branches { get; set; }
    }
}
