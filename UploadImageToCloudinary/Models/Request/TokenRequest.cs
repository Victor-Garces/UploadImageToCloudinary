using System;

namespace UploadImageToCloudinary.Models
{
    public sealed class TokenRequest
    {
        /// <summary>
        /// A school's identification
        /// </summary>
        public Guid SchoolId { get; set; }

        /// <summary>
        /// A profile identification
        /// </summary>
        public Guid Identification { get; set; }

        /// <summary>
        /// A role's identification
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// A user a identification
        /// </summary>
        public Guid UserId { get; set; }
    }
}
