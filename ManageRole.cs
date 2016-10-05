using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageRole
    {
        public static Role Deserialize<T>(string Data)
        {
            try
            {
                Role a = (Role)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Role> DeserializeList<T>(string data)
        {
            try
            {
                List<Role> L = (List<Role>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Role>)
                {
                    return (String)jsonHub.Serialize((List<Role>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Role)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Role> getAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Roles.ToList();
            }
        }

        public static bool Insert(Role r)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Roles.Add(r);
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
        public static Role GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try {
                Role s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Roles.Where(m => m.Role_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static bool IsExist(Role r)
        {
            return GetById(r.Role_ID) == null ? false : true;
        }
        public static bool Edit(Role r)
        {
            if (r == null)
            {
                throw new ArgumentNullException("Role");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(r).State = EntityState.Modified;
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
        public static bool  Delete(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Roles.Remove(db.Roles.Where(x=>x.Role_ID==ID).FirstOrDefault());
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
