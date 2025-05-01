using System.Text.Json.Nodes;
using System.Text.Json;

namespace MicroTec.Hr.BackendApi.Shared.Helper
{
    public static class LoggingHelper
    {
        private static readonly HashSet<string> SensitiveKeys =
    [
        "password", "token", "accessToken", "refreshToken"
    ];

        public static string MaskSensitiveFields(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return json;

            try
            {
                var node = JsonNode.Parse(json);
                MaskNode(node);
                return node?.ToJsonString(new JsonSerializerOptions { WriteIndented = false }) ?? json;
            }
            catch
            {
                // fallback if it's not valid JSON
                return json;
            }
        }

        private static void MaskNode(JsonNode? node)
        {
            if (node is JsonObject obj)
            {
                foreach (var key in obj.ToList())
                {
                    if (SensitiveKeys.Contains(key.Key.ToLower()))
                    {
                        obj[key.Key] = "***MASKED***";
                    }
                    else
                    {
                        MaskNode(obj[key.Key]);
                    }
                }
            }
            else if (node is JsonArray array)
            {
                foreach (var item in array)
                {
                    MaskNode(item);
                }
            }
        }

        public static IDisposable SetLoggingScope(ILogger logger, params (string key, object value)[] data)
        {
            var dict = data.ToDictionary(kv => kv.key, kv => kv.value);
            return logger.BeginScope(dict)!;
        }
    }
}
