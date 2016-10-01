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
        public static Order_Status Deserialize<T>(string Data)
        {
            try
            {
                return (Order_Status)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Order_Status> DeserializeList<T>(string data)
        {
            try
            {
                return (List<Order_Status>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Order_Status>)
                {
                    return (String)jsonHub.Serialize((List<Order_Status>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Order_Status)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Order_Status> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Order_Status.ToList();
            }
        }

        public static bool Insert(Order_Status os)
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

        public static Order_Status GetById(int? id)
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

        public static bool IsExist(Order_Status os)
        {
            return GetById(os.Order_Status_ID) == null ? false : true;
        }

        public static bool Edit(Order_Status os)
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

        public static bool Delete(int ID)
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
