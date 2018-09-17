using Newtonsoft.Json;

namespace UploadImageToCloudinary.Models
{
    public sealed class UserProfile
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public long Expires { get; set; }
    }
}
