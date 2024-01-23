using ArangoDBNet.AdminApi;
using ArangoDBNet.AnalyzerApi;
using ArangoDBNet.AqlFunctionApi;
using ArangoDBNet.AuthApi;
using ArangoDBNet.BulkOperationsApi;
using ArangoDBNet.CollectionApi;
using ArangoDBNet.CursorApi;
using ArangoDBNet.DatabaseApi;
using ArangoDBNet.DocumentApi;
using ArangoDBNet.GraphApi;
using ArangoDBNet.IndexApi;
using ArangoDBNet.PregelApi;
using ArangoDBNet.TransactionApi;
using ArangoDBNet.UserApi;
using ArangoDBNet.ViewApi;
using System;

namespace ArangoDBNet
{
    public interface IArangoDBClient : IDisposable
    {
        /// <summary>
        /// AQL user functions management API.
        /// </summary>
        IAqlFunctionApiClient AqlFunction { get; }

        /// <summary>
        /// Auth API
        /// </summary>
        IAuthApiClient Auth { get; }

        /// <summary>
        /// Cursor API
        /// </summary>
        ICursorApiClient Cursor { get; }

        /// <summary>
        /// Database API
        /// </summary>
        IDatabaseApiClient Database { get; }

        /// <summary>
        /// Document API
        /// </summary>
        IDocumentApiClient Document { get; }

        /// <summary>
        /// Collection API
        /// </summary>
        ICollectionApiClient Collection { get; }

        /// <summary>
        /// Transaction API
        /// </summary>
        ITransactionApiClient Transaction { get; }

        /// <summary>
        /// Graph API
        /// </summary>
        IGraphApiClient Graph { get; }

        /// <summary>
        /// User management API
        /// </summary>
        IUserApiClient User { get; }

        /// <summary>
        /// Index management API
        /// </summary>
        IIndexApiClient Index { get; }

        /// <summary>
        /// Bulk Operations API
        /// </summary>
        IBulkOperationsApiClient BulkOperations { get; }

        /// <summary>
        /// View management API
        /// </summary>
        IViewApiClient View { get; }

        /// <summary>
        /// Analyzer managemet API
        /// </summary>
        IAnalyzerApiClient Analyzer { get; }

        /// <summary>
        /// Admin API
        /// </summary>
        IAdminApiClient Admin { get; }

        /// <summary>
        /// Pregel API
        /// </summary>
        IPregelApiClient Pregel { get; }
    }
}