using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using GigginsPractitestApi.Constants;
using GigginsPractitestApi.Models;
using GigginsPractitestApiTests.Builders;
using GigginsPractitestApiTests.Utils;
using System.Net;
using System.Text;
using GigginsPractitestApi.DTO;

namespace GigginsPractitestApiTests.Controllers.GigginControllerTests
{
    public class PutGigginTests : IClassFixture<WebApplicationFactory<Program>>
    {
        public const string PUT_URL = "/giggins";

        [Fact]
        public async Task ShouldUpdateValidGiggin()
        {
            // arrange

            Giggin gigginToUpdate;
            GigginDTO gigginDTO = new GigginDTOBuilder()
                .WithTitle("Updated Title")
                .WithDescription("Updated Description")
                .WithPrice(15000)
                .Build();

            await using var application = new GigginsPractitestApiApplication();

            using (var scope = application.Services.CreateScope())
            {
                var scopeService = scope.ServiceProvider;
                var dbContext = scopeService.GetRequiredService<GigginsPractitestApiContext>();

                gigginToUpdate = new GigginBuilder()
                    .WithTitle("Put Title 1")
                    .WithDescription("Put Description 1")
                    .WithPrice(20000)
                    .Build();

                gigginToUpdate = dbContext.Giggins.Add(gigginToUpdate).Entity;

                dbContext.SaveChanges();
            }

            // act
            HttpContent content = new StringContent(JsonConvert.SerializeObject(gigginDTO), Encoding.UTF8, "application/json");
            using var client = application.CreateClient();
            using var response = await client.PutAsync($"{PUT_URL}/{gigginToUpdate.Id}", content);

            // assert
            string responseBody = await response.Content.ReadAsStringAsync();
            GigginDTO gigginUpdated = JsonConvert.DeserializeObject<GigginDTO>(responseBody);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            AssertObjects.AssertEquals(gigginUpdated, gigginDTO);
        }

        [Fact]
        public async Task ShouldReturnBadRequestWhenPriceIsNegative()
        {
            // arrange
            Giggin gigginToUpdate;
            GigginDTO gigginDTO = new GigginDTOBuilder()
                .WithPrice(-5)
                .Build();

            await using var application = new GigginsPractitestApiApplication();

            using (var scope = application.Services.CreateScope())
            {
                var scopeService = scope.ServiceProvider;
                var dbContext = scopeService.GetRequiredService<GigginsPractitestApiContext>();

                gigginToUpdate = new GigginBuilder().Build();

                gigginToUpdate = dbContext.Giggins.Add(gigginToUpdate).Entity;

                dbContext.SaveChanges();
            }

            // act
            HttpContent content = new StringContent(JsonConvert.SerializeObject(gigginDTO), Encoding.UTF8, "application/json");
            using var client = application.CreateClient();
            using var response = await client.PutAsync($"{PUT_URL}/{gigginToUpdate.Id}", content);

            // assert
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}