using System.Text.Json;

namespace ServerDataLayer.Base.Common;

public static class JsonElementHelper
{
    public static object? ToObject(this JsonElement self)
    {
        switch (self.ValueKind)
        {
            case JsonValueKind.String:
                if (self.TryGetDateTime(out var datetime))
                    return datetime;
                if (self.TryGetGuid(out var guid))
                    return guid;
                return self.GetString();
            case JsonValueKind.Number:
                if (self.TryGetInt64(out var valor))
                    return valor;
                return self.GetDouble();
            case JsonValueKind.True:
                return true;
            case JsonValueKind.False:
                return false;
            case JsonValueKind.Object:
            case JsonValueKind.Array:
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
                return null;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}