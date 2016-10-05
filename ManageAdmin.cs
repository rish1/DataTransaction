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
                Admin a = (Admin)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
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
                List<Admin> L = (List<Admin>)jsonHub.Deserialize<T>(data);
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
        public static List<Admin> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Admins.Include(x => x.Role).ToList();
            }
        }

        public static bool Insert(Admin admin)
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

        public static Admin GetByID(int? id)
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

        public bool IsExist(Admin a)
        {
            return GetByID(a.Admin_ID) == null ? false : true;
        }

        public static bool Edit(Admin admin)
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
        public static bool Delete(int ID)
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
