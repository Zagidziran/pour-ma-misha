using Dapper;
using DataAceess.Entities;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAceess
{
    public class PowerPlantsService
    {
        private readonly DatabaseConfiguration configuration;


        public PowerPlantsService(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IList<PowerPlant>> GetPowerPlants()
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            var result = await connection.QueryAsync<PowerPlant>("SELECT * FROM PowerPlants");

            return result.AsList();
        }

        public async Task UpdatePowerPlant(PowerPlant data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "UPDATE PowerPlants SET " +
                    "name = @name, " +
                    "countryId = @countryId, " +
                    "reactorCount = @reactorCount, " +
                    "reactorType=@reactorType, " +
                    "grossCapacity = @grossCapacity, " +
                    "netCapacity = @netCapacity, " +
                    "commissedAt = @commissedAt, " +
                    "decommissedAt = @decommissedAt, " +
                    "monitoringPeriod = @monitoringPeriod " +
                "WHERE id = @id",
                data);
        }

        public async Task DeletePowerPlant(int id)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            await connection.ExecuteAsync(
                "DELETE FROM Countries WHERE id = @id",
                new { id });
        }

        public async Task<int> AddPowerPlant(PowerPlant data)
        {
            using var connection = new SqliteConnection(this.configuration.ConnectionString);

            return await connection.ExecuteScalarAsync<int>(
                "INSERT INTO PowerPlants (name, countryId, reactorCount, reactorType, grossCapacity, netCapacity, commissedAt, decommissedAt, monitoringPeriod) SET " +
                "VALUES (@name, @countryId, @reactorCount, @reactorType, @grossCapacity, @netCapacity, @commissedAt, @decommissedAt, @monitoringPeriod); " +
                "SELECT last_insert_rowid()",
                data);
        }

    }
}
