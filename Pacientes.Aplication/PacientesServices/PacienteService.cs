using Pacientes.Aplication.DTOs;
using Pacientes.Domain.Entities;
using Pacientes.Domain.PacientesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pacientes.Aplication.PacientesServices
{
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteService;


        public PacienteService(IPacienteRepository pacienteService)
        {
            
            _pacienteService = pacienteService;

            
        }


        public async Task<PacienteDto> CrearPaciente(CreatePacienteDto dto)
        {
            var p = new Paciente(dto.TipoDocumento,
            dto.NumeroDocumento,
            dto.Nombre,
            dto.Email,
            dto.Genero,
            dto.Direccion,
            dto.Telefono);

            await _pacienteService.CrearPaciente(p);

            return new PacienteDto
            {
                Id = p.Id,
                TipoDocumento = p.TipoDocumento,
                NumeroDocumento = p.NumeroDocumento,
                Nombre = p.Nombre,
                Email = p.Email,
                Genero = p.Genero,
                Direccion = p.Direccion,
                Telefono = p.Telefono
            };
        }

        public async Task EliminarPaciente(Guid id)
        {
            await _pacienteService.EliminarPaciente(id);
        
        }

        public Task<IEnumerable<PacienteDto>> ObtenerPacientes()
        {
            var pacientes =  _pacienteService.ObtenerPacientes();
            return pacientes.ContinueWith(t => t.Result.Select(p => new PacienteDto
            {
                Id = p.Id,
                TipoDocumento = p.TipoDocumento,
                NumeroDocumento = p.NumeroDocumento,
                Nombre = p.Nombre,
                Email = p.Email,
                Genero = p.Genero,
                Direccion = p.Direccion,
                Telefono = p.Telefono
            }));
        }

        public async Task<PacienteDto> ObtenerPacienteById(Guid id)
        {
            var p = await _pacienteService.ObtenerPacienteById(id);
            return new PacienteDto
            {
                Id = p.Id,
                TipoDocumento = p.TipoDocumento,
                NumeroDocumento = p.NumeroDocumento,
                Nombre = p.Nombre,
                Email = p.Email,
                Genero = p.Genero,
                Direccion = p.Direccion,
                Telefono = p.Telefono
            };
        }


        public async Task ActualizarPaciente(PacienteDto dto)

        {
            var pacienteExistente = await _pacienteService.ObtenerPacienteById(dto.Id);
            if (pacienteExistente == null)
            {
                throw new Exception("Paciente no encontrado");
            }

            Paciente pacienteActualizado = new Paciente(
                dto.TipoDocumento,
                dto.NumeroDocumento,
                dto.Nombre,
                dto.Email,
                dto.Genero,
                dto.Direccion,
                dto.Telefono
            )
            {
                Id = dto.Id
            };

            await _pacienteService.ActualizarPaciente(pacienteActualizado);
        }

    

    }
}
