using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageTransactionType
    {
        public static Transaction_Types Deserialize<T>(string Data)
        {
            try
            {
                Transaction_Types a = (Transaction_Types)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Transaction_Types> DeserializeList<T>(string data)
        {
            try
            {
                List<Transaction_Types> L = (List<Transaction_Types>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Transaction_Types>)
                {
                    return (String)jsonHub.Serialize((List<Transaction_Types>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Transaction_Types)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Transaction_Types> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Transaction_Types.ToList();
            }
        }

        public static bool Insert(Transaction_Types tt)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Transaction_Types.Add(tt);
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

        public static Transaction_Types GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Transaction_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Transaction_Types.Where(m => m.Transaction_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Transaction_Types tt)
        {
            return GetById(tt.Transaction_Type_ID) == null ? false : true;
        }

        public static bool Edit(Transaction_Types tt)
        {
            if (tt == null)
            {
                throw new ArgumentNullException("Transaction Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(tt).State = EntityState.Modified;
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
                    db.Transaction_Types.Remove(db.Transaction_Types.Where(x => x.Transaction_Type_ID == ID).FirstOrDefault());
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
