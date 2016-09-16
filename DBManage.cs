using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransaction
{
    public class DBManage : IDisposable

    {
        ef_manager_newEntities db = new ef_manager_newEntities();
        bool IsDisposed = false;
        public void Dispose()
        {
            if (!IsDisposed)
            {
                db.Dispose();
                IsDisposed = !IsDisposed;
            }
        }
    }
}
