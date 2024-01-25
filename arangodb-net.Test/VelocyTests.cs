using ArangoDBNet;
using ArangoDBNet.CollectionApi.Models;
using ArangoDBNet.Serialization;
using ArangoDBNet.Transport.Http;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ArangoDBNetTest.CollectionApi;

public class VelocyTests
{
    [Fact]
    public async Task GetVelocyCollectionCountAsync_ShouldSucceed()
    {
        // You must use the _system database to create databases
        var serialization = new VelocyPackApiClientSerialization();//VelocyStreamApiTransport
        //using var transport = VelocyStreamApiTransport.UsingBasicAuthWithDbName(
        //    new Uri("http://localhost:8529/"), "Rules", "root", "palash", null);
        using var transport = HttpApiTransport.UsingBasicAuth(
            new Uri("http://localhost:8529/"), "Rules", "root", "palash", HttpContentType.Json);
        using var adb = new ArangoDBClient(transport, serialization);

        //try
        //{
        //    var resp = await adb.Collection.PostCollectionAsync(
        //        new PostCollectionBody
        //        {
        //            Name = "MyCollection"
        //        });
        //}
        //catch (ApiErrorException exc) when (exc.ApiError.ErrorNum == 1207)
        //{

        //}
        var response = await adb.Document.PostDocumentAsync("MyCollection",
            new
            {
                MyProperty = "Value"
            });

        //var newDoc = await _adb.Document.PostDocumentAsync(_testCollection, new PostDocumentsQuery());
        //var response = await _collectionApi.GetCollectionCountAsync(_testCollection);

        Assert.False(string.IsNullOrWhiteSpace(response._key));
    }
}