using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Teste.Application.Automapper.DomainToViewModel;
using Teste.Application.Automapper.ViewModelToDomain;

namespace Teste.Application.Automapper
{
    public class AutoMapperConfig
    {

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                #region DomainView
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                #endregion

                #region ViewDomain
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
                #endregion 


            });
        }
    }
}
