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
    public class UserAddNewInterestCommandHandler
    {
        public class Command : IRequest<bool>
        {
            public string Name { get; set; }
            public int Visibility { get; set; }
            public Guid UserId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Visibility)
                    .NotNull().NotEmpty().WithMessage("The user interests Visibility is required");

                RuleFor(x => x.UserId)
                    .NotNull().NotEmpty().WithMessage("The user Id is required");

                RuleFor(x => x.Name)
                    .NotNull().NotEmpty().WithMessage("The interest Name is required");
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
                string name = request.Name;
                int visibility = request.Visibility;
                Guid userId = request.UserId;

                Interest existingInterest = await _interestsDbContext.Interests.AsNoTracking().SingleOrDefaultAsync(i => i.Name == name);

                if (existingInterest != null)
                {
                    throw new AppException($"The interest {name} has already been added");
                }
                else
                {
                    Guid interestId = Guid.NewGuid();
                    Interest Interest = new Interest
                    {
                        Id = interestId,
                        Name = name,
                        PeopleCount = 1,
                        Visibility = visibility
                    };
                    _interestsDbContext.Interests.Add(Interest);

                    UserInterest userInterest = new UserInterest
                    {
                        IdInterest = interestId,
                        Visibility = visibility,
                        IdUser = userId
                    };
                    _interestsDbContext.UserInterests.Add(userInterest);

                    return await _interestsDbContext.SaveChangesAsync() > 0;
                }
            }
        }
    }
}
