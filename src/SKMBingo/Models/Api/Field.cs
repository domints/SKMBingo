using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SKMBingo.Models.Api
{
    public class Field
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "isactive")]
        public bool IsActive { get; set; }
        [DataMember(Name = "number")]
        public int FieldNumber { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
