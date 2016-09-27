using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageHistoryOrderBook
    {
        public static List<History_OrderBook> GetAllHistoryOrderBook()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_OrderBook.Include(x => x.Symbol).Include(x => x.User).Include(x => x.Order_Status).Include(x => x.Order_Types).Include(x => x.History_OrderBook2).ToList();
            }
        }

        public static bool AddHistoryOrderBook(History_OrderBook hob)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.History_OrderBook.Add(hob);
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

        public static History_OrderBook GetHOBById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                History_OrderBook s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.History_OrderBook.Where(m => m.History_Order_ID == id).Include(x=>x.Symbol).Include(x=>x.User).Include(x=>x.Order_Status).Include(x=>x.Order_Types).Include(x=>x.History_OrderBook2).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsHOBExist(History_OrderBook hob)
        {
            return GetHOBById(hob.History_Order_ID) == null ? false : true;
        }

        public static bool EditHoB(History_OrderBook hob)
        {
            if (hob == null)
            {
                throw new ArgumentNullException("hob");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(hob).State = EntityState.Modified;
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

        public static bool deleteHistoryOrderBook(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.History_OrderBook.Remove(db.History_OrderBook.Where(x => x.History_Order_ID == ID).FirstOrDefault());
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
