using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

using Dapper;
using Pacientes.Domain.Entities;
using Pacientes.Domain.PacientesRepositories;


namespace Pacientes.Infraestructure.PacienteRepositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly string _connectionString;
        public PacienteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MySql");


        }

        private MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task ActualizarPaciente(Paciente paciente)
        {
            
            const string sql = @"
                UPDATE Paciente
                SET TipoDocumento = @TipoDocumento,
                    NumeroDocumento = @NumeroDocumento,
                    Nombre = @Nombre,
                    Email = @Email,
                    Genero = @Genero,
                    Direccion = @Direccion,
                    Telefono = @Telefono
                WHERE Id = @Id;";

            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new
            {
                paciente.TipoDocumento,
                paciente.NumeroDocumento,
                paciente.Nombre,
                paciente.Email,
                paciente.Genero,
                paciente.Direccion,
                paciente.Telefono,
                paciente.Id
            });
        }
            
        public async Task CrearPaciente(Paciente paciente)
        {
              const string sql = @"
                INSERT INTO Paciente (Id, TipoDocumento, NumeroDocumento, Nombre, Email, Genero, Direccion, Telefono)
                VALUES (@Id, @TipoDocumento, @NumeroDocumento, @Nombre, @Email, @Genero, @Direccion, @Telefono);";

            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new
            {
                paciente.Id,
                paciente.TipoDocumento,
                paciente.NumeroDocumento,
                paciente.Nombre,
                paciente.Email,
                paciente.Genero,
                paciente.Direccion,
                paciente.Telefono
            });


        }

        public async Task EliminarPaciente(Guid id)
        {
            
            const string sql = @"
                DELETE FROM Paciente
                WHERE Id = @Id;";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Paciente> ObtenerPacienteById(Guid id)
        {
            const string sql = @"
                SELECT Id, TipoDocumento, NumeroDocumento, Nombre, Email, Genero, Direccion, Telefono
                FROM Pacientes
                WHERE Id = @Id;";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Paciente>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Paciente>> ObtenerPacientes()
        {
            
            const string sql = @"
                SELECT Id, TipoDocumento, NumeroDocumento, Nombre, Email, Genero, Direccion, Telefono
                FROM Paciente;";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Paciente>(sql);
        }

    }
}
