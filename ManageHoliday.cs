using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageHoliday
    {
        public static Holiday Deserialize(string Data)
        {
            try
            {
                return (Holiday)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Holiday> DeserializeList(string data)
        {
            try
            {
                return (List<Holiday>)jsonHub.Deserialize(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static string Serialize(Object o)
        {
            try
            {
                if (o is List<Holiday>)
                {
                    return (String)jsonHub.Serialize((List<Holiday>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Holiday)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Holiday> GetAllHolidays()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Holidays.Include(x => x.Segment).ToList();
            }
        }

        public static bool AddHoliday(Holiday h)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Holidays.Add(h);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static Holiday GetHolidayById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Holiday s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Holidays.Where(m => m.Holiday_ID == id).Include(x=>x.Segment).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsHolidayExist(Holiday h)
        {
            return GetHolidayById(h.Holiday_ID) == null ? false : true;
        }

        public static bool EditHoliday(Holiday h)
        {
            if (h == null)
            {
                throw new ArgumentNullException("Holiday");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(h).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool DeleteHoliday(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Holidays.Remove(db.Holidays.Where(x => x.Holiday_ID == ID).FirstOrDefault());
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
