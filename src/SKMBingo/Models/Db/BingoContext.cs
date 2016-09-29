using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Models.Db
{
    public class BingoContext : DbContext
    {
        public BingoContext(DbContextOptions<BingoContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<BingoRecord> Records { get; set; }
    }
}
