using GigginsPractitestApi.DAL.Interfaces;
using GigginsPractitestApi.Models;
using Microsoft.EntityFrameworkCore;
using GigginsPractitestApi.DTO;

namespace GigginsPractitestApi.DAL
{
    public class GigginDAL : IGigginDAL
    {
        private readonly ILogger<GigginDAL> _logger;
        private readonly GigginsPractitestApiContext _GigginsPractitestApiContext;

        public GigginDAL(GigginsPractitestApiContext GigginsPractitestApiContext, ILogger<GigginDAL> logger)
            
        {
            _logger = logger;
            _GigginsPractitestApiContext = GigginsPractitestApiContext;
        }

        public async Task<Giggin?> GetGiggin(int gigginId)
        {
            Giggin? giggin = await _GigginsPractitestApiContext.Giggins
                .Where(c => c.Id == gigginId)
                .FirstOrDefaultAsync();
            return giggin;
        }

        public async Task<List<Giggin>> GetGiggins()
        {
            return await _GigginsPractitestApiContext.Giggins
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

        public async Task<Giggin> UpdateGiggin(Giggin giggin, GigginDTO gigginDTO)
        {
            giggin.Title = gigginDTO.Title;
            giggin.Description = gigginDTO.Description;
            giggin.Price = gigginDTO.Price;

            await _GigginsPractitestApiContext.SaveChangesAsync();
            return giggin;
        }
    }
}
