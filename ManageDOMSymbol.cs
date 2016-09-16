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
        public static List<DOMSymbol> GetAllDOMSymbols()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.DOMSymbols.ToList();
            }
        }

        public static bool AddDOMSymbol(DOMSymbol ds)
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

        public static DOMSymbol GetDOMSymbolById(int? id)
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
                    s = db.DOMSymbols.Where(m => m.DOM_Symbols_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsDomSymbolExist(DOMSymbol ds)
        {
            return GetDOMSymbolById(ds.DOM_Symbols_ID) == null ? false : true;
        }

        public static bool EditDomSymbol(DOMSymbol ds)
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

        public static bool DeleteDomSymbol(int ID)
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
