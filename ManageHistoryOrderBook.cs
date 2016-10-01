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
        public static History_OrderBook Deserialize<T>(string Data)
        {
            try
            {
                return (History_OrderBook)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<History_OrderBook> DeserializeList<T>(string data)
        {
            try
            {
                return (List<History_OrderBook>)jsonHub.Deserialize<T>(data);
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
                if (o is List<History_OrderBook>)
                {
                    return (String)jsonHub.Serialize((List<History_OrderBook>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((History_OrderBook)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<History_OrderBook> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_OrderBook.Include(x => x.Symbol).Include(x => x.User).Include(x => x.Order_Status).Include(x => x.Order_Types).Include(x => x.History_OrderBook2).ToList();
            }
        }

        public static bool Insert(History_OrderBook hob)
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

        public static History_OrderBook GetById(int? id)
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

        public static bool IsExist(History_OrderBook hob)
        {
            return GetById(hob.History_Order_ID) == null ? false : true;
        }

        public static bool Edit(History_OrderBook hob)
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

        public static bool Delete(int ID)
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
