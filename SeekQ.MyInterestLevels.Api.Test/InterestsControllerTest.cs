using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SeekQ.Interests.Api;
using SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries;
using SeekQ.Interests.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SeekQ.MyInterestLevels.Api.Test
{
    public class InterestsControllerTest : BaseIntegrationTest<Startup>
    {
        public InterestsControllerTest(WebApplicationFactory<Startup> factory)
            : base(factory)
        {

        }

        [Theory]
        [InlineData("/api/v1/Interests/defaultinterests")]
        public async void GetDefaultInterest_getExpectedDefaultInterests(string url)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var defaultInterestsList = JsonConvert
                               .DeserializeObject<GetDefaultInterestsViewModel>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(defaultInterestsList.DefaultPublicInterests.Count() == 65, "Default public interest list where not loaded");
            Assert.True(defaultInterestsList.DefaultPrivateInterests.Count() == 17, "Default private Interest list where not loaded");
        }

        [Theory]
        [InlineData("/api/v1/Interests/searchinterest")]
        public async void SearchInterestByName_getExpectedInterest(string url)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{url}/Beauty");

            // Assert
            response.EnsureSuccessStatusCode();
            var interest = JsonConvert
                               .DeserializeObject<IEnumerable<SearchInterestByNameViewModel>>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(interest.Count() == 1, "The interest where not loaded");
        }
    }
}
