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
        public static Holiday Deserialize<T>(string Data)
        {
            try
            {
                Holiday a = (Holiday)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Holiday> DeserializeList<T>(string data)
        {
            try
            {
                List<Holiday> L = (List<Holiday>)jsonHub.Deserialize<T>(data);
                return L == null ? null : L;
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
                if (o == null) { return null; }
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
        public static List<Holiday> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Holidays.Include(x => x.Segment).ToList();
            }
        }

        public static bool Insert(Holiday h)
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

        public static Holiday GetById(int? id)
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

        public static bool IsExist(Holiday h)
        {
            return GetById(h.Holiday_ID) == null ? false : true;
        }

        public static bool Edit(Holiday h)
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

        public static bool Delete(int ID)
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
