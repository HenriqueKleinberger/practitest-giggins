using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using GigginsPractitestApi.BLL.Interfaces;
using GigginsPractitestApi.DTO;

namespace GigginsPractitestApi.Controllers
{
    [ApiController]
    [Route("giggins")]
    public class GigginController : ControllerBase
    {
        private readonly ILogger<GigginController> _logger;
        private readonly IGigginBLL _gigginBLL;
        private readonly IValidator<GigginDTO> _gigginDtoValidator;

        public GigginController(ILogger<GigginController> logger, IGigginBLL gigginBLL, IValidator<GigginDTO> gigginDtoValidator)
        {
            _logger = logger;
            _gigginBLL = gigginBLL;
            _gigginDtoValidator = gigginDtoValidator;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<GigginDTO>> GetAll()
        {
            List<GigginDTO> giggins = await _gigginBLL.GetGiggins();
            return Ok(giggins);
        }

        [HttpPut("{gigginId}", Name = "PutGiggin")]
        [ActionName(nameof(GigginDTO))]
        public async Task<ActionResult<GigginDTO>> Put(int gigginId, [FromBody] GigginDTO gigginDTO)
        {
            GigginDTO updated;

            ValidationResult result = await _gigginDtoValidator.ValidateAsync(gigginDTO);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            try
            {
                updated = await _gigginBLL.UpdateGiggin(gigginDTO, gigginId);
            }
            catch (Exceptions.ValidationException ex)
            {
                return base.BadRequest(ex.Message);
            }

            return Ok(updated);
        }
    }
}
