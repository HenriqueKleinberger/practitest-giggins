using GigginsPractitestApi.DTO;

namespace GigginsPractitestApiTests.Utils
{
    public static class AssertObjects
    {
        public static void AssertEquals(GigginDTO expected, GigginDTO actual)
        {
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.Artist, actual.Artist);
            Assert.Equal(expected.Image, actual.Image);
            Assert.Equal(expected.SoldOut, actual.SoldOut);
        }
    }
}
