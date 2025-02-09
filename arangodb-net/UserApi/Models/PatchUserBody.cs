﻿using System.Collections.Generic;

namespace ArangoDBNet.UserApi.Models
{
    /// <summary>
    /// Represents a request body to update an existing user.
    /// </summary>
    public class PatchUserBody
    {
        /// <summary>
        /// The user password. Specifying a password is mandatory,
        /// but the empty string is allowed for passwords.
        /// </summary>
        public string Passwd { get; set; }

        /// <summary>
        /// An optional flag that specifies whether the user is active.
        /// If not specified, this will default to true.
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Optional object with arbitrary extra data about the user.
        /// </summary>
        public Dictionary<string, object> Extra { get; set; }
    }
}
