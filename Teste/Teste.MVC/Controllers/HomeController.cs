using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Interfaces;
using Teste.MVC.Models;

namespace Teste.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuariosApplication _usuariosApplication;

        public HomeController(IUsuariosApplication UsuariosApplication)
        {
            _usuariosApplication = UsuariosApplication;
        }

        public IActionResult Index()
        {
            return View(_usuariosApplication.GetAllUsuarios());
        }

        public PartialViewResult GetAllUsuarios()
        {
            return PartialView("_Usuarios", _usuariosApplication.GetAllUsuarios());
        }

        public object CadastrarUsuario(Teste.Application.ViewModel.Request.UsuariosViewModel usuariosViewModel)
        {
            try
            {
                var result = _usuariosApplication.CadastrarUsuario(usuariosViewModel);
                return new ExecutionResult(StatusCodes.Status200OK, "Usuario cadastrado com sucesso");
            }
            catch (ArgumentException exception)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ExecutionResult(StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (Exception exception)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ExecutionResult(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        public object AtualizarUsuario(Teste.Application.ViewModel.Request.UsuariosViewModel usuariosViewModel)
        {
            try
            {
                var result = _usuariosApplication.AtualizarUsuario(usuariosViewModel);
                return new ExecutionResult(StatusCodes.Status200OK, "Usuario alterado com sucesso");
            }
            catch (ArgumentException exception)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ExecutionResult(StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (Exception exception)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ExecutionResult(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        public object DeletarUsuario(Teste.Application.ViewModel.Request.UsuariosViewModel usuariosViewModel)
        {
            try
            {
                _usuariosApplication.DeletarUsuario(usuariosViewModel);
                return new ExecutionResult(StatusCodes.Status200OK, "Usuario excluido com sucesso");
            }
            catch (ArgumentException exception)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ExecutionResult(StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (Exception exception)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ExecutionResult(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
