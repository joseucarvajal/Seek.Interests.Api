using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Commands
{
    public class UserAddNewInterestParams
    {
        public string Name { get; set; }
        public int Visibility { get; set; }
        public Guid UserId { get; set; }
    }
}
