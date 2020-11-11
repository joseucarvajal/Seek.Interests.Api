using App.Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using SeekQ.Interests.Api.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Commands
{
    public class UserDeleteExistingInterestCommandHandler
    {
        public class Command : IRequest<bool>
        {
            public Guid Id { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull().NotEmpty().WithMessage("The user interests Id is required");
            }

            private object RuleFor(Func<object, object> p)
            {
                throw new NotImplementedException();
            }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private InterestsDbContext _interestsDbContext;

            public Handler(InterestsDbContext interestsDbContext)
            {
                _interestsDbContext = interestsDbContext;
            }

            public async Task<bool> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                Guid id = request.Id;

                UserInterest existingUserInterest = _interestsDbContext.UserInterests.Find(id);

                if (existingUserInterest != null)
                {
                    _interestsDbContext.UserInterests.Remove(existingUserInterest);
                    return await _interestsDbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new AppException($"The user interest {id} already as not been found");
                }
            }
        }
    }
}
