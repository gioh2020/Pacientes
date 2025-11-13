using Pacientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes.Domain.PacientesRepositories
{
    public interface IPacienteRepository
    {
   
            Task<Paciente> ObtenerPacienteById(Guid id);
            Task<IEnumerable<Paciente>> ObtenerPacientes();
            Task CrearPaciente(Paciente paciente);
            Task ActualizarPaciente(Paciente paciente);
            Task EliminarPaciente(Guid id);

    }
}
