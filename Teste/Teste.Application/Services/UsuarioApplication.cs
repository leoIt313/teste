using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Teste.Application.Interfaces;
using Teste.Application.ViewModel.Request;
using Teste.Application.ViewModel.Response;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces.Services;

namespace Teste.Application.Services
{
    public class UsuarioApplication : IUsuariosApplication
    {
        private readonly IUsuariosDomain _iUsuariosService;

        public UsuarioApplication(IUsuariosDomain iUsuariosService)
        {
            _iUsuariosService = iUsuariosService;
        }

        public IEnumerable<ViewModel.Response.UsuariosViewModel> GetAllUsuarios()
        {
            var teste = _iUsuariosService.GetAllUsuarios();
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<ViewModel.Response.UsuariosViewModel>>(_iUsuariosService.GetAllUsuarios());
        }

        public void Dispose()
        {
            _iUsuariosService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ViewModel.Response.UsuariosViewModel CadastrarUsuario(ViewModel.Request.UsuariosViewModel usuarioViewModel)
        {
            var mapUsuario = Mapper.Map<ViewModel.Request.UsuariosViewModel, Usuario>(usuarioViewModel);
            return Mapper.Map<Usuario, ViewModel.Response.UsuariosViewModel>(_iUsuariosService.CadastrarUsuario(mapUsuario));
        }

        public ViewModel.Response.UsuariosViewModel AtualizarUsuario(ViewModel.Request.UsuariosViewModel usuarioViewModel)
        {
            var mapUsuario = Mapper.Map<ViewModel.Request.UsuariosViewModel, Usuario>(usuarioViewModel);
            return Mapper.Map<Usuario, ViewModel.Response.UsuariosViewModel>(_iUsuariosService.AtualizarUsuario(mapUsuario));
        }

        public void DeletarUsuario(ViewModel.Request.UsuariosViewModel usuarioViewModel)
        {
            var mapUsuario = Mapper.Map<ViewModel.Request.UsuariosViewModel, Usuario>(usuarioViewModel);
            _iUsuariosService.DeletarUsuario(mapUsuario);
        }
    }
}
