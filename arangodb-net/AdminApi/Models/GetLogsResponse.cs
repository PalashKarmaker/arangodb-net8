﻿using System.Collections.Generic;

namespace ArangoDBNet.AdminApi.Models
{
    /// <summary>
    /// Returned by <see cref="IAdminApiClient.GetLogsAsync"/>
    /// </summary>
    public class GetLogsResponse
    {
        /// <summary>
        /// The total amount of log entries before pagination
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// List of log messages that matched the criteria
        /// </summary>
        public List<LogMessage> Messages { get; set; }
    }
}