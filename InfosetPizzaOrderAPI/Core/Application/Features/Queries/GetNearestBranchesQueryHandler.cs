using Application.Dtos.Branch;
using Application.Dtos.Location;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNearestBranchesQueryHandler : IRequestHandler<GetNearestBranchesQueryRequest, GetNearestBranchesQueryResponse>
    {
        readonly ILocationService _locationService;
        readonly IBranchService _branchService;
        public GetNearestBranchesQueryHandler(ILocationService locationService, IBranchService branchService)
        {
            _locationService = locationService;
            _branchService = branchService;
        }
        /*
         * Kullanıcının IP adresi ile http://api.ipstack.com e istek atarak lokasyon bilgisini elde ediyoruz.  
         * Gelen lokasyon bilgisini branchService nesnesine gerekli parametrelerle yollayarak en yakın şubeleri elde ediyoruz.
         */
        public async Task<GetNearestBranchesQueryResponse> Handle(GetNearestBranchesQueryRequest request, CancellationToken cancellationToken)
        {
            Location userLocation = await _locationService.GetLocationByIPAsync(request.IPAddress);
            List<NearBranchDTO> nearBranches = (await _branchService.GetNearBranches(userLocation, request.WithinKilometers, 5)).ToList();
            return new()
            {
                Branches = nearBranches
            };
        }
    }
}
