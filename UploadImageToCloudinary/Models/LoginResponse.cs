using Newtonsoft.Json;
using System;

namespace UploadImageToCloudinary.Models
{
    public sealed class LoginResponse
    {
        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "isTemporaryPassword")]
        public bool IsTemporaryPassword { get; set; }
    }
}
