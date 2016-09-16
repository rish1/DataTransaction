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
        public static List<Currency> GetAllCurrency()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Currencies.ToList();
            }
        }

        public static bool AddCurrency(Currency c)
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

        public static Currency GetCurrencyById(int? id)
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

        public static bool IsCurrencyExist(Currency c)
        {
            return GetCurrencyById(c.Currency_ID) == null ? false : true;
        }

        public static bool EditCurrency(Currency c)
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

        public static bool DeleteCurrency(int ID)
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
