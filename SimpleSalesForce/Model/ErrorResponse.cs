using Newtonsoft.Json;

namespace Simple.Salesforce
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "message")]
        public string Message;

        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode;
    }
}
