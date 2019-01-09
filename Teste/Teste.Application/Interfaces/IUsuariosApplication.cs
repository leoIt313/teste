using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.ViewModel.Request;
using Teste.Application.ViewModel.Response;

namespace Teste.Application.Interfaces
{
    public interface IUsuariosApplication : IDisposable
    {
        IEnumerable<Teste.Application.ViewModel.Response.UsuariosViewModel> GetAllUsuarios();
        Teste.Application.ViewModel.Response.UsuariosViewModel CadastrarUsuario(Teste.Application.ViewModel.Request.UsuariosViewModel Usuario);
        Teste.Application.ViewModel.Response.UsuariosViewModel AtualizarUsuario(Teste.Application.ViewModel.Request.UsuariosViewModel Usuario);
        void DeletarUsuario(Teste.Application.ViewModel.Request.UsuariosViewModel Usuario);
    }
}
