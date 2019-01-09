using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository:IDisposable
    {
        IEnumerable<Usuario> GetAllUsuarios();

        Usuario AddUsuario(Usuario Usuario);

        Usuario UpdateUsuario(Usuario usuario);

        void DeleteUsuario(Usuario usuario);

    }
}
