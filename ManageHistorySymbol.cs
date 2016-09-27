using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageHistorySymbol
    {
        public static List<HistorySymbol> GetAllHistorySymbols()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.HistorySymbols.Include(x => x.History_Source).Include(x => x.Symbol).ToList();
            }
        }

        public static bool AddHistorySymbol(HistorySymbol hs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.HistorySymbols.Add(hs);
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

        public static HistorySymbol GetHistorySymbolById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                HistorySymbol s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.HistorySymbols.Where(m => m.History_Symbol_ID == id).Include(x=>x.History_Source).Include(x=>x.Symbol).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsHistorySymbolExist(HistorySymbol hs)
        {
            return GetHistorySymbolById(hs.History_Symbol_ID) == null ? false : true;
        }

        public static bool EditHistorySymbol(HistorySymbol hs)
        {
            if (hs == null)
            {
                throw new ArgumentNullException("History Symbol");
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

        public static bool DeleteHistorySymbol(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.HistorySymbols.Remove(db.HistorySymbols.Where(x => x.History_Symbol_ID == ID).FirstOrDefault());
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
