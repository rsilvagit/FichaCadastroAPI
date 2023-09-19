using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FichaCadastroAPI.DTO.Ficha;
using FichaCadastroAPI.Model;

namespace FichaCadastroAPI.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            //Origem .... Destino
            CreateMap<FichaCreateDTO, FichaModel>()
                .ForMember(destino => destino.Nome, origem => origem.MapFrom(dados => dados.NomeCompleto))
                .ForMember(destino => destino.Email, origem => origem.MapFrom(dados => dados.EmailInformado.ToLower()))// método ToLower garante que os o email sera registrado em letras minusculas mesmo que o usuario informe em letras maiusculas
                .ForMember(destino => destino.DataNascimento, origem => origem.MapFrom(dados => dados.DataDeNascimento));
            //origem ...destino
            CreateMap<FichaModel, FichaReadDTO>();

            //origem ... destino
            CreateMap<FichaUpdateDTO, FichaModel>();

            //origem ...destino
            CreateMap<FichaModel, FichaDetalhesReadDTO>()
                .ForMember(destino => destino.Detalhes, origem => origem.MapFrom(dados =>dados.DetalheModels));

            //origem ... destino
            CreateMap<DetalheModel, DetalheReadDTO>();
        }
    }
}