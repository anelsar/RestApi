using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestApiData.Models
{
    public class Field
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
     
    public class Metadata
    {
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
        
    }

    public class RootInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
