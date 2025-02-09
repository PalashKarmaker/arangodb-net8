﻿using ArangoDBNet.DatabaseApi;
using System.Threading.Tasks;

namespace ArangoDBNetTest.DatabaseApi
{
    /// <summary>
    /// Provides per-test-class fixture data for <see cref="DatabaseApiClientTest"/>.
    /// </summary>
    public class DatabaseApiClientTestFixture : ApiClientTestFixtureBase
    {
        /// <summary>
        /// A <see cref="DatabaseApiClient"/> targeting the _system database.
        /// </summary>
        public IDatabaseApiClient DatabaseClientSystem { get; internal set; }

        /// <summary>
        /// A <see cref="DatabaseApiClient"/> targeting a database that does not exist.
        /// </summary>
        public IDatabaseApiClient DatabaseClientNonExistent { get; internal set; }

        /// <summary>
        /// A <see cref="DatabaseApiClient"/> targeting an existing database other than _system.
        /// </summary>
        public IDatabaseApiClient DatabaseClientOther { get; internal set; }

        public string DeletableDatabase { get; } = nameof(DatabaseApiClientTestFixture) + "_ToBeDeleted";

        public DatabaseApiClientTestFixture()
        {
            DatabaseClientSystem = GetArangoDBClient("_system").Database;
            DatabaseClientNonExistent = GetArangoDBClient("DatabaseThatDoesNotExist").Database;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            string dbName = nameof(DatabaseApiClientTestFixture);

            await CreateDatabase(dbName);

            await CreateDatabase(DeletableDatabase);

            var arangoDBClient = GetArangoDBClient(dbName);
            DatabaseClientOther = arangoDBClient.Database;
            await GetVersionAsync(arangoDBClient);
        }
    }
}
