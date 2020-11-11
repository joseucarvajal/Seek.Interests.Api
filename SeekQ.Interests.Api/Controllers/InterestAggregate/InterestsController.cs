using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace SeekQ.Interests.Api.Controllers.InterestAggregate
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InterestsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("defaultinterests")]
        [SwaggerOperation(Summary = "Get default interests")]
        public async Task<GetDefaultInterestsViewModel> GetDefaultInterests()
        {
            return await _mediator.Send(new GetDefaultInterestsQueryHandler.Query());
        }

        [HttpGet]
        [Route("searchinterest/{interestName}")]
        [SwaggerOperation(Summary = "Search interest by name")]
        public async Task<IEnumerable<SearchInterestByNameViewModel>> SearchInterestByName(
            [FromRoute] string interestName
        )
        {
            return await _mediator.Send(new SearchInterestByNameQueryHandler.Query(interestName));
        }
    }
}
