using Microsoft.AspNetCore.Mvc;
using Pacientes.Aplication.DTOs;
using Pacientes.Aplication.PacientesServices;

namespace Pacientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;
        public PacienteController(Pacientes.Aplication.PacientesServices.PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }


        [HttpPost("CrearPaciente")]

        public
            async Task<IActionResult> CrearPaciente([FromBody] Pacientes.Aplication.DTOs.CreatePacienteDto dto)
        {
            var pacienteCreado = await _pacienteService.CrearPaciente(dto);
            return Ok(pacienteCreado);
        }

        [HttpDelete("EliminarPaciente/{id}")]
        public async Task<IActionResult> EliminarPaciente(Guid id)
        {
            await _pacienteService.EliminarPaciente(id);
            return NoContent();
        }

        [HttpGet("ObtenerPacientes")]
        public async Task<IActionResult> ObtenerPacientes()
        {
            var pacientes = await _pacienteService.ObtenerPacientes();
            return Ok(pacientes);
        }

        [HttpPut("ActualizarPaciente/{id}")]
        public async Task<IActionResult> ActualizarPaciente(Guid id, [FromBody] Pacientes.Aplication.DTOs.ActualizarPacienteDto dto)
        {
    
            var pacienteDto = new Pacientes.Aplication.DTOs.PacienteDto
            {
                Id = id,
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono

            };
            await _pacienteService.ActualizarPaciente(pacienteDto);
            return NoContent();
        }

    }
}
