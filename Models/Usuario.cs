using System;
using System.Collections.Generic;
using System.Text;

namespace AntHiveStock.Models
{
    public class Usuario
    {
        public string NombreEmpresa { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
