using SKMBingo.Models.Api;
using SKMBingo.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Services
{
    public interface IRecordService
    {
        IEnumerable<Record> GetAll();
        IEnumerable<Record> GetForDay(DateTime day);
        bool Check(int id);
        bool Uncheck(int id);
    }

    public class RecordService : IRecordService
    {
        BingoContext cx;

        public RecordService(BingoContext context)
        {
            cx = context;
        }

        public bool Check(int id)
        {
            if(GetForDay(DateTime.Today).Any(r => r.FieldId == id))
            {
                return false;
            }
            else
            {
                cx.Records.Add(new BingoRecord
                {
                    CreateDate = DateTime.Now,
                    FieldId = id
                });
                cx.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Record> GetAll()
        {
            return cx.Records.Select(r => new Record
            {
                Id = r.ID,
                FieldId = r.FieldId,
                Date = r.CreateDate
            });
        }

        public IEnumerable<Record> GetForDay(DateTime day)
        {
            DateTime start = day.Date;
            DateTime end = start.AddHours(23).AddMinutes(59).AddSeconds(59);
            return cx.Records.Where(r => r.CreateDate >= start && r.CreateDate <= end).Select(r => new Record
            {
                Id = r.ID,
                FieldId = r.FieldId,
                Date = r.CreateDate
            });
        }

        public bool Uncheck(int id)
        {
            BingoRecord br = cx.Records.FirstOrDefault(r => r.ID == id);
            if(br != null)
            {
                cx.Records.Remove(br);
                cx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
