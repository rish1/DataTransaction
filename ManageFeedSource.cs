
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageFeedSource
    {
        public static FeedSource Deserialize<T>(string Data)
        {
            try
            {
                return (FeedSource)jsonHub.Deserialize<T>(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<FeedSource> DeserializeList<T>(string data)
        {
            try
            {
                return (List<FeedSource>)jsonHub.Deserialize<T>(data);
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
                if (o is List<FeedSource>)
                {
                    return (String)jsonHub.Serialize((List<FeedSource>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((FeedSource)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<FeedSource> GetAllFeedSource()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.FeedSources.ToList();
            }
        }

        public static bool AddFeedSource(FeedSource fs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.FeedSources.Add(fs);
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

        public static FeedSource GetFeedSourceById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                FeedSource s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.FeedSources.Where(m => m.Feed_Source_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsFeedSourceExist(FeedSource fs)
        {
            return GetFeedSourceById(fs.Feed_Source_ID) == null ? false : true;
        }
        public static bool EditFeedSource(FeedSource fs)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("Feed Source");
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
        public static bool DeleteFeedSource(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.FeedSources.Remove(db.FeedSources.Where(x => x.Feed_Source_ID == ID).FirstOrDefault());
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
