using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AppVk
{
    public class User
    {
        [JsonPropertyName("first_name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("last_name")]
        public string Surname { get; set; }

        [JsonPropertyName("is_closed")]
        public bool IsClosed { get; set; }
        
        [JsonPropertyName("bdate")]
        public string BDay { get; set; }

        public DateTime BirthDay =>
           DateTime.ParseExact(BDay, "D.M.YYYY", CultureInfo.InvariantCulture);
    }
}
