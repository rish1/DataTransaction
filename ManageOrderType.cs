using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOrderType
    {
        public static Order_Types Deserialize<T>(string Data)
        {
            try
            {
                return (Order_Types)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Order_Types> DeserializeList<T>(string data)
        {
            try
            {
                return (List<Order_Types>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Order_Types>)
                {
                    return (String)jsonHub.Serialize((List<Order_Types>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Order_Types)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Order_Types> GetAllOrderType()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Order_Types.ToList();
            }
        }

        public static bool AddOrderType(Order_Types ot)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Order_Types.Add(ot);
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

        public static Order_Types GetOrderTypeById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Order_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {

                    s = db.Order_Types.Where(m => m.Order_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static bool IsOrderTypeExist(Order_Types ot)
        {
            return GetOrderTypeById(ot.Order_Type_ID) == null ? false : true;

        }

        public static bool EditOrderType(Order_Types ot)
        {
            if (ot == null)
            {
                throw new ArgumentNullException("Order Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ot).State = EntityState.Modified;
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

        public static bool DeleteOrderType(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Order_Types.Remove(db.Order_Types.Where(x => x.Order_Type_ID == ID).FirstOrDefault());
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
