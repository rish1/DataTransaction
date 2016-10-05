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
        public static ContractKind Deserialize<T>(string Data)
        {
            try
            {
                ContractKind a = (ContractKind)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<ContractKind> DeserializeList<T>(string data)
        {
            try
            {
                List<ContractKind> L = (List<ContractKind>)jsonHub.Deserialize<T>(data);
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
                if (o is List<ContractKind>)
                {
                    return (String)jsonHub.Serialize((List<ContractKind>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((ContractKind)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<ContractKind> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.ContractKinds.ToList();
            }
        }

        public static bool Insert(ContractKind ck)
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

        public static ContractKind GetById(int? id)
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

        public static bool IsExist(ContractKind ck)
        {
            return GetById(ck.Contract_Kind_ID) == null ? false : true;
        }

        public static bool Edit(ContractKind ck)
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

        public static bool Delete(int ID)
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
