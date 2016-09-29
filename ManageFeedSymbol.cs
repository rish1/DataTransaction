using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageFeedSymbol
    {
        public static FeedSymbol Deserialize(string Data)
        {
            try
            {
                return (FeedSymbol)jsonHub.Deserialize(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<FeedSymbol> DeserializeList(string data)
        {
            try
            {
                return (List<FeedSymbol>)jsonHub.Deserialize(data);
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
                if (o is List<FeedSymbol>)
                {
                    return (String)jsonHub.Serialize((List<FeedSymbol>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((FeedSymbol)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<FeedSymbol> GetAllFeedSymbols()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.FeedSymbols.Include(x => x.Symbol).Include(x => x.FeedSource).ToList();
            }
        }

        public static bool AddFeedSymbol(FeedSymbol fs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.FeedSymbols.Add(fs);
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

        public static FeedSymbol GetFeedSymbolById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                FeedSymbol s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.FeedSymbols.Where(m => m.Feed_Symbol_ID == id).Include(x=>x.Symbol).Include(x=>x.FeedSource).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsFeedSymbolExist(FeedSymbol fs)
        {
            return GetFeedSymbolById(fs.Feed_Symbol_ID) == null ? false : true;
        }

        public static bool EditFeedSymbol(FeedSymbol fs)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("Feed Symbol");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(fs).State = EntityState.Modified;
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

        public static bool DeleteFeedSymbol(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.FeedSymbols.Remove(db.FeedSymbols.Where(x => x.Feed_Symbol_ID == ID).FirstOrDefault());
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
