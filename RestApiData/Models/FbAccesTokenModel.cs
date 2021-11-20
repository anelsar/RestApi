using Newtonsoft.Json;

namespace RestApiData.Models
{

    public class AccesToken
    {
        public AccesToken() { }

        [JsonProperty("access_token")]
        public string AccessToken{ get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
    }

}
