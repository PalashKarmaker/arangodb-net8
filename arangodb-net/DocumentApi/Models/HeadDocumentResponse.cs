using System.Net;
using System.Net.Http.Headers;

namespace ArangoDBNet.DocumentApi.Models
{
    public class HeadDocumentResponse
    {
        public HttpStatusCode Code { get; set; }

        public EntityTagHeaderValue Etag { get; set; }
    }
}
