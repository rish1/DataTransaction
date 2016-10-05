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
        public static User Deserialize<T>(string Data)
        {
            try
            {
                User a = (User)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<User> DeserializeList<T>(string data)
        {
            try
            {
                List<User> L = (List<User>)jsonHub.Deserialize<T>(data);
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
                if (o is List<User>)
                {
                    return (String)jsonHub.Serialize((List<User>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((User)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<User> GetAll()
        {
            using(ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Users.Include(x => x.Balance).Include(x => x.Balance_Type).Include(x => x.Currency).Include(x => x.ExecutionType1).Include(x => x.Liquidation_Types).Include(x => x.Office).ToList();
            }
        }

        public static bool Insert(User u)
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

        public static User GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try {
                User s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities()) {
                    s = db.Users.Where(m => m.User_ID == id).Include(x=>x.Balance).Include(x=>x.Balance_Type).Include(x=>x.Currency).Include(x=>x.ExecutionType1).Include(x=>x.Liquidation_Types).Include(x=>x.Office).FirstOrDefault();
                }
                return s;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(User u)
        {
            return GetById(u.User_ID) == null ? false : true;
        }

        public static bool Edit(User u)
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

        public static bool Delete(int ID)
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
