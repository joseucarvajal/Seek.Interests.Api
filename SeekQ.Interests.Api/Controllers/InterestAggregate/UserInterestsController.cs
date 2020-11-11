using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Commands;
using SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SeekQ.Interests.Api.Controllers.InterestAggregate
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserInterestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserInterestsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("userinterests/{idUser}")]
        [SwaggerOperation(Summary = "Get user interest by user")]
        public async Task<GetUserInterestsViewModel> GetUserInterestsByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetUserInterestsQueryHandler.Query(idUser));
        }

        [HttpPost]
        [Route("addexistinginterest")]
        [SwaggerOperation(Summary = "Add User existing interest: and user adds an interest")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Interest added and user adds an interest succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> AddExistingInterest(
            [FromBody]UserAddExistingInterestCommandHandler.Command userAddExistingInterestParams
        )
        {
            return await _mediator.Send(userAddExistingInterestParams);
        }

        [HttpPost]
        [Route("addnewinterest")]
        [SwaggerOperation(Summary = "Add User new interest: and user adds a new interest")]
        [SwaggerResponse((int)HttpStatusCode.OK, "New Interest added and user adds a new interest succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> AddNewInterest(
            [FromBody]UserAddNewInterestCommandHandler.Command userAddNewInterestParams
        )
        {
            return await _mediator.Send(userAddNewInterestParams);
        }

        [HttpDelete]
        [Route("deleteexistinginterest/{userInterestId}")]
        [SwaggerOperation(Summary = "Delete User existing interest: and user decrease an interest")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Interest deleted and user decrease an interest succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> DeleteExistingInterest(
            [FromRoute] Guid userInterestId
        )
        {
            return await _mediator.Send(new UserDeleteExistingInterestCommandHandler.Command(userInterestId));
        }
    }
}
