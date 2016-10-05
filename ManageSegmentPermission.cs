using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageSegmentPermission
    {
        public static Segment_Permissions Deserialize<T>(string Data)
        {
            try
            {
                Segment_Permissions a = (Segment_Permissions)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Segment_Permissions> DeserializeList<T>(string data)
        {
            try
            {
                List<Segment_Permissions> L = (List<Segment_Permissions>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Segment_Permissions>)
                {
                    return (String)jsonHub.Serialize((List<Segment_Permissions>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Segment_Permissions)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Segment_Permissions> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Segment_Permissions.Include(x => x.User).Include(x => x.Segment).Include(x => x.Margin_Types).Include(x => x.Commission_Types).ToList();
            }
        }

        public static bool Insert(Segment_Permissions sp)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Segment_Permissions.Add(sp);
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

        public static Segment_Permissions GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Segment_Permissions s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Segment_Permissions.Where(m => m.Segment_Permission_ID == id).Include(x=>x.User).Include(x=>x.Segment).Include(x=>x.Margin_Types).Include(x=>x.Commission_Types).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static bool IsExist(Segment_Permissions sp)
        {
            return GetById(sp.Segment_Permission_ID) == null ? false : true;
        }

        public static bool Edit(Segment_Permissions sp)
        {
            if (sp == null)
            {
                throw new ArgumentNullException("Segment Permission");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(sp).State = EntityState.Modified;
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
                    db.Segment_Permissions.Remove(db.Segment_Permissions.Where(x => x.Segment_Permission_ID == ID).FirstOrDefault());
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
