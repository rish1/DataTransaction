using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataTransaction
{
    public class ManageContractKind
    {
        public static List<ContractKind> GetAllContractKind()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.ContractKinds.ToList();
            }
        }

        public static bool AddContractKind(ContractKind ck)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.ContractKinds.Add(ck);
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

        public static ContractKind getContractKinfById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                ContractKind s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.ContractKinds.Where(m => m.Contract_Kind_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsContractKindExist(ContractKind ck)
        {
            return getContractKinfById(ck.Contract_Kind_ID) == null ? false : true;
        }

        public static bool EditContractKind(ContractKind ck)
        {
            if (ck == null)
            {
                throw new ArgumentNullException("Contract Kind");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {

                    db.Entry(ck).State = EntityState.Modified;
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

        public static bool DeleteContractKind(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.ContractKinds.Remove(db.ContractKinds.Where(x => x.Contract_Kind_ID == ID).FirstOrDefault());
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
