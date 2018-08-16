using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrioSimulator.Models
{
    public class DeviceInfoModel
    {
        [JsonProperty(PropertyName = "data")]
        public DeviceInfoDataModel data { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }
    }

    public class DeviceInfoDataModel
    {
        [JsonProperty(PropertyName = "ModelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty(PropertyName = "DeviceType")]
        public string DeviceType { get; set; }

        [JsonProperty(PropertyName = "FirmwareRelease")]
        public string FirmwareRelease { get; set; }

        [JsonProperty(PropertyName = "DeviceVendor")]
        public string DeviceVendor { get; set; }

        [JsonProperty(PropertyName = "MACAddress")]
        public string MACAddress { get; set; }

        [JsonProperty(PropertyName = "UpTimeSinceLastReboot")]
        public string UpTimeSinceLastReboot { get; set; }

        [JsonProperty(PropertyName = "IPV4Address")]
        public string IPV4Address { get; set; }

        [JsonProperty(PropertyName = "IPV6Address")]
        public string IPV6Address { get; set; }

        [JsonProperty(PropertyName = "AttachedHardware")]
        public DeviceInfoAttachedHardwareModel AttachedHardware { get; set; }
    }

    public class DeviceInfoAttachedHardwareModel
    {
    }
}
