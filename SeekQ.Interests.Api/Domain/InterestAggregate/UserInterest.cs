using App.Common.Repository;
using System;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class UserInterest : BaseEntity
    {
        public Guid IdUser { get; set; }
        public Guid IdInterest { get; set; }
        public Interest Interest { get; set; }
        public int Visibility { get; set; }

        public UserInterest() { }
    }
}
