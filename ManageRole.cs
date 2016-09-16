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
        public static List<Role> getAllRoles()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Roles.ToList();
            }
        }

        public static bool AddRole(Role r)
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
        public static Role GetRoleById(int? id)
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
        public static bool IsRoleExist(Role r)
        {
            return GetRoleById(r.Role_ID) == null ? false : true;
        }
        public static bool EditRole(Role r)
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
        public static bool  DeleteRole(int ID)
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
