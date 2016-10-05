using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
   public class ManageCommissionType
    {
        public static Commission_Types Deserialize<T>(string Data)
        {
            try
            {
                Commission_Types a = (Commission_Types)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Commission_Types> DeserializeList<T>(string data)
        {
            try
            {
                List<Commission_Types> L = (List<Commission_Types>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Commission_Types>)
                {
                    return (String)jsonHub.Serialize((List<Commission_Types>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Commission_Types)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Commission_Types> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Commission_Types.ToList();
            }
        }

        public static bool Insert(Commission_Types ct)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Commission_Types.Add(ct);
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

        public static Commission_Types GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Commission_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Commission_Types.Where(m => m.Commission_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Commission_Types ct)
        {
            return GetById(ct.Commission_Type_ID) == null ? false : true;
        }

        public static bool Edit(Commission_Types ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException("Commission Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ct).State = EntityState.Modified;
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
                    db.Commission_Types.Remove(db.Commission_Types.Where(x => x.Commission_Type_ID == ID).FirstOrDefault());
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
