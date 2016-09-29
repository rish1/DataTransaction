using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageExchange
    {
        public static Exchange Deserialize(string Data)
        {
            try
            {
                return (Exchange)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Exchange> DeserializeList(string data)
        {
            try
            {
                return (List<Exchange>)jsonHub.Deserialize(data);
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
                if (o is List<Exchange>)
                {
                    return (String)jsonHub.Serialize((List<Exchange>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Exchange)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Exchange> GetAllExchanges()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Exchanges.Include(x => x.Country).ToList();
            }
        }

        public static bool AddExchange(Exchange ex)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Exchanges.Add(ex);
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

        public static Exchange GetExchangeById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Exchange s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Exchanges.Where(m => m.Exchange_ID == id).Include(x=>x.Country).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExchangeExist(Exchange ex)
        {
            return GetExchangeById(ex.Exchange_ID) == null ? false : true;
        }

        public static bool EditExchange(Exchange ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("Exchange");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ex).State = EntityState.Modified;
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

        public static bool DeleteExchange(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Exchanges.Remove(db.Exchanges.Where(x => x.Exchange_ID == ID).FirstOrDefault());
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
