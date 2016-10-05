using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageMargin_type
    {
        public static Margin_Types Deserialize<T>(string Data)
        {
            try
            {
                Margin_Types a = (Margin_Types)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Margin_Types> DeserializeList<T>(string data)
        {
            try
            {
                List<Margin_Types> L = (List<Margin_Types>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Margin_Types>)
                {
                    return (String)jsonHub.Serialize((List<Margin_Types>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Margin_Types)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Margin_Types> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Margin_Types.ToList();
            }
        }

        public static bool Insert(Margin_Types mt)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Margin_Types.Add(mt);
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

        public static Margin_Types GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Margin_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Margin_Types.Where(m => m.Margin_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Margin_Types mt)
        {
            return GetById(mt.Margin_Type_ID) == null ? false : true;
        }

        public static bool Edit(Margin_Types ht)
        {
            if (ht == null)
            {
                throw new ArgumentNullException("Margin Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {

                    db.Entry(ht).State = EntityState.Modified;
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
                    db.Margin_Types.Remove(db.Margin_Types.Where(x => x.Margin_Type_ID == ID).FirstOrDefault());
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
