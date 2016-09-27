using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
  public  class ManageCity
    {
      //  ef_manager_newEntities db = new ef_manager_newEntities();
      public static List<City> GetallCities()
        {
            using(ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Cities.ToList();
            }
        }

        public static bool AddCity(City c)
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static City GetCityId(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try {
                City s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities()) {
                    s = db.Cities.Where(m => m.City_ID == id).Include(x=>x.State).FirstOrDefault();
                }
                return s;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool isCityExist(City c)
        {
            return GetCityId(c.City_ID) == null ? false : true;
        }

        public static bool EditCity(City c)
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

        public static bool DeleteCity(int ID)
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
