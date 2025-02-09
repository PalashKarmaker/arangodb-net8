﻿using System.IO;
using System.Threading.Tasks;

namespace ArangoDBNet.Serialization;

/// <summary>
/// Defines a serialization layer used for the content in transport.
/// </summary>
public interface IApiClientSerialization
{
    /// <summary>
    /// Asynchronously deserializes the data structure contained by the specified stream
    /// into an instance of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="stream">The stream containing the JSON structure to deserialize.</param>
    /// <returns></returns>
    Task<T> DeserializeFromStreamAsync<T>(Stream stream);

    /// <summary>
    /// Asynchronously serializes the specified object to a sequence of bytes,
    /// following the provided rules for camel case property name and null value handling.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="item">The object to serialize.</param>
    /// <param name="serializationOptions">The serialization options. When the value is null the
    /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
    /// <returns></returns>
    Task<byte[]> SerializeAsync<T>(T item, ApiClientSerializationOptions serializationOptions);

    /// <summary>
    /// Asynchronously serializes the specified object to a JSON string,
    /// following the provided rules for camel case property name and null value handling.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="item">The object to serialize.</param>
    /// <param name="serializationOptions">The serialization options. When the value is null the
    /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
    /// <returns></returns>
    Task<string> SerializeToStringAsync<T>(T item, ApiClientSerializationOptions serializationOptions);
}