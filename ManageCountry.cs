using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageCountry
    {
        public static Country Deserialize(string Data)
        {
            try
            {
                return (Country)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Country> DeserializeList(string data)
        {
            try
            {
                return (List<Country>)jsonHub.Deserialize(data);
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
                if (o is List<Country>)
                {
                    return (String)jsonHub.Serialize((List<Country>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Country)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Country> GetallCountries()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Countries.ToList();
            }
        }

        public static bool AddCountry(Country c)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Countries.Add(c);
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

        public static Country getCountryById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Country s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Countries.Where(m => m.Country_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsCountryExist(Country c)
        {
            return getCountryById(c.Country_ID) == null ? false : true;
        }

        public static bool EditCountry(Country c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("Country");
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

        public static bool DeleteCountry(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Countries.Remove(db.Countries.Where(x => x.Country_ID == ID).FirstOrDefault());
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
