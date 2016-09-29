using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Models.Db
{
    [Table("bingorecord")]
    public class BingoRecord
    {
        [Column("birid")]
        public int ID { get; set; }
        [Column("birfldid")]
        public int FieldId { get; set; }
        [Column("birdate")]
        public DateTime CreateDate { get; set; }

        public virtual Field Field { get; set; }
    }
}
