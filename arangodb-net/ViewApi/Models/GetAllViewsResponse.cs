using System.Collections.Generic;

namespace ArangoDBNet.ViewApi.Models
{
    /// <summary>
    /// Response from <see cref="IViewApiClient.GetAllViewsAsync"/>
    /// </summary>
    public class GetAllViewsResponse : ResponseBase
    {
        /// <summary>
        /// List of views
        /// </summary>
        public List<ViewSummary> Result { get; set; }
    }
}
