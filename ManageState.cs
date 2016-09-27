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

        public static List<State> GetAllStates()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.States.Include(x => x.Country).ToList();
            }
        }

        public static bool AddState(State s)
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

        public static State GetStateById(int? id)
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

        public static bool IsStateExist(State s)
        {
            return GetStateById(s.State_ID) == null ? false : true;
        }

        public static bool EditState(State ss)
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

        public static bool DeleteState(int ID)
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
