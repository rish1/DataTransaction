using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageModules
    {
        public static AppModule Deserialize<T>(string Data)
        {
            try
            {
                return (AppModule)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<AppModule> DeserializeList<T>(string data)
        {
            try
            {
                return (List<AppModule>)jsonHub.Deserialize<T>(data);
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
                if (o is List<AppModule>)
                {
                    return (String)jsonHub.Serialize((List<AppModule>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((AppModule)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<AppModule> GetAllAppModules()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.AppModules.ToList();
            }
        }

        public static bool AddModule(AppModule mod)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.AppModules.Add(mod);
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

        public static AppModule getModuleById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                AppModule s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.AppModules.Where(m => m.Module_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool AppmoduleExist(AppModule mod)
        {
            return getModuleById(mod.Module_ID) == null ? false : true;
        }

        public static bool EditAppModule(AppModule mod)
        {
            if (mod == null)
            {
                throw new ArgumentNullException("Module");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(mod).State = EntityState.Modified;
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

        public static bool DeleteModule(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.AppModules.Remove(db.AppModules.Where(x => x.Module_ID == ID).FirstOrDefault());
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
