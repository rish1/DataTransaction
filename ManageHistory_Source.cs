using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageHistory_Source
    {
        public static History_Source Deserialize<T>(string Data)
        {
            try
            {
                return (History_Source)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<History_Source> DeserializeList<T>(string data)
        {
            try
            {
                return (List<History_Source>)jsonHub.Deserialize<T>(data);
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
                if (o is List<History_Source>)
                {
                    return (String)jsonHub.Serialize((List<History_Source>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((History_Source)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<History_Source> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_Source.ToList();
            }
        }

        public static bool Insert(History_Source hs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.History_Source.Add(hs);
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

        public static History_Source GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                History_Source s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.History_Source.Where(m => m.History_Source_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(History_Source hs)
        {
            return GetById(hs.History_Source_ID) == null ? false : true;
        }

        public static bool Edit(History_Source hs)
        {
            if (hs == null)
            {
                throw new ArgumentNullException("History Source");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(hs).State = EntityState.Modified;
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
                    db.History_Source.Remove(db.History_Source.Where(x => x.History_Source_ID == ID).FirstOrDefault());
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
