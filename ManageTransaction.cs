using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageTransaction
    {
        public static Transaction Deserialize(string Data)
        {
            try
            {
                return (Transaction)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Transaction> DeserializeList(string data)
        {
            try
            {
                return (List<Transaction>)jsonHub.Deserialize(data);
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
                if (o is List<Transaction>)
                {
                    return (String)jsonHub.Serialize((List<Transaction>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Transaction)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Transaction> GetAllTransactions()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Transactions.Include(x => x.User).Include(x => x.OrderBook1).Include(x => x.Transaction_Types).ToList();
            }
        }

        public static bool AddTransaction(Transaction t)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Transactions.Add(t);
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

        public static bool IsTransactionExist(Transaction t)
        {
            return GetTransactionById(t.Transaction_ID) == null ? false : true;
        }
        public static Transaction GetTransactionById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Transaction s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Transactions.Where(m => m.Transaction_ID == id).Include(x=>x.User).Include(x=>x.OrderBook1).Include(x=>x.Transaction_Types).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool EditTransaction(Transaction t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("Transaction");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(t).State = EntityState.Modified;
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

        public static bool DeleteTransaction(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Transactions.Remove(db.Transactions.Where(x => x.Transaction_ID == ID).FirstOrDefault());
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
