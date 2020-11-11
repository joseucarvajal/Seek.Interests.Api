using System;

namespace SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Commands
{
    public class UserAddExistingInterestParams
    {
        public Guid Id { get; set; }
        public int Visibility { get; set; }
        public Guid UserId { get; set; }
    }
}
