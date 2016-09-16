using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOrderStatus
    {
        public static List<Order_Status> GetAllOrderStatus()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Order_Status.ToList();
            }
        }

        public static bool AddOrderStatus(Order_Status os)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Order_Status.Add(os);
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

        public static Order_Status GetOrderStatusById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Order_Status s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Order_Status.Where(m => m.Order_Status_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsOrderStatusExist(Order_Status os)
        {
            return GetOrderStatusById(os.Order_Status_ID) == null ? false : true;
        }

        public static bool EditOrderStatus(Order_Status os)
        {
            if (os == null)
            {
                throw new ArgumentNullException("Order Status");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(os).State = EntityState.Modified;
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

        public static bool DeleteOrderStatus(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Order_Status.Remove(db.Order_Status.Where(x => x.Order_Status_ID == ID).FirstOrDefault());
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
