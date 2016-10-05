using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataTransaction
{
  public  class ManageBaseSymbol
    {
        // ef_manager_newEntities db = new ef_manager_newEntities();
        public static Base_Symbol Deserialize<T>(string Data)
        {
            try
            {
                Base_Symbol a = (Base_Symbol)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Base_Symbol> DeserializeList<T>(string data)
        {
            try
            {
                List<Base_Symbol> L = (List<Base_Symbol>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Base_Symbol>)
                {
                    return (String)jsonHub.Serialize((List<Base_Symbol>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Base_Symbol)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Base_Symbol> Getall()
        {
            using(ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Base_Symbol.Include(x => x.ContractKind).Include(x => x.Commission_Types).Include(x => x.Currency).Include(x => x.Exchange).Include(x => x.Sector).Include(x => x.Segment).Include(x => x.Margin_Types).ToList();
            }
            
        }

        public static bool Insert(Base_Symbol bs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Base_Symbol.Add(bs);
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

        public static Base_Symbol GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Base_Symbol s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities()) {
                    s = db.Base_Symbol.Where(m => m.Base_Symbol_ID == id).Include(x => x.ContractKind).Include(x=>x.Commission_Types).Include(x=>x.Currency).Include(x=>x.Exchange).Include(x=>x.Sector).Include(x=>x.Segment).Include(x=>x.Margin_Types).FirstOrDefault();
                }
                return s;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Base_Symbol bs)
        {
            return GetById(bs.Base_Symbol_ID) == null ? false : true;
        }

        public static bool Edit(Base_Symbol bs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(bs).State = EntityState.Modified;
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

        public static bool Delete(int id) 
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Base_Symbol.Remove(db.Base_Symbol.Where(x=>x.Base_Symbol_ID==id).FirstOrDefault());
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
