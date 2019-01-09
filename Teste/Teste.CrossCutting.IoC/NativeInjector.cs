using Teste.Infra.UoW;
using Teste.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Teste.Application.Services;
using Teste.Domain.Interfaces.Services;
using Teste.Domain.Interfaces.Repository;
using Teste.Domain.Services;
using Teste.Infra.Repository;

namespace Teste.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Application

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<Application.Interfaces.IUsuariosApplication, UsuarioApplication>();
           

            #endregion

            #region Domain
            services.AddScoped<IUsuariosDomain, UsuariosDomain>();
          

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
          
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region  Infra

            services.AddScoped<TesteContext>();

            #endregion

        }
    }
}
