using Dapper;
using DataAceess.Entities;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAceess
{
    public class EventsService
    {
        private readonly DatabaseConfiguration configuration;


        public EventsService(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IList<Event>> GetPowerPlants()
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            var result = await connection.QueryAsync<Event>("SELECT * FROM Events");

            return result.AsList();
        }

        public async Task UpdateEvent(Event data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "UPDATE Events SET " +
                    "date = @date, " +
                    "plantId = @plantId, " +
                    "description = @description, " +
                    "reason=@reason, " +
                    "rating = @rating, " +
                    "consequences = @consequences " +
                "WHERE id = @id",
                data);
        }

        public async Task DeleteEvent(int id)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "DELETE FROM Events WHERE id = @id",
                new { id });
        }

        public async Task<int> AddEvent(Event data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            return await connection.ExecuteScalarAsync<int>(
                "INSERT INTO Events (date, PlantId, Description, Reason, Rating, Consequences) " +
                "VALUES (@date, @plantId, @description, @reason,  @rating, @consequences); " +
                "SELECT last_insert_rowid()",
                data);
        }

    }
}
