using SKMBingo.Models;
using SKMBingo.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKMBingo.Services
{
    public interface IFieldService
    {
        IEnumerable<Models.Api.Field> GetFields(bool withDeleted = false);
        Models.Api.Field GetSingle(int id);
        int AddField(Models.Api.Field field);
        bool Update(int id, Models.Api.Field fld);
        bool Deactivate(int id);
        int Activate(int id);
    }

    public class FieldService : IFieldService
    {
        BingoContext cx;
        public FieldService(BingoContext context)
        {
            cx = context;
        }

        public IEnumerable<Models.Api.Field> GetFields(bool withDeleted = false)
        {
            return cx.Fields.Where(f => withDeleted || f.IsActive).Select(f => new Models.Api.Field
            {
                Id = f.Id,
                IsActive = f.IsActive,
                FieldNumber = f.FieldNumber,
                Name = f.Name
            });
        }

        public Models.Api.Field GetSingle(int id)
        {
            Field fld = cx.Fields.FirstOrDefault(f => f.Id == id);
            if(fld == null)
            {
                return null;
            }
            else
            {
                return new Models.Api.Field
                {
                    Id = fld.Id,
                    IsActive = fld.IsActive,
                    FieldNumber = fld.FieldNumber,
                    Name = fld.Name
                };
            }
        }

        public int AddField(Models.Api.Field field)
        {
            try
            {
                if (cx.Fields.Any(f => f.IsActive && f.FieldNumber == field.FieldNumber))
                {
                    return -2;
                }

                Field newField = new Field
                {
                    Name = field.Name,
                    IsActive = field.IsActive,
                    FieldNumber = field.FieldNumber
                };

                cx.Fields.Add(newField);
                cx.SaveChanges();
                return newField.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(int id, Models.Api.Field fld)
        {
            Field dbField = cx.Fields.FirstOrDefault(f => f.Id == id);
            if(dbField == null)
            {
                return false;
            }

            dbField.FieldNumber = fld.FieldNumber;
            dbField.IsActive = fld.IsActive;
            dbField.Name = fld.Name;
            cx.SaveChanges();
            return true;
        }

        public bool Deactivate(int id)
        {
            Field fld = cx.Fields.FirstOrDefault(f => f.Id == id);
            if (fld == null)
            {
                return false;
            }

            if (fld.IsActive)
            {
                fld.IsActive = false;
                cx.SaveChanges();
                return true;
            }
            else
            {
                return true;
            }
        }

        public int Activate(int id)
        {
            Field fld = cx.Fields.FirstOrDefault(f => f.Id == id);
            if(fld == null)
            {
                return 0;
            }

            if(cx.Fields.Any(f => f.IsActive && f.FieldNumber == fld.FieldNumber))
            {
                return -1;
            }
            else
            {
                if (!fld.IsActive)
                {
                    fld.IsActive = true;
                    cx.SaveChanges();
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}