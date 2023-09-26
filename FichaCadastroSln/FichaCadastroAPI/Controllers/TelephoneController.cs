using AutoMapper;
using FichaCadastroAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FichaCadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly FichaCadastroContextDB _fichaCadastroContextDB;
        private readonly ILogger<FichaCadastroController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TelephoneController(IMapper mapper, FichaCadastroContextDB fichaCadastroContextDB, ILogger<FichaCadastroController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _fichaCadastroContextDB = fichaCadastroContextDB;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TelephoneReadDTO> Post([FromBody] TelephoneCreateDTO telephoneCreateDTO)
        {
            TelephoneModel telephoneModel = _mapper.Map<TelephoneModel>(telephoneCreateDTO);

            _fichaCadastroContextDB.TelephoneModels.Add(telephoneModel);
            _fichaCadastroContextDB.SaveChanges();

            TelephoneReadDTO telephoneReadDTO = _mapper.Map<TelephoneReadDTO>(telephoneModel);

            return StatusCode(HttpStatusCode.Created.GetHashCode(), telephoneReadDTO);
        }
    }
}
