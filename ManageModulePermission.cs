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

        public static List<ModulePermission> GetAllModulePermission()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.ModulePermissions.Include(x => x.AppModule).Include(x => x.User).ToList();
            }
        }

        public static bool AddModulePermission(ModulePermission mp)
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

        public static ModulePermission GetModulePermissionById(int? id)
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

        public static bool IsModulePermissionExist(ModulePermission mp)
        {
            return GetModulePermissionById(mp.Module_Permission_ID) == null ? false : true;
        }

        public static bool EditModulePermission(ModulePermission mp)
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

        public static bool DeleteModulePermission(int ID)
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
