using ArangoDBNet;
using ArangoDBNet.CollectionApi.Models;
using System;
using System.Threading.Tasks;

namespace ArangoDBNetTest.CollectionApi;

public class CollectionApiClientTestFixture : ApiClientTestFixtureBase
{
    public ArangoDBClient ArangoDBClient { get; internal set; }

    public string TestCollection { get; } = "Rules";

    public CollectionApiClientTestFixture()
    {
    }

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        string dbName = nameof(CollectionApiClientTestFixture);

        await CreateDatabase(dbName);

        ArangoDBClient = GetArangoDBClient(dbName);
        await GetVersionAsync(ArangoDBClient);
        try
        {
            await ArangoDBClient.Collection.PostCollectionAsync(
                new PostCollectionBody
                {
                    Name = TestCollection
                });
        }
        catch (ApiErrorException ex) when (ex.ApiError.ErrorNum == 1207)
        {
            // The collection must exist already, carry on...
            Console.WriteLine(ex.Message);
        }
    }
}
