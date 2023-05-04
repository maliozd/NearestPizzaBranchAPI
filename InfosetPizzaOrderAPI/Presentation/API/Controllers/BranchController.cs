using API.Controllers.Base;
using Application.Features.Queries;
using Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : BaseController
    {
        readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //BranchRequestParameters.WithinKilometers default value -> 10
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BranchRequestParameters branchesRequestParameters)
        {
            GetNearestBranchesQueryRequest request = new()
            {
                IPAddress = GetIpAddress(),
                WithinKilometers = branchesRequestParameters.WithinKilometers
            };
            GetNearestBranchesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
