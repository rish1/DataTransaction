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
        public static List<History_Source> GetAllHistorySource()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_Source.ToList();
            }
        }

        public static bool AddHistorySource(History_Source hs)
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

        public static History_Source GetHistorySourceById(int? id)
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

        public static bool IsHistorySourceExist(History_Source hs)
        {
            return GetHistorySourceById(hs.History_Source_ID) == null ? false : true;
        }

        public static bool EditHistorySource(History_Source hs)
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

        public static bool DeleteHistorySource(int ID)
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
