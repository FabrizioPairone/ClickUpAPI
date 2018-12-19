using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Error
{

    /// <summary>
    /// Response Class of Error 401
    /// </summary>
    public class ResponseError401 : ResponseError
    {

        /// <summary>
        /// Message of the Error
        /// </summary>
        [JsonProperty("err")]
        public string Err { get; set; }

        /// <summary>
        /// Status of Http Request
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Code of the Error
        /// </summary>
        [JsonProperty("ECODE")]
        public string ECode { get; set; }

    }

}
