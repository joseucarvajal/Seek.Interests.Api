using App.Common.Repository;
using Org.BouncyCastle.Math;
using System;
using System.Numerics;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class Interest : BaseEntity
    {
        public string Name { get; set; }
        public int PeopleCount { get; set; }
        public int Visibility { get; set; }

        public Interest() { }

        public Interest(Guid id, string name, int peopleCount, int visibility)
        {
            Id = id;
            Name = name;
            PeopleCount = peopleCount;
            Visibility = visibility;
        }
    }
}
