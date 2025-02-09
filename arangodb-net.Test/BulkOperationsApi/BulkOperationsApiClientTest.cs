﻿using ArangoDBNet;
using ArangoDBNet.BulkOperationsApi;
using ArangoDBNet.BulkOperationsApi.Models;
using System.Threading.Tasks;
using Xunit;

namespace ArangoDBNetTest.BulkOperationsApi
{
    public class BulkOperationsApiClientTest : IClassFixture<BulkOperationsApiClientTestFixture>, IAsyncLifetime
    {
        private IBulkOperationsApiClient _boApi;
        private ArangoDBClient _adb;
        private readonly string _testCollection;
        private readonly ImportDocumentArraysBody _testImportDocumentArraysBody;
        private readonly ImportDocumentObjectsBody<object> _testImportDocumentObjectsBody;
        private readonly string _testImportDocumentArraysJSON;
        private readonly int _testImportDocumentArrayJSONCount;
        private readonly string _testImportDocumentObjectsJSON;
        private readonly int _testImportDocumentObjectJSONCount;
        private readonly string _testImportDocumentObjectsType;

        public BulkOperationsApiClientTest(BulkOperationsApiClientTestFixture fixture)
        {
            _adb = fixture.ArangoDBClient;
            _boApi = _adb.BulkOperations;
            _testCollection = fixture.TestCollectionName;
            _testImportDocumentArraysBody = fixture.TestImportDocumentArraysBody;
            _testImportDocumentObjectsBody = fixture.TestImportDocumentObjectsBody;
            _testImportDocumentArraysJSON = fixture.TestImportDocumentArraysJSON;
            _testImportDocumentObjectsJSON = fixture.TestImportDocumentObjectsJSON;
            _testImportDocumentArrayJSONCount = fixture.TestImportDocumentArrayJSONCount;
            _testImportDocumentObjectJSONCount = fixture.TestImportDocumentObjectJSONCount;
            _testImportDocumentObjectsType = fixture.TestImportDocumentObjectsType;
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task PostImportDocumentArraysAsync_ShouldSucceed()
        {
            var postResponse = await _boApi.PostImportDocumentArraysAsync(
                new ImportDocumentsQuery()
                {
                    Collection = _testCollection
                },
                _testImportDocumentArraysBody);
            Assert.False(postResponse.Error);
        }

        [Fact]
        public async Task PostImportDocumentJSONArraysAsync_ShouldSucceed()
        {
            var postResponse = await _boApi.PostImportDocumentArraysAsync(
                new ImportDocumentsQuery()
                {
                    Collection = _testCollection,
                },
                _testImportDocumentArraysJSON);
            Assert.False(postResponse.Error);
        }

        [Fact]
        public async Task PostImportDocumentObjectsAsync_ShouldSucceed()
        {
            var postResponse = await _boApi.PostImportDocumentObjectsAsync(
                new ImportDocumentsQuery()
                {
                    Collection = _testCollection,
                    Type = _testImportDocumentObjectsType
                },
                _testImportDocumentObjectsBody);
            Assert.False(postResponse.Error);
        }

        [Fact]
        public async Task PostImportDocumentJSONObjectsAsync_ShouldSucceed()
        {
            var postResponse = await _boApi.PostImportDocumentObjectsAsync(
                new ImportDocumentsQuery()
                {
                    Collection = _testCollection,
                    Type = _testImportDocumentObjectsType
                },
                _testImportDocumentObjectsJSON);
            Assert.False(postResponse.Error);
        }
    }
}
