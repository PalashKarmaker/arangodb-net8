using ArangoDBNet;
using ArangoDBNet.AdminApi;
using System.Threading.Tasks;
using Xunit;

namespace ArangoDBNetTest.AdminApi;

public class AdminApiClientTest(AdminApiClientTestFixture fixture) : IClassFixture<AdminApiClientTestFixture>, IAsyncLifetime
{
    private IAdminApiClient _adminApi = fixture.ArangoDBClient.Admin;
    private ArangoDBClient _adb = fixture.ArangoDBClient;

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => Task.CompletedTask;

    /// <summary>
    /// Works only on version 3.8 onwards. 
    /// </summary>
    /// <returns></returns>
    [Fact]
    [Trait("ServerVersion", "3_8_PLUS")]
    public async Task GetLogsAsync_ShouldSucceed()
    {
        var getResponse = await _adminApi.GetLogsAsync();
        Assert.NotNull(getResponse);
    }

    [Fact]
    public async Task PostReloadRoutingInfoAsync_ShouldSucceed()
    {
        var postResponse = await _adminApi.PostReloadRoutingInfoAsync();
        Assert.True(postResponse);
    }

    /// <summary>
    /// This test will run only in a cluster
    /// </summary>
    /// <returns></returns>
    [Fact]
    [Trait("RunningMode", "Cluster")]
    public async Task GetServerIdAsync_ShouldSucceed()
    {
        var getResponse = await _adminApi.GetServerIdAsync();
        Assert.NotNull(getResponse);
        Assert.False(getResponse.Error);
        Assert.NotNull(getResponse.Id);
    }

    [Fact]
    public async Task GetServerRoleAsync_ShouldSucceed()
    {
        var getResponse = await _adminApi.GetServerRoleAsync();
        Assert.NotNull(getResponse);
        Assert.False(getResponse.Error);
        Assert.NotNull(getResponse.Role);
    }

    [Fact]
    public async Task GetServerEngineTypeAsync_ShouldSucceed()
    {
        var getResponse = await _adminApi.GetServerEngineTypeAsync();
        Assert.NotNull(getResponse);
        Assert.NotNull(getResponse.Name);
    }

    [Fact]
    public async Task GetServerVersionAsync_ShouldSucceed()
    {
        var getResponse = await _adminApi.GetServerVersionAsync();
        Assert.NotNull(getResponse);
        Assert.NotNull(getResponse.License);
        Assert.NotNull(getResponse.Version);
        Assert.NotNull(getResponse.Server);
    }

    /// <summary>
    /// Works only on version 3.9 onwards. 
    /// </summary>
    /// <returns></returns>
    [Fact]
    [Trait("ServerVersion", "3_9_PLUS")]
    public async Task GetLicenseAsync_ShouldSucceed()
    {
        var getResponse = await _adminApi.GetLicenseAsync();
        Assert.NotNull(getResponse);
    }
}