using SeekQ.Interests.Api.Domain.InterestAggregate;
using System.Collections.Generic;

namespace SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries
{
    public class GetDefaultInterestsViewModel
    {
        public IEnumerable<Interest> DefaultPublicInterests { get; set; }
        public IEnumerable<Interest> DefaultPrivateInterests { get; set; }
    }
}
