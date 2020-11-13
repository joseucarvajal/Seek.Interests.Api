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
        // Statics IDs for users
        public Guid ID_USER_JOSE = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D7");
        public Guid ID_USER_DANIEL = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D9");
        public Guid ID_USER_JORGE = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D8");
        public Guid ID_USER_LLIUR = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D7");
        public Guid ID_USER_JULIAN = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D6");
        public Guid ID_USER_CARLOS = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D5");
        public Guid ID_USER_ANDRES = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D4");
        public Guid ID_USER_DAVID = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D3");

        // Statics IDs for interests
        public Guid ID_INTEREST_CAT_LOVER = Guid.NewGuid();
        public Guid ID_INTEREST_DOG_LOVER = Guid.NewGuid(); // new Guid("9540c6ed-835d-4907-9678-9a0a94e7a8b9");
        public Guid ID_INTEREST_HORSES = Guid.NewGuid();
        public Guid ID_INTEREST_BEACH_LOVER = Guid.NewGuid();
        public Guid ID_INTEREST_COFFEE = Guid.NewGuid();
        public Guid ID_INTEREST_CONCERTS = Guid.NewGuid();
        public Guid ID_INTEREST_CRAFT_BEER = Guid.NewGuid();
        public Guid ID_INTEREST_LAKES = Guid.NewGuid();
        public Guid ID_INTEREST_OUTDOORS = Guid.NewGuid();
        public Guid ID_INTEREST_PARTIES = Guid.NewGuid();
        public Guid ID_INTEREST_ROAD_TRIPS = Guid.NewGuid();
        public Guid ID_INTEREST_CARS = Guid.NewGuid();
        public Guid ID_INTEREST_VEGETARIAN = Guid.NewGuid();
        public Guid ID_INTEREST_WINE = Guid.NewGuid();
        public Guid ID_INTEREST_ADVENTURE = Guid.NewGuid();
        public Guid ID_INTEREST_TATTOOS = Guid.NewGuid();
        public Guid ID_INTEREST_HIP_HOP = Guid.NewGuid();
        public Guid ID_INTEREST_RAP = Guid.NewGuid();
        public Guid ID_INTEREST_CLASSIC_ROCK = Guid.NewGuid();
        public Guid ID_INTEREST_COUNTRY_MUSIC = Guid.NewGuid();
        public Guid ID_INTEREST_POP = new Guid("8AFB19CA-40AF-478A-97AC-7E4A4569DE66");
        public Guid ID_INTEREST_FOREIGN_FILMS = Guid.NewGuid();
        public Guid ID_INTEREST_INDIE_MUSIC = Guid.NewGuid();
        public Guid ID_INTEREST_EDM = Guid.NewGuid();

        // Statics IDs for user interests
        public Guid ID_USER_INTEREST_TEST = Guid.NewGuid();

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
                Id = ID_INTEREST_CAT_LOVER,
                Name = "Cat lover",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_DOG_LOVER,
                Name = "Dog lover",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_HORSES,
                Name = "Horses",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });

            // Misc
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_BEACH_LOVER,
                Name = "Beach lover",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_COFFEE,
                Name = "Coffee",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_CONCERTS,
                Name = "Concerts",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_CRAFT_BEER,
                Name = "Craft beer",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_LAKES,
                Name = "Lakes",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_OUTDOORS,
                Name = "Outdoors",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_PARTIES,
                Name = "Parties",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_ROAD_TRIPS,
                Name = "Road trips",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_CARS,
                Name = "Cars",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_VEGETARIAN,
                Name = "Vegetarian",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_WINE,
                Name = "Wine",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_ADVENTURE,
                Name = "Adventure",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_TATTOOS,
                Name = "Tattoos",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_HIP_HOP,
                Name = "Hip Hop",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_RAP,
                Name = "Rap",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_CLASSIC_ROCK,
                Name = "Classic rock",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_COUNTRY_MUSIC,
                Name = "Country music",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_POP,
                Name = "Pop",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Id = ID_INTEREST_FOREIGN_FILMS,
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
            context.Interests.Add(new Interest
            {
                Name = "Binge watching",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Blog/Vlog",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Board games",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Content creation",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Cosplay",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Dancing",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Fantasy sports",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Fashion",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Festivals",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Fishing",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Foodie",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Football",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Health & Fitness",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Gaming",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Languages",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Meditation",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Movies",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Music",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Photography",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Podcasts",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Running",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Shopping",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Stay in and chill",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Tailgating",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Travel",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Working out",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Writing",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Yoga",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Hiking",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Baseball",
                PeopleCount = 0,
                Visibility = Level.Public.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Basketball",
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
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Politics",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Religion",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "STEM",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Logic",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Change the world",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Spiritual",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Spontaneous",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Volunteering",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });

            // BACKUP/MAYBE
            context.Interests.Add(new Interest
            {
                Name = "Surfing",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Cycling",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Environmentalism",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Crossfit",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Combat sports",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Alternative (music)",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Martial arts",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });
            context.Interests.Add(new Interest
            {
                Name = "Vegan",
                PeopleCount = 0,
                Visibility = Level.Private.Id
            });

            // Black list
            context.BlackLists.Add(new BlackList
            {
                Name = "F*ck"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "F*ck you"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Shit"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Piss off"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Dick head"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Asshole"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Son of a b*tch"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Bastard"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Bitch"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Damn"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "C*nt"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Bollocks"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Bugger"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Choad"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Crikey"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Rubbish"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Shag"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Wanker"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Taking the piss"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Twat"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Bloody Oath"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Root"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Get Stuffed"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Bugger me"
            });
            context.BlackLists.Add(new BlackList
            {
                Name = "Fair suck of the sav"
            });

            // **************************************************** User Interests ****************************************************
            // Public Interests
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_CAT_LOVER,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_DOG_LOVER,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_HORSES,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_BEACH_LOVER,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_COFFEE,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_CONCERTS,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_CRAFT_BEER,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_LAKES,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_OUTDOORS,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_PARTIES,
                Visibility = Level.Public.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_ROAD_TRIPS,
                Visibility = Level.Public.Id
            });

            // Private Interests
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_CARS,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_VEGETARIAN,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_WINE,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_ADVENTURE,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_TATTOOS,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_HIP_HOP,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_RAP,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_CLASSIC_ROCK,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                IdUser = ID_USER_JOSE,
                IdInterest = ID_INTEREST_COUNTRY_MUSIC,
                Visibility = Level.Private.Id
            });
            context.UserInterests.Add(new UserInterest
            {
                Id = ID_USER_INTEREST_TEST,
                IdUser = ID_USER_DANIEL,
                IdInterest = ID_INTEREST_POP,
                Visibility = Level.Private.Id
            });

            await context.SaveChangesAsync();
        }
    }
}
