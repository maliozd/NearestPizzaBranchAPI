using MediatR;

namespace Application.Features.Queries
{
    public class GetNearestBranchesQueryRequest : IRequest<GetNearestBranchesQueryResponse>
    {
        public double WithinKilometers { get; set; }
        public string IPAddress { get; set; }
    }
}