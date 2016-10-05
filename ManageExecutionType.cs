using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageExecutionType
    {
        public static ExecutionType Deserialize<T>(string Data)
        {
            try
            {
                ExecutionType a = (ExecutionType)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<ExecutionType> DeserializeList<T>(string data)
        {
            try
            {
                List<ExecutionType> L = (List<ExecutionType>)jsonHub.Deserialize<T>(data);
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
                if (o is List<ExecutionType>)
                {
                    return (String)jsonHub.Serialize((List<ExecutionType>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((ExecutionType)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<ExecutionType> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.ExecutionTypes.ToList();
            }
        }

        public static bool Insert(ExecutionType et)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.ExecutionTypes.Add(et);
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

        public static ExecutionType GetById(int? id)
        {

            if (id == null)
            {
                return null;
            }
            try
            {
                ExecutionType s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.ExecutionTypes.Where(m => m.ExecutionTypeID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(ExecutionType et)
        {
            return GetById(et.ExecutionTypeID) == null ? false : true;
        }

        public static bool Edit(ExecutionType et)
        {
            if (et == null)
            {
                throw new ArgumentNullException("Execution Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {

                    db.Entry(et).State = EntityState.Modified;
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
                    db.ExecutionTypes.Remove(db.ExecutionTypes.Where(x => x.ExecutionTypeID == ID).FirstOrDefault());
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
