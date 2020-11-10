using App.Common.SeedWork;

namespace SeekQ.Interests.Api.Domain.InterestAggregate
{
    public class Level : Enumeration
    {
        public static Level Public = new Level(0, "Public");
        public static Level Private = new Level(1, "Private");

        public Level(int id, string name)
                   : base(id, name)
        {
        }
    }
}
