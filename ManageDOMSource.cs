using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageDOMSource
    {
        public static DOMSource Deserialize<T>(string Data)
        {
            try
            {
                DOMSource a = (DOMSource)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<DOMSource> DeserializeList<T>(string data)
        {
            try
            {
                List<DOMSource> L = (List<DOMSource>)jsonHub.Deserialize<T>(data);
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
                if (o is List<DOMSource>)
                {
                    return (String)jsonHub.Serialize((List<DOMSource>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((DOMSource)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<DOMSource> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.DOMSources.ToList();
            }
        }

        public static bool Insert(DOMSource dom)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.DOMSources.Add(dom);
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

        public static DOMSource GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                DOMSource s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.DOMSources.Where(m => m.DOM_Source_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(DOMSource dom)
        {
            return GetById(dom.DOM_Source_ID) == null ? false : true;
        }

        public static bool Edit(DOMSource dom)
        {
            if (dom == null)
            {
                throw new ArgumentNullException("DOM Source");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(dom).State = EntityState.Modified;
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
                    db.DOMSources.Remove(db.DOMSources.Where(x => x.DOM_Source_ID == ID).FirstOrDefault());
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
