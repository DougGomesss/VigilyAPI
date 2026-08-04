using System.Text.Json;
using System.Text.Json.Serialization;

namespace VigilyAPI.Models
{
    public class ErrorDetails
    {
        public int? StatusCode { get; set; }
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Trace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
