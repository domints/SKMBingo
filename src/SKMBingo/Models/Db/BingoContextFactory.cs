using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Models.Db
{
    public class BingoContextFactory : IDbContextFactory<BingoContext>
    {
        public BingoContext Create()
        {
            var builder = new DbContextOptionsBuilder<BingoContext>();
            builder.UseNpgsql(Startup.ConnString);
            return new BingoContext(builder.Options);
        }

        public BingoContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<BingoContext>();
            builder.UseNpgsql(Startup.ConnString);
            return new BingoContext(builder.Options);
        }
    }
}
