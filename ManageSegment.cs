using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageSegment
    {
        public static Segment Deserialize<T>(string Data)
        {
            try
            {
                Segment a = (Segment)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Segment> DeserializeList<T>(string data)
        {
            try
            {
                List<Segment> L = (List<Segment>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Segment>)
                {
                    return (String)jsonHub.Serialize((List<Segment>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Segment)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Segment> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Segments.ToList();
            }
        }

        public static bool Insert(Segment sg)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Segments.Add(sg);
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

        public static Segment GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Segment s = null;

                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Segments.Where(m => m.Segment_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Segment s)
        {
            return GetById(s.Segment_ID) == null ? false : true;
        }

        public static bool Edit(Segment ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Segment");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ss).State = EntityState.Modified;
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
                    db.Segments.Remove(db.Segments.Where(x => x.Segment_ID == ID).FirstOrDefault());
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
