using AutoMapper;
using FichaCadastroAPI.DTO.Ficha;
using FichaCadastroAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                _logger.LogCritical($"Dados {telephoneCreateDTO.ToString()}");
                var ip = _httpContextAccessor
                                    .HttpContext!
                                    .Connection!
                                    .RemoteIpAddress!
                                    .ToString();

                _logger.LogWarning($"IP Requisição {ip}");

                bool existeFichaId = _fichaCadastroContextDB
                                            .FichaModels
                                            .ToList()
                                            .Exists(exists => exists.Id == telephoneCreateDTO.FichaId);

                if (existeFichaId==false)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Não encontrada a ficha com id indicado");
                }

                TelephoneModel telephoneModel = _mapper.Map<TelephoneModel>(telephoneCreateDTO);



            _fichaCadastroContextDB.TelephoneModels.Add(telephoneModel);
            _fichaCadastroContextDB.SaveChanges();

            TelephoneReadDTO telephoneReadDTO = _mapper.Map<TelephoneReadDTO>(telephoneModel);

            return StatusCode(HttpStatusCode.Created.GetHashCode(), telephoneReadDTO);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TelephoneReadDTO> Put([FromRoute] int id, [FromBody] TelephoneUpdateDTO telephoneUpdateDTO)
        {
            try
            {
                TelephoneModel? telephoneModel = _fichaCadastroContextDB
                                                                .TelephoneModels
                                                                .Find(id);
                //validação 
                if (telephoneModel == null)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Não pode alterar um registro que não exista na base de dados");
                }

                telephoneModel = _mapper.Map(telephoneUpdateDTO, telephoneModel);

                _fichaCadastroContextDB.TelephoneModels.Update(telephoneModel);
                _fichaCadastroContextDB.SaveChanges();

                TelephoneReadDTO telephoneReadDTO = _mapper.Map<TelephoneReadDTO>(telephoneModel);

                return StatusCode(HttpStatusCode.OK.GetHashCode(), telephoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//  gera uma anotação no sweger informando os tipos de retorno do método
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                
                TelephoneModel? telephoneModel = _fichaCadastroContextDB
                                                    .TelephoneModels
                                                    .Where(w => w.Id == id)
                                                    .FirstOrDefault();

                if (telephoneModel == null)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Não existe dados a ser excluído");
                }


                _fichaCadastroContextDB.TelephoneModels.Remove(telephoneModel);
                _fichaCadastroContextDB.SaveChanges();

                return StatusCode(HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<FichaTelephoneReadDTO>> Get([FromQuery] int? FichaId)
        {
            try
            {
                List<TelephoneModel>? telephonesModel;

                //validação
               
               
                    telephonesModel = _fichaCadastroContextDB
                                                    .TelephoneModels
                                                    .ToList();
                

                IEnumerable<FichaTelephoneReadDTO> fichaTelephoneReadDTO = _mapper.Map<IEnumerable<FichaTelephoneReadDTO>>(telephonesModel);

                return StatusCode(HttpStatusCode.OK.GetHashCode(), fichaTelephoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FichaTelephoneReadDTO> Get([FromRoute] int Fichaid)
        {
            try
            {
                
                if (Fichaid == 0)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Id está igual a zero");
                }

                TelephoneModel? telephoneModel = _fichaCadastroContextDB
                                                    .TelephoneModels
                                                    .Where(w => w.FichaId == Fichaid)
                                                    .FirstOrDefault();


                FichaTelephoneReadDTO fichaTelephoneReadDTO = _mapper.Map<FichaTelephoneReadDTO>(telephoneModel);

                return StatusCode(HttpStatusCode.OK.GetHashCode(), fichaTelephoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

    }
}
