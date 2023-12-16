using System.Text.Json.Serialization;

namespace backend.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Roles
    {
        Admin,
        Tutor,
        Student
    }

}