using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResiduosApi.DTO
{
    public class EventSend
    {
        [JsonPropertyName("event")]
        public string Event { get; set; }
        public Payload payload { get; set; }
    }
}
