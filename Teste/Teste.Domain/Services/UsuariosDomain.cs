using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces.Repository;
using Teste.Domain.Interfaces.Services;

namespace Teste.Domain.Services
{
    public class UsuariosDomain : IUsuariosDomain
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
       

        public UsuariosDomain(IUsuarioRepository UsuarioRepository,IUnitOfWork unitOfWork)
        {
            _usuarioRepository = UsuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public Usuario AtualizarUsuario(Usuario Usuario)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var result = _usuarioRepository.UpdateUsuario(Usuario);
                _unitOfWork.Commit();

                return result;
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();

            }
            finally
            {
                Dispose();

            }

            return new Usuario();
        }

        public Usuario CadastrarUsuario(Usuario Usuario)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var result =  _usuarioRepository.AddUsuario(Usuario);
                _unitOfWork.Commit();

                return result;
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();

            }
            finally
            {
                Dispose();

            }

            return new Usuario();
        }

        public void DeletarUsuario(Usuario Usuario)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                 _usuarioRepository.DeleteUsuario(Usuario);
                _unitOfWork.Commit();

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();

            }
            finally
            {
                Dispose();

            }
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            _unitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAllUsuarios();
        }

        void IDisposable.Dispose()
        {
        }
    }
}
