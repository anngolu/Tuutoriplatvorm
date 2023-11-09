// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Text.Json.Serialization;
// using Microsoft.EntityFrameworkCore;

// namespace backend.Model
// {
//     public class Subjects
//     {
//         public int? Id { get; init; }
//         public List<SubjectList>? Subject {get;init;} 

//          public Subjects()
//         {
//             Subject = new List<SubjectList>();
//         }
        
//     }

//         [JsonConverter(typeof(JsonStringEnumConverter))]
//         public enum SubjectList {
            
//             Economics = 1,
//             Maths = 2,
//             Programming = 3,
//             Startup = 4,
//             PE = 5,
//             DiscMaths = 6,

//         }
// }