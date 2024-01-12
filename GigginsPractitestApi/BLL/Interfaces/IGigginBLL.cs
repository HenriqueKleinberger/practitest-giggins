using GigginsPractitestApi.DTO;

namespace GigginsPractitestApi.BLL.Interfaces
{
    public interface IGigginBLL
    {
        public Task<GigginDTO> UpdateGiggin(GigginDTO gigginDTO, int gigginId);
        public Task<List<GigginDTO>> GetGiggins();
    }
}
