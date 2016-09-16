﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOffice
    {
        public static List<Office> GetAllOffice()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Offices.ToList();
            }
        }

        public static bool AddOffice(Office o)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Offices.Add(o);
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

        public static Office GetOfficeById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Office s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Offices.Where(m => m.Office_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsOfficeExist(Office o)
        {
            return GetOfficeById(o.Office_ID) == null ? false : true;
        }

        public static bool EditOffice(Office o)
        {
            if (o == null)
            {
                throw new ArgumentNullException("Office");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(o).State = EntityState.Modified;
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
        public static bool DeleteOffice(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Offices.Remove(db.Offices.Where(x => x.Office_ID == ID).FirstOrDefault());
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
