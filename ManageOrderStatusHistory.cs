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

        public static List<Order_Status_History> GetAllOrderStatusHistory()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Order_Status_History.ToList();
            }
        }

        public static bool AddOrderstatusHistory(Order_Status_History osh)
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

        public static Order_Status_History GetOrderStatusHistoryById(int? id)
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
                    s = db.Order_Status_History.Where(m => m.Order_Status_History_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsOrderStatusHistoryExist(Order_Status_History osh)
        {
            return GetOrderStatusHistoryById(osh.Order_Status_History_ID) == null ? false : true;
        }

        public static bool EditOrderStatusHistory(Order_Status_History osh)
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

        public static bool DeleteOrderStatusHistory(int ID)
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
