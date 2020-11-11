using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SeekQ.Interests.Api;
using SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries;
using SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Commands;
using SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Queries;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using SeekQ.Interests.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace SeekQ.MyInterestLevels.Api.Test
{
    public class UserInterestsControllerTest : BaseIntegrationTest<Startup>
    {
        public UserInterestsControllerTest(WebApplicationFactory<Startup> factory)
            : base(factory)
        {

        }

        [Theory]
        [InlineData("/api/v1/UserInterests/userinterests")]
        public async void SearchInterestByName_getExpectedInterest(string url)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{url}/{InterestsSeeding.ID_USER_JOSE}");

            // Assert
            response.EnsureSuccessStatusCode();
            var userInterest = JsonConvert
                               .DeserializeObject<GetUserInterestsViewModel>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(userInterest.DefaultPublicInterests.Count() == 11, "The user interest where not loaded");
            Assert.True(userInterest.DefaultPrivateInterests.Count() == 10, "The user interest where not loaded");
        }

        [Theory]
        [InlineData("/api/v1/UserInterests/addexistinginterest")]
        public async void AddExistingInterest_addedExpectedExistingInterest(string url)
        {
            // Arrange
            var client = Factory.CreateClient();
            UserAddExistingInterestParams userAddExistingInterestParams = new UserAddExistingInterestParams
            {
                Id = InterestsSeeding.ID_INTEREST_FOREIGN_FILMS,
                Visibility = Level.Public.Id,
                UserId = InterestsSeeding.ID_USER_JOSE
            };

            // Content
            var httpContent = new StringContent(JsonConvert.SerializeObject(userAddExistingInterestParams), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var interest = JsonConvert
                               .DeserializeObject<bool>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(interest == true, "The add existing interest not addaded");
        }

        [Theory]
        [InlineData("/api/v1/UserInterests/addnewinterest")]
        public async void AddNewInterest_addedExpectedNewInterest(string url)
        {
            // Arrange
            var client = Factory.CreateClient();

            UserAddNewInterestParams userAddNewInterestParams = new UserAddNewInterestParams
            {
                Name = "New Interest",
                Visibility = Level.Public.Id,
                UserId = InterestsSeeding.ID_USER_JOSE,
            };

            // Content
            var httpContent = new StringContent(JsonConvert.SerializeObject(userAddNewInterestParams), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var interest = JsonConvert
                               .DeserializeObject<bool>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(interest == true, "The add new interest not addaded");
        }

        [Theory]
        [InlineData("/api/v1/UserInterests/deleteexistinginterest")]
        public async void DeleteExistingInterest_deletedExpectedExistingInterest(string url)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"{url}/{InterestsSeeding.ID_USER_INTEREST_TEST}");

            // Assert
            response.EnsureSuccessStatusCode();
            var interest = JsonConvert
                               .DeserializeObject<bool>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(interest == true, "The delete existing interest not deleted");
        }
    }
}
