using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
   public class ManageBalanceType
    {
        public static Balance_Types Deserialize<T>(string Data)
        {
            try
            {
                Balance_Types a = (Balance_Types)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Balance_Types> DeserializeList<T>(string data)
        {
            try
            {
                List<Balance_Types> L = (List<Balance_Types>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Balance_Types>)
                {
                    return (String)jsonHub.Serialize((List<Balance_Types>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Balance_Types)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Balance_Types> Getall()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Balance_Types.ToList();
            }
        }

        public static bool Insert(Balance_Types bt)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Balance_Types.Add(bt);
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

        public static Balance_Types GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Balance_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Balance_Types.Where(m => m.Balance_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public static bool IsExist(Balance_Types bt)
        {
            return GetById(bt.Balance_Type_ID) == null ? false : true;
        }

        public static bool Edit(Balance_Types bt)
        {
            if (bt == null)
            {
                throw new ArgumentNullException("Balance Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(bt).State = EntityState.Modified;
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
                    db.Balance_Types.Remove(db.Balance_Types.Where(x=>x.Balance_Type_ID==ID).FirstOrDefault());
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
