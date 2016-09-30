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
                return (Platform)jsonHub.Deserialize<T>(Data);
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
                return (List<Platform>)jsonHub.Deserialize<T>(data);
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
        public static List<Platform> GetAllPlatforms()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Platforms.ToList();
            }
        }

        public static bool AddPlatform(Platform p)
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

        public static Platform GetPlatformById(int? id)
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

        public static bool IsPlatformExist(Platform p)
        {
            return GetPlatformById(p.Platform_ID) == null ? false : true;
        }

        public static bool EditPlatform(Platform p)
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

        public static bool DeletePlatform(int ID)
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
