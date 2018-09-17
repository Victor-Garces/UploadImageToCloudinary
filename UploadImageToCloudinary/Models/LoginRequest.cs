namespace UploadImageToCloudinary.Models
{
    /// <summary>
    /// Represents a login model for authentication
    /// </summary>
    public sealed class LoginRequest
    {
        /// <summary>
        /// Represent an user email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// An user password
        /// </summary>
        public string Password { get; set; }
    }
}
