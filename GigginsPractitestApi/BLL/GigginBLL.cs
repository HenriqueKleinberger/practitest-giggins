using GigginsPractitestApi.BLL.Interfaces;
using GigginsPractitestApi.Constants;
using GigginsPractitestApi.DAL.Interfaces;
using GigginsPractitestApi.DTO;
using GigginsPractitestApi.Exceptions;
using GigginsPractitestApi.Mappers;
using GigginsPractitestApi.Models;

namespace GigginsPractitestApi.BLL
{
    public class GigginBLL : IGigginBLL
    {
        private readonly ILogger<GigginBLL> _logger;
        private readonly IGigginDAL _gigginDAL;


        public GigginBLL(ILogger<GigginBLL> logger, IGigginDAL gigginDAL)
        {
            _logger = logger;
            _gigginDAL = gigginDAL;
        }

        public async Task<List<GigginDTO>> GetGiggins()
        {
            List<Giggin> giggins = await _gigginDAL.GetGiggins();
            return giggins.ConvertAll(c => c.ToGigginDTO());
        }

        public async Task<GigginDTO> UpdateGiggin(GigginDTO gigginDTO, int gigginId)
        {   
            Giggin? gigginToUpdate = await _gigginDAL.GetGiggin(gigginId);
            ValidateGiggin(gigginToUpdate);
            
            Giggin gigginUpdated = await _gigginDAL.UpdateGiggin(gigginToUpdate, gigginDTO);

            return gigginUpdated.ToGigginDTO();
        }

        
        private void ValidateGiggin(Giggin? giggin)
        {
            if (giggin == null)
            {
                throw new ValidationException(ErrorMessages.GIGGIN_NOT_FOUND);

            }
        }
    }
}
