﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageTransaction
    {
        public static Transaction Deserialize<T>(string Data)
        {
            try
            {
                Transaction a = (Transaction)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Transaction> DeserializeList<T>(string data)
        {
            try
            {
                List<Transaction> L = (List<Transaction>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Transaction>)
                {
                    return (String)jsonHub.Serialize((List<Transaction>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Transaction)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Transaction> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Transactions.Include(x => x.User).Include(x => x.OrderBook1).Include(x => x.Transaction_Types).ToList();
            }
        }

        public static bool Insert(Transaction t)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Transactions.Add(t);
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

        public static bool IsExist(Transaction t)
        {
            return GetById(t.Transaction_ID) == null ? false : true;
        }
        public static Transaction GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Transaction s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Transactions.Where(m => m.Transaction_ID == id).Include(x=>x.User).Include(x=>x.OrderBook1).Include(x=>x.Transaction_Types).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool Edit(Transaction t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("Transaction");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(t).State = EntityState.Modified;
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
                    db.Transactions.Remove(db.Transactions.Where(x => x.Transaction_ID == ID).FirstOrDefault());
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
