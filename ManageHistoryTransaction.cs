using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageHistoryTransaction
    {
        public static History_Transactions Deserialize(string Data)
        {
            try
            {
                return (History_Transactions)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<History_Transactions> DeserializeList(string data)
        {
            try
            {
                return (List<History_Transactions>)jsonHub.Deserialize(data);
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
                if (o is List<History_Transactions>)
                {
                    return (String)jsonHub.Serialize((List<History_Transactions>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((History_Transactions)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<History_Transactions> GetAllHistoryTransaction()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_Transactions.Include(x => x.User).Include(x => x.History_OrderBook).Include(x => x.Transaction_Types).Include(x => x.History_OrderBook1).ToList();
            }
        }

        public static bool AddHistoryTransaction(History_Transactions ht)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.History_Transactions.Add(ht);
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

        public static History_Transactions GetHistoryTransById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                History_Transactions s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.History_Transactions.Where(m => m.Transaction_ID == id).Include(x=>x.User).Include(x=>x.History_OrderBook).Include(x=>x.Transaction_Types).Include(x=>x.History_OrderBook1).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static bool IsHistoryTransExist(History_Transactions ht)
        {
            return GetHistoryTransById(ht.Transaction_ID) == null ? false : true;
        }

        public static bool EditHistoryTransaction(History_Transactions ht)
        {
            if (ht == null)
            {
                throw new ArgumentNullException("History Transaction");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ht).State = EntityState.Modified;
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
        public static bool DeleteHistoryTransaction(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.History_Transactions.Remove(db.History_Transactions.Where(x => x.Transaction_ID == ID).FirstOrDefault());
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
