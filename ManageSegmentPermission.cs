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

        public static List<Segment_Permissions> GetAllSegmentPermissions()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Segment_Permissions.ToList();
            }
        }

        public static bool AddSegmentPermission(Segment_Permissions sp)
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

        public static Segment_Permissions GetSegmentPermissionById(int? id)
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
                    s = db.Segment_Permissions.Where(m => m.Segment_Permission_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static bool IsSegmentPermissionExist(Segment_Permissions sp)
        {
            return GetSegmentPermissionById(sp.Segment_Permission_ID) == null ? false : true;
        }

        public static bool EditSegmentPermission(Segment_Permissions sp)
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

        public static bool DeleteSegmentPermission(int ID)
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
