using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
   public class ManageBalanceType
    {
        public static List<Balance_Types> getallBalanceType()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Balance_Types.ToList();
            }
        }

        public static bool AddBalanceType(Balance_Types bt)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Balance_Types.Add(bt);
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

        public static Balance_Types getBalTypeById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Balance_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Balance_Types.Where(m => m.Balance_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public static bool BalanceTypeExist(Balance_Types bt)
        {
            return getBalTypeById(bt.Balance_Type_ID) == null ? false : true;
        }

        public static bool EditBalanceType(Balance_Types bt)
        {
            if (bt == null)
            {
                throw new ArgumentNullException("Balance Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(bt).State = EntityState.Modified;
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

        public static bool DeleteBalanceType(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Balance_Types.Remove(db.Balance_Types.Where(x=>x.Balance_Type_ID==ID).FirstOrDefault());
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
