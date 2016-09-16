using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageLiquidationType
    {
        public static List<Liquidation_Types> GetAllLiquidationType()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Liquidation_Types.ToList();
            }
        }

        public static bool AddLiquidationType(Liquidation_Types lt)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Liquidation_Types.Add(lt);
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

        public static Liquidation_Types GetLiquidationTypeById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Liquidation_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Liquidation_Types.Where(m => m.Liqudation_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsLiquidationTypeExist(Liquidation_Types lt)
        {
            return GetLiquidationTypeById(lt.Liqudation_Type_ID) == null ? false : true;
        }

        public static bool EditLiquidationType(Liquidation_Types lt)
        {
            if (lt == null)
            {
                throw new ArgumentNullException("Liquidation Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(lt).State = EntityState.Modified;
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

        public static bool DeleteLiquidationType(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Liquidation_Types.Remove(db.Liquidation_Types.Where(x => x.Liqudation_Type_ID == ID).FirstOrDefault());
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
