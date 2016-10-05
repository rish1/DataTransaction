using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageCurrency
    {
        public static Currency Deserialize<T>(string Data)
        {
            try
            {
                Currency a = (Currency)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Currency> DeserializeList<T>(string data)
        {
            try
            {
                List<Currency> L = (List<Currency>)jsonHub.Deserialize<T>(data);
                return L == null ? null : L;
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
                if (o == null) { return null; }
                if (o is List<Currency>)
                {
                    return (String)jsonHub.Serialize((List<Currency>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Currency)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Currency> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Currencies.ToList();
            }
        }

        public static bool Insert(Currency c)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Currencies.Add(c);
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

        public static Currency GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Currency s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Currencies.Where(m => m.Currency_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Currency c)
        {
            return GetById(c.Currency_ID) == null ? false : true;
        }

        public static bool Edit(Currency c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("Currency");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {

                    db.Entry(c).State = EntityState.Modified;
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
                    db.Currencies.Remove(db.Currencies.Where(x => x.Currency_ID == ID).FirstOrDefault());
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
