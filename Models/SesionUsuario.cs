using System;
using System.Collections.Generic;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

namespace AntHiveStock.Models
{
    // Lo convertimos en un ObservableObject para que el menú lateral
    // se entere en tiempo real cuando el nombre cambie al loguearse.
    public partial class SesionUsuario : ObservableObject
    {
        private static string _nombreEmpresa = "Invitado";
        private static string _correo = string.Empty;

        public static string NombreEmpresa
        {
            get => _nombreEmpresa;
            set => _nombreEmpresa = value;
        }

        public static string Correo
        {
            get => _correo;
            set => _correo = value;
        }
    }
}
