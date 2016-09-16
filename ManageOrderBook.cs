using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOrderBook
    {
        public static List<OrderBook> GetAllOrderBook()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.OrderBooks.ToList();
            }
        }

        public static bool AddOrderBook(OrderBook ob)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.OrderBooks.Add(ob);
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

        public static OrderBook GetOrderBookById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                OrderBook s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.OrderBooks.Where(m => m.Order_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static bool IsOrderBookExist(OrderBook ob)
        {
            return GetOrderBookById(ob.Order_ID) == null ? false : true;

        }

        public static bool EditOrderBook(OrderBook ob)
        {
            if (ob == null)
            {
                throw new ArgumentNullException("OrderBook");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ob).State = EntityState.Modified;
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

        public static bool DeleteOrderBook(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.OrderBooks.Remove(db.OrderBooks.Where(x => x.Order_ID == ID).FirstOrDefault());
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
