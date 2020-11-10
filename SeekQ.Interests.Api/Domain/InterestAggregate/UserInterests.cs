using App.Common.Repository;
using System;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class UserInterests : BaseEntity
    {
        public Guid IdUser { get; set; }
        public Guid IdInterest { get; set; }
        public int Visibility { get; set; }

        public UserInterests() { }
    }
}
