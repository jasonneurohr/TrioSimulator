using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrioSimulator.Models
{
    public class CallStatusModel
    {
        [JsonProperty(PropertyName = "data")]
        public CallStatusDataModel data { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }
    }

    public class CallStatusDataModel
    {
        [JsonProperty(PropertyName = "LineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "CallHandle")]
        public string CallHandle { get; set; }

        [JsonProperty(PropertyName = "RemotePartyName")]
        public string RemotePartyName { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "CallState")]
        public string CallState { get; set; }

        [JsonProperty(PropertyName = "RemotePartyNumber")]
        public string RemotePartyNumber { get; set; }

        [JsonProperty(PropertyName = "DurationInSeconds")]
        public string DurationInSeconds { get; set; }
    }
}
