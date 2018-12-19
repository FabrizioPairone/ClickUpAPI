using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Enums;
using System;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model Object of User information response
    /// </summary>
    public class ModelUser : Model
    {

        /// <summary>
        /// Id of the User
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Username of the User
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Theme Color selected by the User
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// The url of the Profile Picture of the user
        /// </summary>
        [JsonProperty("profilePicture")]
        public string ProfilePicture { get; set; }

        /// <summary>
        /// Initials of the User
        /// </summary>
        [JsonProperty("initials")]
        public string Initials { get; set; }

        /// <summary>
        /// The start day of the Week setted by the user
        /// </summary>
        [JsonProperty("week_start_day")]
        public DayOfWeek? WeekStartDay { get; set; }

        /// <summary>
        /// Check if user support global font
        /// </summary>
        [JsonProperty("global_font_support")]
        public bool? GlobalFontSupport { get; set; }

        /// <summary>
        /// Role of the user
        /// </summary>
        [JsonProperty("role")]
        public UserRole? Role { get; set; }

    }

}
