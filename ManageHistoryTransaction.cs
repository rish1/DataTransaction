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

        public static List<History_Transactions> GetAllHistoryTransaction()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_Transactions.ToList();
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
                    s = db.History_Transactions.Where(m => m.Transaction_ID == id).FirstOrDefault();
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
