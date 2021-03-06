﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageHistoryTransaction
    {
        public static History_Transactions Deserialize<T>(string Data)
        {
            try
            {
                History_Transactions a = (History_Transactions)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<History_Transactions> DeserializeList<T>(string data)
        {
            try
            {
                List<History_Transactions> L = (List<History_Transactions>)jsonHub.Deserialize<T>(data);
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
                if (o is List<History_Transactions>)
                {
                    return (String)jsonHub.Serialize((List<History_Transactions>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((History_Transactions)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<History_Transactions> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.History_Transactions.Include(x => x.User).Include(x => x.History_OrderBook).Include(x => x.Transaction_Types).Include(x => x.History_OrderBook1).ToList();
            }
        }

        public static bool Insert(History_Transactions ht)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.History_Transactions.Add(ht);
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

        public static History_Transactions GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                History_Transactions s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.History_Transactions.Where(m => m.Transaction_ID == id).Include(x=>x.User).Include(x=>x.History_OrderBook).Include(x=>x.Transaction_Types).Include(x=>x.History_OrderBook1).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static bool IsExist(History_Transactions ht)
        {
            return GetById(ht.Transaction_ID) == null ? false : true;
        }

        public static bool Edit(History_Transactions ht)
        {
            if (ht == null)
            {
                throw new ArgumentNullException("History Transaction");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ht).State = EntityState.Modified;
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
                    db.History_Transactions.Remove(db.History_Transactions.Where(x => x.Transaction_ID == ID).FirstOrDefault());
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
