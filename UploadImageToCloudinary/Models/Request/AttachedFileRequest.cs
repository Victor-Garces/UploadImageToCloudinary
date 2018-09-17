using System;

namespace UploadImageToCloudinary
{
    /// <summary>
    /// Represents the request model for an attached file.
    /// </summary>
    public sealed class AttachedFileRequest
    {
        /// <summary>
        /// Uploaded  date
        /// </summary>
        public DateTime UploadDate { get; } = DateTime.Now;

        /// <summary>
        /// A base-64 string cointaing the file
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Type of the file
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Image format
        /// </summary>
        public string Format { get; set; }
    }
}
