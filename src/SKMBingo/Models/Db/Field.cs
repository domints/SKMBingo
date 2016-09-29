using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Models.Db
{
    [Table("field")]
    public class Field
    {
        [Column("fldid")]
        public int Id { get; set; }
        [Column("fldactive")]
        public bool IsActive { get; set; }
        [Column("fldno")]
        public int FieldNumber { get; set; }
        [Column("fldname")]
        public string Name { get; set; }
    }
}
