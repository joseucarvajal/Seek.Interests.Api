using App.Common.Repository;
using System;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class UserInterest : BaseEntity
    {
        public Guid IdUser { get; set; }
        public Guid IdInterest { get; set; }
        public Interest Interests { get; set; }
        public int Visibility { get; set; }

        public UserInterest() { }

        public UserInterest(Guid id, Guid idUser, Guid idInterest, int visibility)
        {
            Id = id;
            IdUser = idUser;
            IdInterest = idInterest;
            Visibility = visibility;
        }
    }
}
