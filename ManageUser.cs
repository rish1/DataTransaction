using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
   public class ManageUser
    {
        
        public static List<User> GetAllUsers()
        {
            using(ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Users.ToList();
            }
        }

        public static bool AddUser(User u)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Users.Add(u);
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

        public static User GetUserById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try {
                User s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities()) {
                    s = db.Users.Where(m => m.User_ID == id).FirstOrDefault();
                }
                return s;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsUserExist(User u)
        {
            return GetUserById(u.User_ID) == null ? false : true;
        }

        public static bool EditUser(User u)
        {
            if (u == null)
            {
                throw new ArgumentNullException("User");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(u).State = EntityState.Modified;
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

        public static bool DeleteUser(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Users.Remove(db.Users.Where(x => x.User_ID == ID).FirstOrDefault());
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
