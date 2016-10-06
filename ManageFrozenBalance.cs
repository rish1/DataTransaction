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
    class ManageFrozenBalance
    {
        public static FrozenBalance Deserialize<T>(string Data)
        {
            try
            {
                FrozenBalance a = (FrozenBalance)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<FrozenBalance> DeserializeList<T>(string data)
        {
            try
            {
                List<FrozenBalance> L = (List<FrozenBalance>)jsonHub.Deserialize<T>(data);
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
                if (o is List<FrozenBalance>)
                {
                    return (String)jsonHub.Serialize((List<FrozenBalance>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((FrozenBalance)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<FrozenBalance> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.FrozenBalances.Include(x => x.Symbol).Include(x=>x.User).ToList();
            }
        }

        public static bool Insert(FrozenBalance f)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.FrozenBalances.Add(f);
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

        public static FrozenBalance GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                FrozenBalance s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.FrozenBalances.Where(m => m.FozenBalance_ID == id).Include(x => x.Symbol).Include(x=>x.User).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool IsExist(FrozenBalance f)
        {
            return GetByID(f.FozenBalance_ID) == null ? false : true;
        }

        public static bool Edit(FrozenBalance f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("FrozenBalance");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(f).State = EntityState.Modified;
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
                    db.FrozenBalances.Remove(db.FrozenBalances.Where(x => x.FozenBalance_ID == ID).FirstOrDefault());
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
