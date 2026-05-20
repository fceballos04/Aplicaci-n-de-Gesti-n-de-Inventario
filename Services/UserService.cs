using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json;
using AntHiveStock.Models;

namespace AntHiveStock.Services
{
    public static class UserService
    {
        private static string folderPath = FileSystem.AppDataDirectory;
        private static string filePath = Path.Combine(folderPath, "usuarios.json");

        public static void RegistrarUsuario(Usuario nuevoUsuario)
        {
            List<Usuario> usuarios = ObtenerTodos();
            usuarios.Add(nuevoUsuario);

            string jsonString = JsonSerializer.Serialize(usuarios);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Usuario> ObtenerTodos()
        {
            System.Diagnostics.Debug.WriteLine($"RUTA DEL ARCHIVO JSON: {filePath}");

            if (!File.Exists(filePath))
                return new List<Usuario>();

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Usuario>>(jsonString) ?? new List<Usuario>();
        }
    }
}
