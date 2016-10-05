using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageCity
    {

        public static City Deserialize<T>(string Data)
        {
            try
            {
                City a = (City)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<City> DeserializeList<T>(string data)
        {
            try
            {
                List<City> L = (List<City>)jsonHub.Deserialize<T>(data);
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
                if (o is List<City>)
                {
                    return (String)jsonHub.Serialize((List<City>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((City)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<City> Getall()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Cities.Include(x => x.State).ToList();
            }
        }

        public static bool Insert(City c)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Cities.Add(c);
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

        public static City GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                City s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Cities.Where(m => m.City_ID == id).Include(x => x.State).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(City c)
        {
            return GetById(c.City_ID) == null ? false : true;
        }

        public static bool Edit(City c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("City");
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
                    db.Cities.Remove(db.Cities.Where(x => x.City_ID == ID).FirstOrDefault());
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
