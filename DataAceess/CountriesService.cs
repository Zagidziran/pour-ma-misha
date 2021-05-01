using Dapper;
using DataAceess.Entities;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAceess
{
    public class CountriesService
    {
        private readonly DatabaseConfiguration configuration;


        public CountriesService(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IList<Country>> GetCountries()
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            var result = await connection.QueryAsync<Country>("SELECT * FROM Countries");

            return result.AsList();
        }

        public async Task UpdateCountry(Country data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "UPDATE Countries SET name = @name, code = @code, @continrtId = @continetId WHERE id = @id",
                data);
        }

        public async Task DeleteCountry(int id)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "DELETE FROM Countries WHERE id = @id",
                new { id });
        }

        public async Task<int> AddCountry(Country data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            return await connection.ExecuteScalarAsync<int>(
                "INSERT INTO Countries (name, code, continentId) VALUES (@name, @code, @continetId); SELECT last_insert_rowid()",
                data);
        }
    }
}
