using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using DataTransaction;
using Newtonsoft.Json;

namespace DataTransaction
{

    public class ManageAdmin
    {
         
        //ef_manager_newEntities db = new ef_manager_newEntities();
        public static Admin Deserialize<T>(string Data)
        {
            try
            {
                return (Admin)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Admin> DeserializeList<T>(string data)
        {
            try
            {
                return (List<Admin>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Admin>)
                {
                    return (String)jsonHub.Serialize((List<Admin>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Admin)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Admin> getAllAdmins()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Admins.Include(x => x.Role_ID).ToList();
            }
        }

        public static bool InsertAdmin(Admin admin)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Admins.Add(admin);
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

        public static Admin getAdminByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Admin s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Admins.Where(m => m.Admin_ID == id).Include(x=>x.Role).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool adminExist(Admin a)
        {
            return getAdminByID(a.Admin_ID) == null ? false : true;
        }

        public static bool EditAdmin(Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException("admin");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(admin).State = EntityState.Modified;
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
        public static bool DeleteAdmin(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Admins.Remove(db.Admins.Where(x => x.Admin_ID== ID).FirstOrDefault());
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
