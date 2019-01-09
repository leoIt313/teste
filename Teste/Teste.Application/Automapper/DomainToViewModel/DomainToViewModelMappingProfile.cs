using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using Teste.Application.ViewModel.Request;
using Teste.Application.ViewModel.Response;
using Teste.Domain.Entities;

namespace Teste.Application.Automapper.DomainToViewModel
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            this.Configure();
        }

        protected void Configure()
        {
            CreateMap<Usuario, ViewModel.Response.UsuariosViewModel>();
        }
    }
}
