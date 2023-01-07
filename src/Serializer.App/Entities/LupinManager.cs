using Serializer.App.Attributes;

namespace Serializer.App.Entities;

public class LupinManager
{
    public string Address { get; set; } = null!;

    [JsonMask]
    public string PassCode { get; set; } = null!;
}
