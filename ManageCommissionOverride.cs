using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageCommissionOverride
    {
        public static List<CommissionOverride> GetAllCommissionOverride()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.CommissionOverrides.ToList();
            }
        }

        public static bool AddCommOverride(CommissionOverride co)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.CommissionOverrides.Add(co);
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

        public static CommissionOverride getComOverrideById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                CommissionOverride s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.CommissionOverrides.Where(m => m.Commission_Override_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool isComOverrideExist(CommissionOverride co)
        {
            return getComOverrideById(co.Commission_Override_ID) == null ? false : true;
        }

        public static bool EditCommissionOverride(CommissionOverride co)
        {
            if (co == null)
            {
                throw new ArgumentNullException("Commission Override");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(co).State = EntityState.Modified;
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

        public static bool DeleteComOverride(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.CommissionOverrides.Remove(db.CommissionOverrides.Where(x => x.Commission_Override_ID == ID).FirstOrDefault());
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
