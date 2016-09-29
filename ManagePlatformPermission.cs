using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManagePlatformPermission
    {
        public static PlatformPermission Deserialize(string Data)
        {
            try
            {
                return (PlatformPermission)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<PlatformPermission> DeserializeList(string data)
        {
            try
            {
                return (List<PlatformPermission>)jsonHub.Deserialize(data);
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
                if (o is List<PlatformPermission>)
                {
                    return (String)jsonHub.Serialize((List<PlatformPermission>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((PlatformPermission)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<PlatformPermission> GetAllPlatformPermissions()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.PlatformPermissions.Include(x => x.User).Include(x => x.Platform).ToList();
            }
        }

        public static bool AddPlatformPermission(PlatformPermission pp)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.PlatformPermissions.Add(pp);
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

        public static PlatformPermission GetPlatformPermissionById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                PlatformPermission s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.PlatformPermissions.Where(m => m.Platform_Permission_ID == id).Include(x=>x.User).Include(x=>x.Platform).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsPlatformPermissionExist(PlatformPermission pp)
        {
            return GetPlatformPermissionById(pp.Platform_Permission_ID) == null ? false : true;
        }

        public static bool EditPlatformPermission(PlatformPermission pp)
        {
            if (pp == null)
            {
                throw new ArgumentNullException("Platform Permission");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(pp).State = EntityState.Modified;
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

        public static bool DeletePlatformPermission(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.PlatformPermissions.Remove(db.PlatformPermissions.Where(x => x.Platform_Permission_ID == ID).FirstOrDefault());
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
