using ArangoDB.VelocyPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ArangoDBNet.Serialization;

public class VelocyPackApiClientSerialization : ApiClientSerialization
{
    /// <summary>
    /// Deserializes the JSON structure contained by the specified stream
    /// into an instance of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="stream">The stream containing the JSON structure to deserialize.</param>
    /// <returns></returns>
    public override T DeserializeFromStream<T>(Stream stream)
    {
        if (stream == null || !stream.CanRead)
            return default;
        using var sr = new StreamReader(stream);
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        var result = VPack.Deserialize<T>(ms.ToArray());
        return result;
    }

    /// <summary>
    /// Asynchronously deserializes the data structure contained by the specified stream
    /// into an instance of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="stream">The stream containing the JSON structure to deserialize.</param>
    /// <returns></returns>
    public override async Task<T> DeserializeFromStreamAsync<T>(Stream stream)
    {
        if (stream == null || !stream.CanRead)
            return default;
        using var sr = new StreamReader(stream);
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms).ConfigureAwait(false);
        var result = VPack.Deserialize<T>(ms.ToArray());
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="serializationOptions">The serialization options. When the value is null the
    /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
    /// <returns></returns>

    public override byte[] Serialize<T>(T item, ApiClientSerializationOptions serializationOptions) => 
        VPack.Serialize(item);

    /// <summary>
    /// Asynchronously serializes the specified object to a sequence of bytes,
    /// following the provided rules for camel case property name and null value handling.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="item">The object to serialize.</param>
    /// <param name="serializationOptions">The serialization options. When the value is null the
    /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
    /// <returns></returns>
    public override async Task<byte[]> SerializeAsync<T>(T item, ApiClientSerializationOptions serializationOptions)
    {
        var result = Task.Run(() => Serialize(item, serializationOptions));
        return await result.ConfigureAwait(false);
    }

    /// <summary>
    /// Serializes an object to JSON string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="serializationOptions">The serialization options. When the value is null the
    /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
    /// <returns></returns>

    public override string SerializeToString<T>(T item, ApiClientSerializationOptions serializationOptions)
    {
        // When no options passed use the default.
        serializationOptions ??= DefaultOptions;

        var jsonSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = serializationOptions.IgnoreMissingMember ? MissingMemberHandling.Ignore : MissingMemberHandling.Error,
            NullValueHandling = serializationOptions.IgnoreNullValues ? NullValueHandling.Ignore : NullValueHandling.Include
        };

        if (serializationOptions.UseStringEnumConversion)
        {
            var stringEnumConverter = new StringEnumConverter();
            jsonSettings.Converters.Add(stringEnumConverter);
        }

        if (serializationOptions.UseCamelCasePropertyNames)
            jsonSettings.ContractResolver = new CamelCasePropertyNamesExceptDictionaryContractResolver(serializationOptions);

        string json = JsonConvert.SerializeObject(item, jsonSettings);

        return json;
    }

    /// <summary>
    /// Asynchronously serializes the specified object to a JSON string,
    /// following the provided rules for camel case property name and null value handling.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="item">The object to serialize.</param>
    /// <param name="serializationOptions">The serialization options. When the value is null the
    /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
    /// <returns></returns>
    public override async Task<string> SerializeToStringAsync<T>(T item, ApiClientSerializationOptions serializationOptions)
    {
        var result = SerializeToString(item, serializationOptions);
        return await Task.FromResult(result);
    }
}
