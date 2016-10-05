using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransaction
{
   public class ManageAppModules
    {
        public static AppModule Deserialize<T>(string Data)
        {
            try
            {
                AppModule a = (AppModule)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
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
                List<AppModule> L = (List<AppModule>)jsonHub.Deserialize<T>(data);
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
        public static List<AppModule> GetAllAppModule()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.AppModules.ToList();
            }
        }

        public static bool InsertAppModule(AppModule appmodule)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.AppModules.Add(appmodule);
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

        public static AppModule GetAppModuleByID(int? id)
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

        public bool IsExistAppModule(AppModule a)
        {
            return GetAppModuleByID(a.Module_ID) == null ? false : true;
        }

        public static bool EditAppModule(AppModule appmodule)
        {
            if (appmodule == null)
            {
                throw new ArgumentNullException("App Module");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(appmodule).State = EntityState.Modified;
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
        public static bool DeleteAppModule(int ID)
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
