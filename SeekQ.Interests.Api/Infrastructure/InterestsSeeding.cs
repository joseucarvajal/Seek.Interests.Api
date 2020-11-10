using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using System;
using System.Threading.Tasks;


namespace SeekQ.Interests.Api.Infrastructure
{
    public class InterestsSeeding
    {
        public async Task SeedAsync(InterestsDbContext context, IServiceProvider services)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<InterestsSeeding>>();

            context.Database.EnsureCreated();

            if (await context.Interests.AnyAsync())
            {
                return;
            }

            // Animals
            context.Interests.Add(new Interest
            {
                Name = "Cat lover",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Dog lover",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Horses",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            // Misc
            context.Interests.Add(new Interest
            {
                Name = "Beach lover",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Coffee",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Concerts",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Craft beer",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Lakes",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Outdoors",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Parties",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Road trips",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Cars",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Vegetarian",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Wine",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Adventure",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Tattoos",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Hip Hop",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Rap",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Classic rock",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Country music",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Pop",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Foreign films",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Indie music",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "EDM",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            // Hobbies
            context.Interests.Add(new Interest
            {
                Name = "Art",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Beauty",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            // Psychological
            context.Interests.Add(new Interest
            {
                Name = "Adrenalin junkie",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Basic",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Free spirit",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Free thinker",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Intuitive",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Night owl",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Planner",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Thrill seeker",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            // Heavy
            context.Interests.Add(new Interest
            {
                Name = "Activism",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Politics",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            // BACKUP/MAYBE
            context.Interests.Add(new Interest
            {
                Name = "Surfing",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Cycling",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Environmentalism",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Crossfit",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Combat sports",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Alternative (music)",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Martial arts",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Vegan",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            await context.SaveChangesAsync();
        }
    }
}
