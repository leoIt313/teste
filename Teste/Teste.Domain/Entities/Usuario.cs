using System;
using System.Collections.Generic;

namespace Teste.Domain.Entities
{
    public class Usuario
    {
        public Int64 IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
