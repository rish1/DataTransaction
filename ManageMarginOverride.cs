using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageMarginOverride
    {
        public static List<MarginOverride> GetAllMarginOverride()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.MarginOverrides.ToList();
            }
        }

        public static bool AddMarginOverride(MarginOverride mo)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.MarginOverrides.Add(mo);
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

        public static MarginOverride GetMarginOverrideById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                MarginOverride s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.MarginOverrides.Where(m => m.Margin_Override_ID == id).FirstOrDefault();
                    }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsMarginOverrideExist(MarginOverride ho)
        {
            return GetMarginOverrideById(ho.Margin_Override_ID) == null ? false : true;
        }

        public static bool EditMarginOverride(MarginOverride ho)
        {
            if (ho == null)
            {
                throw new ArgumentNullException("Margin Override");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ho).State = EntityState.Modified;
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

        public static bool DeleteMarginOverride(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.MarginOverrides.Remove(db.MarginOverrides.Where(x => x.Margin_Override_ID == ID).FirstOrDefault());
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
