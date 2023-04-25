using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResiduosApi.DTO
{
    public class DataHook
    {
        [JsonProperty(Required = Required.Always)]
        public string id { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string sellerId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string sellerName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string date { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string eventType { get; set; }
        public ItemData[] items { get; set; }
    }
}
