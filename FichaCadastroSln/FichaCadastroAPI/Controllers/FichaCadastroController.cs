using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FichaCadastroAPI.DTO.Ficha;
using FichaCadastroAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FichaCadastroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FichaCadastroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly FichaCadastroContextDB _fichaCadastroContextDB;

        public FichaCadastroController(IMapper mapper, FichaCadastroContextDB fichaCadastroContextDB)
        {
            _mapper = mapper;
            _fichaCadastroContextDB = fichaCadastroContextDB;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<FichaReadDTO> Post ([FromBody] FichaCreateDTO fichaCreateDTO)
        {
            try
            {
                bool existeEmailInformado = _fichaCadastroContextDB
                    .FichaModels
                    .ToList()
                    .Exists(exists => exists.Email == fichaCreateDTO.EmailInformado);
                if(existeEmailInformado)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "E-mail já cadastrado");
                }
                FichaModel fichaModel = _mapper.Map<FichaModel>(fichaCreateDTO);
                _fichaCadastroContextDB.FichaModels.Add(fichaModel);
                _fichaCadastroContextDB.SaveChanges();

                FichaReadDTO fichaReadDTO = _mapper.Map<FichaReadDTO>(fichaModel);
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), fichaReadDTO);
            }
            catch (Exception ex)
            {
                StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FichaReadDTO> Put([FromRoute] int id, [FromBody] FichaUpdateDTO fichaUpdateDTO)
        {
            return Ok();
        }
    }
}