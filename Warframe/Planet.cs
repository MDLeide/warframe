using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Warframe
{
    public class Planet
    {
        public string Name { get; set; }
        public Mission[] Mission { get; set; }
    }

    public class Mission
    {
        public string Name { get; set; }
        public bool IsEvent { get; set; }
        [JsonProperty("gameMode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MissionType MissionType { get; set; }
    }
}
