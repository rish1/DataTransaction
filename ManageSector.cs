using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageSector
    {
        public static Sector Deserialize<T>(string Data)
        {
            try
            {
                return (Sector)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Sector> DeserializeList<T>(string data)
        {
            try
            {
                return (List<Sector>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Sector>)
                {
                    return (String)jsonHub.Serialize((List<Sector>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Sector)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Sector> GetAllSectors()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Sectors.ToList();
            }
        }

        public static bool AddSector(Sector s)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Sectors.Add(s);
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

        public static Sector GetSectorById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Sector ss = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    ss = db.Sectors.Where(m => m.Sector_ID == id).FirstOrDefault();
                }
                return ss;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static bool IsSectorExist(Sector s)
        {
            return GetSectorById(s.Sector_ID) == null ? false : true;
        }

        public static bool EditSector(Sector s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("Sector");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(s).State = EntityState.Modified;
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

        public static bool DeleteSector(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Sectors.Remove(db.Sectors.Where(x => x.Sector_ID == ID).FirstOrDefault());
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
