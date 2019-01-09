using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces.Repository;
using Teste.Infra.Context;

namespace Teste.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TesteContext context) : base(context)
        {

        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return this.GetAll();
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
          var usr =  this.GetById(usuario.IdUsuario);
          usr.NomeCompleto = usuario.NomeCompleto;
          usr.Telefone = usuario.Telefone;
          usr.Email = usuario.Email;
          this.Update(usr);
          return usuario;
        }

        public void DeleteUsuario(Usuario usuario)
        {
            this.Remove(usuario.IdUsuario);
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            this.Add(usuario);
            this.SaveChanges();
            return usuario;
        }
       
    }
}
