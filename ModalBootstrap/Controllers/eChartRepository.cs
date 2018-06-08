using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModalBootstrap.Models;

namespace ModalBootstrap.Controllers
{
    public class eChartRepository: IDisposable
    {
        private eChartContext db = new eChartContext();
        public IEnumerable<eChart> GetAll()
        {
            return db.eCharts.ToList();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}