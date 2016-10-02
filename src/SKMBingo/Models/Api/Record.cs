using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Models.Api
{
    public class Record
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("fldid")]
        public int FieldId { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
