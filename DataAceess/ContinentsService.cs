using Dapper;
using DataAceess.Entities;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAceess
{
    public class ContinentsService
    {
        private readonly DatabaseConfiguration configuration;


        public ContinentsService(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IList<Continent>> GetContinents()
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            var result = await connection.QueryAsync<Continent>("SELECT * FROM Continents");

            return result.AsList();
        }

        public async Task UpdateContinent(Continent data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "UPDATE Continents SET name = @name, code = @code WHERE id = @id",
                data);
        }

        public async Task DeleteContinent(int id)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "DELETE FROM Continents WHERE id = @id",
                new { id });
        }

        public async Task<int> AddContinent(Continent data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            return await connection.ExecuteScalarAsync<int>(
                "INSERT INTO Continents (name, code) VALUES (@name, @code); SELECT last_insert_rowid() ",
                data);
        }
    }
}
