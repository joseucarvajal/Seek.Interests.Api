using App.Common.Repository;
using System.Numerics;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class Interest : BaseEntity
    {
        public string Name { get; set; }
        public BigInteger PeopleCount { get; set; }
        public int Visibility { get; set; }

        public Interest() { }
    }
}
