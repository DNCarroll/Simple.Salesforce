using Newtonsoft.Json;

namespace Simple.Salesforce
{
    public class SuccessResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "success")]
        public bool Success;

        [JsonProperty(PropertyName = "errors")]
        public object Errors;
    }
}

