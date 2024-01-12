using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using GigginsPractitestApi.DTO;
using GigginsPractitestApi.Models;
using GigginsPractitestApiTests.Builders;
using System.Net;

namespace GigginsPractitestApiTests.Controllers.GigginControllerTests
{
    public class GetAllGigginsTests
    {
        public const string GET_ALL = "/giggins";

        [Fact]
        public async Task ShouldGetAllGiggins()
        {
            // arrange
            Giggin giggin1;
            Giggin giggin2;

            await using var application = new GigginsPractitestApiApplication();
            using (var scope = application.Services.CreateScope())
            {
                var scopeService = scope.ServiceProvider;
                var dbContext = scopeService.GetRequiredService<GigginsPractitestApiContext>();

                giggin1 = new GigginBuilder()
                    .WithTitle("Get Title 1")
                    .WithDescription("Get Description 1")
                    .WithArtist("Get Artist 1")
                    .WithImage("Get Image 1")
                    .IsSoldOut(false)
                    .WithPrice(15000)
                    .Build();

                giggin2 = new GigginBuilder()
                    .WithTitle("Get Title 2")
                    .WithDescription("Get Description 2")
                    .WithArtist("Get Artist 2")
                    .WithImage("Get Image 2")
                    .IsSoldOut(true)
                    .WithPrice(40000)
                    .Build();

                giggin1 = dbContext.Giggins.Add(giggin1).Entity;
                giggin2 = dbContext.Giggins.Add(giggin2).Entity;

                dbContext.SaveChanges();
            }

            // act

            using var client = application.CreateClient();
            using var response = await client.GetAsync(GET_ALL);

            // assert
            string responseBody = await response.Content.ReadAsStringAsync();
            List<GigginDTO> giggins = JsonConvert.DeserializeObject<List<GigginDTO>>(responseBody);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(giggins.Count, 2);
            AssertEquals(giggin1, giggins[0]);
            AssertEquals(giggin2, giggins[1]);
        }

        private void AssertEquals(Giggin expected, GigginDTO actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.Artist, actual.Artist);
            Assert.Equal(expected.Image, actual.Image);
            Assert.Equal(expected.SoldOut, actual.SoldOut);
        }
    }
}