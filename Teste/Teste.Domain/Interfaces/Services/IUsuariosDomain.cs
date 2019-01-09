using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Domain.Interfaces.Services
{
    public interface IUsuariosDomain : IDisposable
    {
        IEnumerable<Usuario> GetAllUsuarios();

        Usuario CadastrarUsuario(Usuario Usuario);
        Usuario AtualizarUsuario(Usuario Usuario);
        void DeletarUsuario(Usuario Usuario);

    }
}
