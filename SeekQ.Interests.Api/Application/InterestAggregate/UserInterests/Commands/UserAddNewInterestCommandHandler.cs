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
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Visibility { get; set; }
            public Guid UserId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull().NotEmpty().WithMessage("The user interests Id is required");

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
                Guid id = request.Id;
                string name = request.Name;
                int visibility = request.Visibility;
                Guid uid = request.UserId;

                Interest existingInterest = _interestsDbContext.Interests.Find(id);

                if (existingInterest != null)
                {
                    UserInterest existingUserInterest = await _interestsDbContext.UserInterests.AsNoTracking().SingleOrDefaultAsync(u => u.IdInterest == id);

                    if (existingUserInterest != null)
                    {
                        throw new AppException($"The user adds an interest {id} has already been added");
                    }
                    else
                    {
                        UserInterest userInterest = new UserInterest
                        {
                            IdInterest = id,
                            Visibility = visibility,
                            IdUser = uid
                        };
                        _interestsDbContext.UserInterests.Add(userInterest);

                        int count = await _interestsDbContext.SaveChangesAsync();
                        if (count > 0)
                        {
                            existingInterest.PeopleCount = existingInterest.PeopleCount + 1;
                            _interestsDbContext.Interests.Update(existingInterest);

                            return count > 0;
                        }
                        else
                        {
                            throw new AppException($"The interest {id} already as not been updated");
                        }
                    }
                }
                else
                {
                    Interest Interest = new Interest
                    {
                        Name = name,
                        PeopleCount = 1,
                        Visibility = visibility
                    };

                    _interestsDbContext.Interests.Add(Interest);
                    int count = await _interestsDbContext.SaveChangesAsync();
                    if(count > 0)
                    {
                        UserInterest userInterest = new UserInterest
                        {
                            IdInterest = Interest.Id,
                            Visibility = visibility,
                            IdUser = uid
                        };
                        _interestsDbContext.UserInterests.Add(userInterest);

                        return await _interestsDbContext.SaveChangesAsync() > 0;
                    }

                    throw new AppException($"The user adds an interest {id} already as not been added");
                }
            }
        }
    }
}
