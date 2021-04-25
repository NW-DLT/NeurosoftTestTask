using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsListApp.Models;

namespace OptionsListApp.Models
{
    public static class DataWorker
    {
        public static List<MoreOption> GetAllOpt()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.MoreOption.ToList();
                return result;
            }
        }

        public static List<MoreOptionType> GetAllOptType()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.MoreOptionType.ToList();
                return result;
            }
        }

        public static List<Value> GetValues(int OptID)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Values.Where(v => v.MoreOptionID == OptID).ToList();
                return result;
            }
        }
        public static List<Value> GetAllValues()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Values.ToList();
                return result;
            }
        }

        public static void CreateOpt(string title,MoreOptionType moreOptionType)
        {
            using (AppDbContext db = new AppDbContext())
            {
                MoreOption newMoreOption = new MoreOption { Title = title, MoreOptionTypeID = moreOptionType.MoreOptionTypeID, MoreOptionType = moreOptionType, Values = null};
                db.MoreOptionType.Attach(moreOptionType);
                db.MoreOption.Add(newMoreOption);
                db.SaveChanges();
            }
            
        }

        public static void CreatValue(string valueName,int OptID)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Value value = new Value { ValueName = valueName, MoreOptionID = OptID };
                db.Values.Add(value);
                db.SaveChanges();
            }
        }

        public static MoreOptionType GetMoreOptionTypeByID(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                MoreOptionType moreOptionType = db.MoreOptionType.FirstOrDefault(m => m.MoreOptionTypeID == id);
                return  moreOptionType;
            }
        }

        public static void DeleteOpt(MoreOption moreOption)
        {
            using(AppDbContext db = new AppDbContext())
            {
                db.MoreOption.Remove(moreOption);
                db.SaveChanges();
            }
        }

        public static void DeleteValue(Value value)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Values.Remove(value);
                db.SaveChanges();
            }
        }

        public static void EditOpt(MoreOption moreOption, string newTitle, MoreOptionType moreOptionType)
        {
            using (AppDbContext db = new AppDbContext())
            {
                MoreOption moreOption1 = db.MoreOption.FirstOrDefault(d => d.MoreOptionID == moreOption.MoreOptionID);
                moreOption1.Title = newTitle;
                moreOption1.MoreOptionType = moreOptionType;
                moreOption1.MoreOptionTypeID = moreOptionType.MoreOptionTypeID;
                db.MoreOptionType.Attach(moreOptionType);
                db.SaveChanges();
            }
        }

        public static void EditValue(string valueName, Value value)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Value value1 = db.Values.FirstOrDefault(v => v.ValueID == value.ValueID);
                value1.ValueName = valueName;
                db.SaveChanges();
            }
        }

        //вверх

        //вниз
    }
}
