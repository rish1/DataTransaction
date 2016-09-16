using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransaction
{
    class ManageBalance
    {
        ef_manager_newEntities db = new ef_manager_newEntities();
        public Boolean addBalance(Balance bal)
        {
            try
            {
                db.Balances.Add(bal);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void CalculateBalance()
        {
            try
            {
                //implementation of logic
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        public Boolean EditBalance(Balance bal)
        {
            try
            {
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public Boolean DeleteBalance(Balance bal)
        {
            try
            {
                db.Balances.Remove(bal);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
