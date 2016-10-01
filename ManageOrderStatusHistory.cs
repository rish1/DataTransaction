using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOrderStatusHistory
    {
        public static Order_Status_History Deserialize<T>(string Data)
        {
            try
            {
                return (Order_Status_History)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Order_Status_History> DeserializeList<T>(string data)
        {
            try
            {
                return (List<Order_Status_History>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Order_Status_History>)
                {
                    return (String)jsonHub.Serialize((List<Order_Status_History>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Order_Status_History)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Order_Status_History> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Order_Status_History.Include(x => x.Order_Status).Include(x => x.OrderBook).ToList();
            }
        }

        public static bool Insert(Order_Status_History osh)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Order_Status_History.Add(osh);
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

        public static Order_Status_History GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Order_Status_History s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Order_Status_History.Where(m => m.Order_Status_History_ID == id).Include(x=>x.Order_Status).Include(x=>x.OrderBook).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Order_Status_History osh)
        {
            return GetById(osh.Order_Status_History_ID) == null ? false : true;
        }

        public static bool Edit(Order_Status_History osh)
        {
            if (osh == null)
            {
                throw new ArgumentNullException("Order Status History");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(osh).State = EntityState.Modified;
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
                    db.Order_Status_History.Remove(db.Order_Status_History.Where(x => x.Order_Status_History_ID == ID).FirstOrDefault());
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
