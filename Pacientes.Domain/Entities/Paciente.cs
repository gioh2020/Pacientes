using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pacientes.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Paciente(
            string tipoDocumento,
            string numeroDocumento,
            string nombre,
            string email,
            string genero,
            string direccion,
            string telefono

            )
        {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Nombre = nombre;
            Email = email;
            Genero = genero;
            Direccion = direccion;
            Telefono = telefono;

        }


        public static string ValidarName(string nombre)
        { 
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            if (nombre.Length < 2 || nombre.Length > 50)
            {
                throw new ArgumentException("El nombre debe tener entre 2 y 50 caracteres.");
            }
            return nombre;

        }
        public Paciente()
        {
        }

    }


  
}
