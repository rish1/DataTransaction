using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageSymbol
    {
        public static Symbol Deserialize<T>(string Data)
        {
            try
            {
                Symbol a = (Symbol)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Symbol> DeserializeList<T>(string data)
        {
            try
            {
                List<Symbol> L = (List<Symbol>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Symbol>)
                {
                    return (String)jsonHub.Serialize((List<Symbol>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Symbol)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Symbol> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Symbols.Include(x => x.Base_Symbol).Include(x => x.ExecutionType1).ToList();
            }
        }

        public static bool Insert(Symbol sy)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Symbols.Add(sy);
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

        public static Symbol GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Symbol k = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    k = db.Symbols.Where(m => m.Symbol_ID == id).Include(x=>x.Base_Symbol).Include(x=>x.ExecutionType1).FirstOrDefault();
                }
                return k;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Symbol s)
        {
            return GetById(s.Symbol_ID) == null ? false : true;
        }

        public static bool Edit(Symbol ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Symbol");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ss).State = EntityState.Modified;
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
                    db.Symbols.Remove(db.Symbols.Where(x => x.Symbol_ID == ID).FirstOrDefault());
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
