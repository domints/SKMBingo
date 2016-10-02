using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SKMBingo.Models.Api
{
    public class Field
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("isactive")]
        public bool IsActive { get; set; }
        [JsonProperty("number")]
        public int FieldNumber { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
