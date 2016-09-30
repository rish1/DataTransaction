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
                return (Segment)jsonHub.Deserialize<T>(Data);
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
                return (List<Segment>)jsonHub.Deserialize<T>(data);
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
        public static List<Segment> GetAllSegments()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Segments.ToList();
            }
        }

        public static bool AddSegment(Segment sg)
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

        public static Segment GetSectorById(int? id)
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

        public static bool IsSegmentExist(Segment s)
        {
            return GetSectorById(s.Segment_ID) == null ? false : true;
        }

        public static bool EditSegment(Segment ss)
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

        public static bool DeleteSegment(int ID)
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
