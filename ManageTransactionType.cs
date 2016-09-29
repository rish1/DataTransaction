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
        public static Transaction_Types Deserialize(string Data)
        {
            try
            {
                return (Transaction_Types)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Transaction_Types> DeserializeList(string data)
        {
            try
            {
                return (List<Transaction_Types>)jsonHub.Deserialize(data);
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
        public static List<Transaction_Types> GetAllTransactions()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Transaction_Types.ToList();
            }
        }

        public static bool AddTransactionType(Transaction_Types tt)
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

        public static Transaction_Types GetTransactionTypeById(int? id)
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

        public static bool IsTransactiontypeExist(Transaction_Types tt)
        {
            return GetTransactionTypeById(tt.Transaction_Type_ID) == null ? false : true;
        }

        public static bool EditTransactiontype(Transaction_Types tt)
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

        public static bool DeleteTransactiontype(int ID)
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
