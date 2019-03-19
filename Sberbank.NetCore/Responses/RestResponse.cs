using Newtonsoft.Json;

namespace Sberbank.NetCore.Responses
{
    public class RestResponse
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        public RestResponse()
        {
            ErrorCode = 0;
            ErrorMessage = string.Empty;
        }

        public bool IsSuccess => 0 == ErrorCode;
        public bool ISFail => !IsSuccess;
    }
}
