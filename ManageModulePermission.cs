using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageModulePermission
    {
        public static ModulePermission Deserialize<T>(string Data)
        {
            try
            {
                ModulePermission a = (ModulePermission)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<ModulePermission> DeserializeList<T>(string data)
        {
            try
            {
                List<ModulePermission> L = (List<ModulePermission>)jsonHub.Deserialize<T>(data);
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
                if (o is List<ModulePermission>)
                {
                    return (String)jsonHub.Serialize((List<ModulePermission>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((ModulePermission)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<ModulePermission> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.ModulePermissions.Include(x => x.AppModule).Include(x => x.User).ToList();
            }
        }

        public static bool Insert(ModulePermission mp)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.ModulePermissions.Add(mp);
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

        public static ModulePermission GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                ModulePermission s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.ModulePermissions.Where(m => m.Module_Permission_ID == id).Include(x=>x.AppModule).Include(x=>x.User).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(ModulePermission mp)
        {
            return GetById(mp.Module_Permission_ID) == null ? false : true;
        }

        public static bool Edit(ModulePermission mp)
        {
            if (mp == null)
            {
                throw new ArgumentNullException("Nodule Permission");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(mp).State = EntityState.Modified;
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
                    db.ModulePermissions.Remove(db.ModulePermissions.Where(x => x.Module_Permission_ID == ID).FirstOrDefault());
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
