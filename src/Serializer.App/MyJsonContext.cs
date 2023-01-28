using Serializer.App.Entities;
using System.Text.Json.Serialization;

namespace Serializer.App;

[JsonSerializable(typeof(Person))]
[JsonSerializable(typeof(Vote))]
[JsonSerializable(typeof(LupinManager), GenerationMode = JsonSourceGenerationMode.Serialization)]
internal partial class MyJsonContext : JsonSerializerContext
{
}
