using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Teste.Application.ViewModel.Request;
using Teste.Application.ViewModel.Response;
using Teste.Domain.Entities;

namespace Teste.Application.Automapper.ViewModelToDomain
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            this.Configure();
        }

        protected void Configure()
        {
            CreateMap<ViewModel.Request.UsuariosViewModel, Usuario>();
        }
    }
}
