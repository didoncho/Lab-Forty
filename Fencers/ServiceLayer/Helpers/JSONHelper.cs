using System.Text.Json;

namespace ServiceLayer.Helpers;

public static class JSONHelper
{
    public static T DeepCopy<T>(T item) where T : class
    {
        var serialezed = JsonSerializer.Serialize(item);
        return JsonSerializer.Deserialize<T>(serialezed);
    }
}