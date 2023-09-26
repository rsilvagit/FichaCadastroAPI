using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FichaCadastroAPI.DTO.Detalhe;
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
                .ForMember(destino => destino.ContatenacaoNomeEmail,
                           origem => origem.MapFrom(dados => $"{dados.Nome} - {dados.Email}"))
                .ForMember(destino => destino.Detalhes, origem => origem.MapFrom(dados => dados.DetalheModels));
            
            //origem ... destino
            CreateMap<DetalheModel, DetalheReadDTO>();

            //origem destino
            CreateMap<FichaModel, FichaTelephoneReadDTO>()
                .ForMember(destino => destino.ListTelephones, origem => origem.MapFrom(dados => dados.TelephoneModels));

            //origem ... destino
            CreateMap<TelephoneModel, TelephoneCreateDTO>();
            //origem ... destino
            CreateMap<TelephoneModel, TelephoneReadDTO>()
                .ForMember(destino => destino.Contato,
                           origem => origem.MapFrom(dados => $"{dados.Ddd} - {dados.Number}"))
                .ForMember(destino => destino.ative,
                      origem => origem.MapFrom(dados => dados.Ative));
            //origem ... destino
            CreateMap<TelephoneUpdateDTO,TelephoneModel>();
                
        }
    }
}