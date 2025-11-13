using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes.Aplication.DTOs
{
    public class PacienteDto
    {

        public Guid Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class CreatePacienteDto
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class EliminarPacienteDto
    {
        public Guid Id { get; private set; }

    }

    public class ActualizarPacienteDto
    {

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
}
