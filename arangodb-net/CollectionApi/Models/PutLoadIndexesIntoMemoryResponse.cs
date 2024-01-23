namespace ArangoDBNet.CollectionApi.Models
{
    public class PutLoadIndexesIntoMemoryResponse : ResponseBase
    {
        /// <summary>
        /// Indicates whether the operation
        /// was successful or not.
        /// </summary>
        public bool Result { get; set; }
    }
}