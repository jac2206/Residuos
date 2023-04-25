using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiduosApi.DTO
{
    public class EventoWebHook
    {
        [JsonProperty(Required = Required.Always)]
        public string eventType { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DataHook data { get; set; }
    }
}

