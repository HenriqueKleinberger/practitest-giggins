using GigginsPractitestApi.DTO;
using GigginsPractitestApi.Models;

namespace GigginsPractitestApi.DAL.Interfaces
{
    public interface IGigginDAL
    {
        public Task<Giggin> UpdateGiggin(Giggin giggin, GigginDTO gigginDTO);
        public Task<Giggin?> GetGiggin(int gigginId);
        public Task<List<Giggin>> GetGiggins();
    }
}
