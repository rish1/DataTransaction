using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOffice
    {
        public static Office Deserialize<T>(string Data)
        {
            try
            {
                return (Office)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Office> DeserializeList<T>(string data)
        {
            try
            {
                return (List<Office>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Office>)
                {
                    return (String)jsonHub.Serialize((List<Office>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Office)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Office> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Offices.ToList();
            }
        }

        public static bool Insert(Office o)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Offices.Add(o);
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

        public static Office GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Office s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Offices.Where(m => m.Office_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Office o)
        {
            return GetById(o.Office_ID) == null ? false : true;
        }

        public static bool Edit(Office o)
        {
            if (o == null)
            {
                throw new ArgumentNullException("Office");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(o).State = EntityState.Modified;
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
                    db.Offices.Remove(db.Offices.Where(x => x.Office_ID == ID).FirstOrDefault());
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
