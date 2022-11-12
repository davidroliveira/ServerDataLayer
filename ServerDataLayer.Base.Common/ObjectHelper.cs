using FluentAssertions;
using Newtonsoft.Json;

namespace ServerDataLayer.Base.Common;

public static class ObjectHelper
{
    public static bool Compare(this object self, object other)
    {
        var selfJson = SerializeObject(self);
        var otherJson = SerializeObject(other);
        selfJson.Should().BeEquivalentTo(otherJson);
        return true;
    }

    public static string SerializeObject(this object self) => JsonConvert.SerializeObject(self);
}