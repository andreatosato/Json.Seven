using Serializer.App.Attributes;
using System.Reflection;
using System.Text.Json.Serialization.Metadata;

namespace Serializer.App;

public static class JsonSerializerModifiers
{
    public static void MaskMemberAttribute(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
        {
            if (propertyInfo.AttributeProvider is ICustomAttributeProvider provider &&
                provider.IsDefined(typeof(JsonMaskAttribute), inherit: true))
            {
                propertyInfo.Get = (obj) =>
                {
                    var value = obj.GetType()!.GetRuntimeProperty(propertyInfo.Name)!.GetValue(obj);
                    if (value is string)
                    {
                        return new string('*', ((string)value).Length);
                    }
                    return "not string";
                };
            }
        }
    }

}
