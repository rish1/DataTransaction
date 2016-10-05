using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageState
    {
        public static State Deserialize<T>(string Data)
        {
            try
            {
                State a = (State)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<State> DeserializeList<T>(string data)
        {
            try
            {
                List<State> L = (List<State>)jsonHub.Deserialize<T>(data);
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
                if (o is List<State>)
                {
                    return (String)jsonHub.Serialize((List<State>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((State)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<State> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.States.Include(x => x.Country).ToList();
            }
        }

        public static bool Insert(State s)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.States.Add(s);
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

        public static State GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                State k = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    k = db.States.Where(m => m.State_ID == id).Include(x=>x.Country).FirstOrDefault();
                }
                return k;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(State s)
        {
            return GetById(s.State_ID) == null ? false : true;
        }

        public static bool Edit(State ss)
        {
            try
            {
                if (ss == null)
                {
                    throw new ArgumentNullException("State");
                }
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ss).State = EntityState.Modified;
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
                    db.States.Remove(db.States.Where(x => x.State_ID == ID).FirstOrDefault());
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
