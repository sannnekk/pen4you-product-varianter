using System.Text.Json;

namespace ProductVarianter.Helpers
{
    public static class JsonConverter
    {
        public static T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}