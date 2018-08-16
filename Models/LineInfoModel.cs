using Newtonsoft.Json;

namespace TrioSimulator.Models
{
    public class LineInfoModel
    {
        [JsonProperty(PropertyName = "data")]
        public LineInfoDataModel data { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }
    }

    public class LineInfoDataModel
    {
        [JsonProperty(PropertyName = "LineNumber")]
        public string LineNumber { get; set; }

        [JsonProperty(PropertyName = "RegistrationStatus")]
        public string RegistrationStatus { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public string UserID { get; set; }

        [JsonProperty(PropertyName = "Label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "LineType")]
        public string LineType { get; set; }

        [JsonProperty(PropertyName = "SIPAddress")]
        public string SIPAddress { get; set; }

        [JsonProperty(PropertyName = "Port")]
        public string Port { get; set; }

        [JsonProperty(PropertyName = "Protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "ProxyAddress")]
        public string ProxyAddress { get; set; }
    }
}
