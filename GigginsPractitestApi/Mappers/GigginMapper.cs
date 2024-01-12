using GigginsPractitestApi.DTO;
using GigginsPractitestApi.Models;

namespace GigginsPractitestApi.Mappers
{
    public static class GigginMapper
    {
        public static GigginDTO ToGigginDTO(this Giggin giggin)
        {
            
            GigginDTO gigginDTO = new GigginDTO()
            {
                Id = giggin.Id,
                Title = giggin.Title,
                Description = giggin.Description,
                Price = giggin.Price,
                Artist = giggin.Artist,
                Image = giggin.Image,
                SoldOut = giggin.SoldOut
            };
            return gigginDTO;
        }
    }
}
