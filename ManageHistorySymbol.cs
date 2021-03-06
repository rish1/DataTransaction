﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
   
    public class ManageHistorySymbol
    {
        public static HistorySymbol Deserialize<T>(string Data)
        {
            try
            {
                HistorySymbol a = (HistorySymbol)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<HistorySymbol> DeserializeList<T>(string data)
        {
            try
            {
                List<HistorySymbol> L = (List<HistorySymbol>)jsonHub.Deserialize<T>(data);
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
                if (o is List<HistorySymbol>)
                {
                    return (String)jsonHub.Serialize((List<HistorySymbol>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((HistorySymbol)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<HistorySymbol> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.HistorySymbols.Include(x => x.History_Source).Include(x => x.Symbol).ToList();
            }
        }

        public static bool Insert(HistorySymbol hs)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.HistorySymbols.Add(hs);
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

        public static HistorySymbol GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                HistorySymbol s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.HistorySymbols.Where(m => m.History_Symbol_ID == id).Include(x=>x.History_Source).Include(x=>x.Symbol).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(HistorySymbol hs)
        {
            return GetById(hs.History_Symbol_ID) == null ? false : true;
        }

        public static bool Edit(HistorySymbol hs)
        {
            if (hs == null)
            {
                throw new ArgumentNullException("History Symbol");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(hs).State = EntityState.Modified;
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
                    db.HistorySymbols.Remove(db.HistorySymbols.Where(x => x.History_Symbol_ID == ID).FirstOrDefault());
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
