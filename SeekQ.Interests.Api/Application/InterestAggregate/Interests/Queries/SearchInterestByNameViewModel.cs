using System;
using System.Numerics;

namespace SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries
{
    public class SearchInterestByNameViewModel
    {
        public Guid InterestsId { get; set; }
        public string Name { get; set; }
        public BigInteger PeopleCount { get; set; }
    }
}
