using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManagePlatform
    {
        public static Platform Deserialize<T>(string Data)
        {
            try
            {
                Platform a = (Platform)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Platform> DeserializeList<T>(string data)
        {
            try
            {
                List<Platform> L = (List<Platform>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Platform>)
                {
                    return (String)jsonHub.Serialize((List<Platform>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Platform)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Platform> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Platforms.ToList();
            }
        }

        public static bool Insert(Platform p)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Platforms.Add(p);
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

        public static Platform GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Platform s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Platforms.Where(m => m.Platform_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Platform p)
        {
            return GetById(p.Platform_ID) == null ? false : true;
        }

        public static bool Edit(Platform p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("Platform");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(p).State = EntityState.Modified;
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
                    db.Platforms.Remove(db.Platforms.Where(x => x.Platform_ID == ID).FirstOrDefault());
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
