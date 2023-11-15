using System.Text.Json.Serialization;

namespace backend.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Subject
    {

        Economics = 1,
        Maths = 2,
        Programming = 3,
        Startup = 4,
        PE = 5,
        DiscMaths = 6,

    }


}