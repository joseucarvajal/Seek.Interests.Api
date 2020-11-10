using App.Common.Repository;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class BlackList : BaseEntity
    {
        public string Name { get; set; }

        public BlackList() { }
    }
}
