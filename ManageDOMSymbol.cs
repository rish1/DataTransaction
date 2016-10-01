using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageDOMSymbol
    {
        public static DOMSymbol Deserialize<T>(string Data)
        {
            try
            {
                return (DOMSymbol)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<DOMSymbol> DeserializeList<T>(string data)
        {
            try
            {
                return (List<DOMSymbol>)jsonHub.Deserialize<T>(data);
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
                if (o is List<DOMSymbol>)
                {
                    return (String)jsonHub.Serialize((List<DOMSymbol>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((DOMSymbol)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<DOMSymbol> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.DOMSymbols.Include(x => x.Symbol).ToList();
            }
        }

        public static bool Insert(DOMSymbol ds)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.DOMSymbols.Add(ds);
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

        public static DOMSymbol GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                DOMSymbol s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.DOMSymbols.Where(m => m.DOM_Symbols_ID == id).Include(x=>x.Symbol).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(DOMSymbol ds)
        {
            return GetById(ds.DOM_Symbols_ID) == null ? false : true;
        }

        public static bool Edit(DOMSymbol ds)
        {
            if (ds == null)
            {
                throw new ArgumentNullException("DOM Symbol");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {

                    db.Entry(ds).State = EntityState.Modified;
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
                    db.DOMSymbols.Remove(db.DOMSymbols.Where(x => x.DOM_Symbols_ID == ID).FirstOrDefault());
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
